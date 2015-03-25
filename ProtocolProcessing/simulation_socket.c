

#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <malloc.h>
#include <memory.h>

#include "simulation_socket.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

#ifndef _TCP_SOCKET_H_
	#include "tcp_socket.h"
#endif

#ifndef _ROUTER_H_
	#include "router.h"
#endif

typedef Int (*socket_read_func)(Pointer,Int8*,Int);
typedef Int (*socket_write_func)(Pointer,Int8*,Int);

typedef Int (*socket_connect_func)(Pointer,network_addr);

typedef struct{
	Pointer m_read;
	Pointer m_write;
} SOCKET_PIPE;

typedef struct{
	
	simulation_socket_type m_type;

	SOCKET_PIPE m_host_pipe;
	//in a sense this does not belong here, but the implementation demands it.
	network_node* m_host_node;

//	socket_read_func m_read;
//	socket_write_func m_write;
	
} SOCKET;

static Pointer m_socket_mutex = 0;
typedef struct{
	SOCKET m_socket;

	Int m_port;
	Int m_listen;

} BOUND_SOCKET;


#define PSOCKET(socket) ((SOCKET*)socket)

SOCKET_PACKET* create_ip_packet(network_addr addr, Int16 mtu){

	SOCKET_PACKET* packet = malloc(sizeof(SOCKET_PACKET));
	memset(packet,0,sizeof(SOCKET_PACKET));

	packet->marker = IP_PACKET_MARKER;
	memcpy(packet->addr,addr,4);
	packet->mtu = mtu;

	packet->packet_len = SOCKET_PACKET_SIZE; 

	return packet;
}

void free_ip_packet(SOCKET_PACKET* packet){
	
	free(packet->paket_payload);
	free(packet);

}

void socket_packet_set_payload(SOCKET_PACKET* packet, Int8* payload, Int16 payload_size){
	
	packet->paket_payload = malloc(payload_size);
	memcpy(packet->paket_payload,payload,payload_size);

	packet->packet_len += payload_size;

}

Int simulation_write_raw_socket(Pointer socket, Int8* data, Int size){
	
	UInt32 bytesWritten = 0;
	WaitForSingleObject(m_socket_mutex,INFINITE);
	WriteFile(PSOCKET(socket)->m_host_pipe.m_write,data,size,&bytesWritten,0);
	ReleaseMutex(m_socket_mutex);

	return bytesWritten;
}

Int simulation_read_raw_socket(Pointer socket,Int8* data , Int size){

	UInt32 bytesRead = 0;
	WaitForSingleObject(m_socket_mutex,INFINITE);
	ReadFile(PSOCKET(socket)->m_host_pipe.m_read,data,size,&bytesRead,0);
	ReleaseMutex(m_socket_mutex);
	return bytesRead;
}

SOCKET_PACKET* simulation_receive_raw_socket(network_node* dst){
	
	SOCKET_PACKET* packet = malloc(sizeof(SOCKET_PACKET));
	int read = 0;
	
	memset(packet,0,sizeof(SOCKET_PACKET));
	WaitForSingleObject(m_socket_mutex,INFINITE);
	if(simulation_socket_available(dst->peer.socket)){
		read = simulation_read_raw_socket(dst->peer.socket,packet,SOCKET_PACKET_SIZE);
	}
	
	if(packet->marker != IP_PACKET_MARKER){
		ReleaseMutex(m_socket_mutex);
		return 0;
	}

	packet->paket_payload = malloc(packet->packet_len - read + 1);

	simulation_read_raw_socket(dst->peer.socket,packet->paket_payload,packet->packet_len - read);
	ReleaseMutex(m_socket_mutex);
	packet->mtu --;
	
	if(dst->sniffer){
		dst->sniffer(dst,packet);
	}

	return packet;
}

Int simulation_send_raw_socket(network_node* src, Int8* data, Int size,network_addr dst){
	
//network_get_node(src->simulation_network,dst);
	SOCKET_PACKET* packet = create_ip_packet(dst,1000);
	int err = 0;

	//TODO: split if too big for one packet
	socket_packet_set_payload(packet,data,size);

	//err += simulation_write_raw_socket(dst_node->peer.socket,packet,SOCKET_PACKET_SIZE);
	//err += simulation_write_raw_socket(dst_node->peer.socket,packet->paket_payload,packet->packet_len-SOCKET_PACKET_SIZE);

	err = simulation_send_packet(src,packet);
	free_ip_packet(packet);

	return err;
}

Int simulation_send_packet(network_node* src ,SOCKET_PACKET* packet){
	
	int err = 0;
	network_node* dst = router_get_route_node(src->node_router,packet->addr);
	
	//if(dst )
	
	WaitForSingleObject(m_socket_mutex,INFINITE);
	err += simulation_write_raw_socket(dst->peer.socket,packet,SOCKET_PACKET_SIZE);
	err += simulation_write_raw_socket(dst->peer.socket,packet->paket_payload,packet->packet_len-SOCKET_PACKET_SIZE);
	ReleaseMutex(m_socket_mutex);

	return err;
}

int simulation_socket_available(Pointer socket){
	Int avail = 0;
	PeekNamedPipe(PSOCKET(socket)->m_host_pipe.m_read,0,0,0,&avail,0);
	return avail;
}

Pointer simulation_socket(network_node* host ,simulation_socket_type type){
	
	SOCKET* socket = malloc(sizeof(SOCKET));
	memset(socket,0,sizeof(SOCKET));
	
	if(m_socket_mutex == 0){
		m_socket_mutex = CreateMutexA(0,0,0);
	}

	socket->m_host_node = host;

	//socket->m_socket_mutex = CreateMutexA(0,1,0);

	CreatePipe(&socket->m_host_pipe.m_read,&socket->m_host_pipe.m_write,0,50000);

	socket->m_type = type;

	return socket;
}

Int simulation_connect(Pointer socket, network_addr addr){
	//PSOCKET(socket)->m_connect(socket,addr);
	return 0;
}

Int simulation_send(Pointer socket, Int8* data, Int size){
	return simulation_write_raw_socket(socket,data,size);
}

Int simulation_recv(Pointer socket, Int8* data, Int size){
	return simulation_read_raw_socket(socket,data,size);
}

Int is_listen_port(Pointer socket, int port){
	if(((BOUND_SOCKET*)socket)->m_port == port){
		return 0;
	}
	return -1;
}

Int simulation_send_host(network_node* sender, network_addr dst, Int8* data, Int len, Int16 port){
	
	TCP_SEGMENT* segment = malloc(sizeof(TCP_SEGMENT)+len);
	segment->marker = TCP_MARKER;
	segment->dest_port = port;
	memcpy(segment->src_addr,sender->address,sizeof(network_addr));
	
	memcpy((Pointer)((UInt32)segment + (UInt32)sizeof(TCP_SEGMENT)),data,len);

	return simulation_send_raw_socket(sender,segment,sizeof(TCP_SEGMENT)+len,dst);
}

void tcp_listen(Pointer socket, Int port){	
	
	BOUND_SOCKET* bound_socket = malloc(sizeof(BOUND_SOCKET));
	memset(bound_socket,0,sizeof(BOUND_SOCKET));

	memcpy(bound_socket,socket,sizeof(SOCKET));

	bound_socket->m_listen = 1;
	bound_socket->m_port = port;

	list_add_item(PSOCKET(socket)->m_host_node->peer.bound_socket_list,bound_socket);
}