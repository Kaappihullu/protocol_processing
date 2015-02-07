
#ifndef _NETWORK_H_
	#define _NETWORK_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

typedef UInt8 network_addr[4];

typedef struct{
	network_addr gateway;
	network_addr local_subnet;
} network_area;

typedef struct{
	network_addr prefix;
	Int prefix_len;
}network_prefix;

#define ADDRESS(a,a1,a2,a3,a4) {a[0] = a1;a[1] = a2;a[2] = a3; a[3] = a4;}
#define IS_SAME_ADDRESS(x,y) ((x[0] == y[0]) && (x[1] == y[1]) && (x[2] == y[2]) && (x[3] == y[3]))

typedef struct _network_node{

	network_prefix prefix;
	
	network_addr address;
	
	//Pointer thread_handle;

	struct{
		//the main socket.
		Pointer socket;
		//really!?
		Pointer bound_socket_list;
	} peer;

} network_node;

typedef struct _network_node_chain{
	 network_node* current;
	 struct _network_node_chain* next;
} network_node_chain;

void network_add_to_network(network_node* node);

network_node* network_create_node(void);
network_node_chain* network_create_node_chain(void);

void network_free_node_chain(network_node_chain* chain);

Int is_in_network_prefix(network_prefix prefix, network_addr addr);

Pointer network_create_simulation_network(network_area area);
void network_add_simulation_network(Pointer simulation_network, network_addr addr);
//void network_link_simulation_network(Pointer simulation_network1, Pointer simulation_network2);

