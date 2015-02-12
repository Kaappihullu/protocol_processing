

#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <malloc.h>
#include <memory.h>

#include "simulation_socket.h"



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
	SOCKET_PIPE m_connected_pipe;
	//in a sense this does not belong here, but the implementation demands it.
	network_node* m_host_node;

//	socket_read_func m_read;
//	socket_write_func m_write;
	
} SOCKET;

typedef struct{
	SOCKET m_socket;

	socket_connect_func m_connect;
	socket_connect_func m_disconnect;

	Int m_port;
	Int m_listen;

} BOUND_SOCKET;


#define PSOCKET(socket) ((SOCKET*)socket)

#define SOCKET_PACKET_SIZE sizeof(SOCKET_PACKET)-4 //minus the payload pointer.
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

	packet->packet_len = SOCKET_PACKET_SIZE + payload_size;

}

Int simulation_write_raw_socket(Pointer socket, Int8* data, Int size){
	
	UInt32 bytesWritten = 0;
	
	WriteFile(PSOCKET(socket)->m_connected_pipe.m_write,data,size,&bytesWritten,0);

	return bytesWritten;
}

Int simulation_read_raw_socket(Pointer socket,Int8* data , Int size){

	UInt32 bytesRead = 0;
	ReadFile(PSOCKET(socket)->m_host_pipe.m_read,data,size,&bytesRead,0);

	return bytesRead;
}

SOCKET_PACKET* simulation_receive_raw_socket(network_node* dst){
	
	SOCKET_PACKET packet;
	int read = 0;

	read = simulation_read_raw_socket(dst->peer.socket,&packet,SOCKET_PACKET_SIZE);

	if(packet.marker != IP_PACKET_MARKER){
		return 0;
	}

	simulation_read_raw_socket(dst->peer.socket,packet.paket_payload,packet.packet_len);

}

Int simulation_send_raw_socket(network_node* src, Int8* data, Int size,network_addr dst){
	
	network_node* dst_node = network_get_node(src->simulation_network,dst);
	SOCKET_PACKET* packet = create_ip_packet(dst,1000);
	int err;

	//TODO: split if too big for one packet
	socket_packet_set_payload(packet,data,size);

	err = simulation_write_raw_socket(dst_node->peer.socket,packet,packet->packet_len);
	free_ip_packet(packet);

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
	
	socket->m_host_node = host;

	CreatePipe(&socket->m_host_pipe.m_read,&socket->m_host_pipe.m_write,0,0);

	socket->m_type = type;

	return socket;
}

Int simulation_connect(Pointer socket, network_addr addr){
	//PSOCKET(socket)->m_connect(socket,addr);
	return 0;
}
