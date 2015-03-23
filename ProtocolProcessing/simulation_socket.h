
#ifndef _SIMULATION_SOCKET_H_
	#define _SIMULATION_SOCKET_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif

typedef enum{
	socket_type_raw = 0,
	socket_type_tcp = 1,
} simulation_socket_type;

typedef struct{
	Int32 marker;

	network_addr addr;
	Int16 mtu;

	Int16 packet_len;

	Int8* paket_payload;

} SOCKET_PACKET;

#define SOCKET_PACKET_SIZE (sizeof(SOCKET_PACKET)-4) //minus the payload pointer.

#define IP_PACKET_MARKER 0xF6F6F6F6

void socket_packet_set_payload(SOCKET_PACKET* packet ,Int8* payload, Int16 payload_len);

SOCKET_PACKET* create_ip_packet(network_addr addr, Int16 mtu);
void free_ip_packet(SOCKET_PACKET* packet);
//use this to create the socket.
Pointer simulation_socket(network_node* host,simulation_socket_type type);
int simulation_socket_available(Pointer socket);
//Int simulation_send(network_node* src, Int8* data, Int size, network_addr addr);
Int simulation_send_raw_socket_node(network_node* src, Int8* data, Int size, network_node* node);
Int simulation_send_raw_socket(network_node* src, Int8* data, Int size, network_addr addr);
SOCKET_PACKET* simulation_receive_raw_socket(network_node* dst);

Int simulation_send(Pointer socket, Int8* data, Int size);
Int simulation_recv(Pointer socket, Int8* data, Int size);

Int simulation_send_host(network_node* sender, network_addr dst, Int8* data, Int size, Int16 port);

void tcp_listen(Pointer socket, int port);

Pointer tcp_accept(Pointer socket);

Int is_listen_port(Pointer socket, int port);
