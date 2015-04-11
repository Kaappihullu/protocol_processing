
#ifndef _TCP_SOCKET_H_
	#include "tcp_socket.h"
#endif

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#include <memory.h>
#include <malloc.h>

TCP_SEGMENT* tcp_create_segment(void){
	
	TCP_SEGMENT* segment = malloc(sizeof(TCP_SEGMENT));
	memset(&segment,0,sizeof(TCP_SEGMENT));

	segment->marker = TCP_MARKER;

	return segment;
}

Int is_tcp_segment(SOCKET_PACKET* packet){
	
	if( TCP_MARKER == *(Int*)packet->paket_payload){
		return 0;
	}
	return -1;
}

SOCKET_PACKET* tcp_encapsulate_segment(TCP_SEGMENT* segment, SOCKET_PACKET* packet){
	
	Int8* payload = malloc(packet->packet_len-SOCKET_PACKET_SIZE+sizeof(TCP_SEGMENT));
	
	memcpy(payload,segment,sizeof(TCP_SEGMENT));
	memcpy(((UInt32)payload + sizeof(TCP_SEGMENT)),packet->paket_payload,packet->packet_len-SOCKET_PACKET_SIZE);

	free(packet->paket_payload);
	packet->paket_payload = payload;
	packet->packet_len = packet->packet_len-SOCKET_PACKET_SIZE+sizeof(TCP_SEGMENT);

	return packet;
}
