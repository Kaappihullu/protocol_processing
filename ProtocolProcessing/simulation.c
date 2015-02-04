
#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <malloc.h>
#include <memory.h>

#include "simulation.h"

#ifndef _ROUTER_H_
	#include "router.h"
#endif

#ifndef _LIST_H_
	#include "list.h"
#endif




static Pointer m_network_list = 0;

#define PSIMULATION_NETWORK(network) ((SIMULATION_NETWORK*)network)

// TODO: Add BGP support.
network_node* simulation_find_peer(network_node* node , network_addr addr){
	
	int i,c;
	
	if(node->local_area_list){
		c = list_get_count(node->local_area_list);

		for(i=0;i<c;i++){
			network_node* n_node = list_get_item(node->local_area_list,i);

			if(!IS_SAME_ADDRESS(n_node->address,addr)){
				return n_node;
			}
		}
	}
	return 0;
}


void simulation_start(void){
	if(!m_network_list){
		m_network_list = list_create();
	}
}
