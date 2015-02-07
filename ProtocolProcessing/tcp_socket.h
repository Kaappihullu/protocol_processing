
#ifndef _TCP_SOCKET_H_
	#define _TCP_SOCKET_H_
#endif

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

typedef struct{

	//SOCKET_PACKET ip_packet;
	
	Int32 marker;
	Int16 dest_port;
	Int16 src_port;

} TCP_SEGMENT;

SOCKET_PACKET* tcp_encapsulate_segment(TCP_SEGMENT* segment, SOCKET_PACKET* packet);
//socket_package_set_payload(encapsulate_packet(tcp_create_packet(blaa,blaa)));
SOCKET_PACKET* tcp_create_packet(Int16 dest_port,Int16 src_port, network_addr dest);

Int is_tcp_segment(SOCKET_PACKET* packet);
