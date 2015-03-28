
#ifndef _SIMULATION_H_
	#define _SIMULATION_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif


//Pointer simulation_create_network(network_addr addr);
//Pointer simulation_add_node_to_network(Pointer simulation_network, network_node* node);

//Pointer simulation_get_node_list(Pointer simulation);

void simulation_start(void);
void simulation_stop(void);
