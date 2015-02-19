
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

#define IP_PACKET_MARKER 0xF6F6F6F6

void socket_packet_set_payload(SOCKET_PACKET* packet ,Int8* payload, Int16 payload_len);

SOCKET_PACKET* create_ip_packet(network_addr addr, Int16 mtu);

//use this to create the socket.
Pointer simulation_socket(network_node* host,simulation_socket_type type);

Int simulation_send(network_node* src, Int8* data, Int size, network_addr addr);
Int simulation_send_raw_socket(network_node* src, Int8* data, Int size, network_addr addr);
SOCKET_PACKET* simulation_receive_raw_socket(network_node* dst);

Int simulation_read_socket(Pointer socket,Int8* data, Int size);
Int simulation_write_socket(Pointer socket, Int8* data, Int size);
