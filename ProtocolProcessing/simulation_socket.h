
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


//only necessary for tcp connections. raw sockets dont have ports.
Int simulation_bind(Pointer socket,Int port);
Int simulation_listen(Pointer socket);
Int simulation_connect(Pointer socket ,network_addr addr);
//after socket has been bound and is set to listen state, use this to accept incoming connections.
Pointer simulation_accept(Pointer socket);
//use this to create the socket.
Pointer simulation_socket(network_node* host,simulation_socket_type type);

Int simulation_read_socket(Pointer socket,Int8* data, Int size);
Int simulation_write_socket(Pointer socket, Int8* data, Int size);
