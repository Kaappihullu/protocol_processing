
#ifndef _SIMULATION_H_
	#define _SIMULATION_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif


Pointer simulation_create_network(network_area network);
Pointer simulation_add_node_to_network(network_area network, Pointer peer);

Pointer simulation_get_node_list(network_area network);

void simulation_start(void);
void simulation_stop(void);
