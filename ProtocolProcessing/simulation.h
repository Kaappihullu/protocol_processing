
#ifndef _SIMULATION_H_
	#define _SIMULATION_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif

typedef enum{
	raw = 0,
	tcp = 1,
} simulation_socket_type;


//only necessary for tcp connections. raw sockets dont have ports.
Int simulation_bind(Pointer socket,Int port);
Int simulation_listen(Pointer socket);
Int simulation_connect(Pointer socket ,network_addr addr);
//after socket has been bound and is set to listen state, use this to accept incoming connections.
Pointer simulation_accept(Pointer socket);
//use this to create the socket.
Pointer simulation_socket(simulation_socket_type type);

Int simulation_read_socket(Pointer socket,Int8* data, Int size);
Int simulation_write_socket(Pointer socket, Int8* data, Int size);

/*
 *
 * PUBLIC PARTION, MAYBE WRITE ANOTHER HEADER FILE FOR IT.
 *
 */

Pointer simulation_create_network(network_area network);
Pointer simulation_add_node_to_network(network_area network, Pointer peer);

Pointer simulation_get_node_list(network_area network);

void simulation_start(void);
void simulation_stop(void);
