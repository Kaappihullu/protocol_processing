#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include "network.h"

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

#ifndef _LIST_H_
	#include "list.h"
#endif

#include <malloc.h>
#include <memory.h>


typedef struct{
	//network_node* m_gateway;
	Pointer m_node_list;
} SIMULATION_NETWORK;

#define PSIMULATION_NETWORK(network) ((SIMULATION_NETWORK*)network)

//needs a proper bitwise operations.
Int is_in_network_prefix(network_prefix prefix, network_addr addr){
	
	int i;

	for(i=0;8*(i+1)<prefix.prefix_len;i++){
		if(prefix.prefix[i] != addr[i]){
			return 1;
		}
	}
	return 0;
}

Pointer network_create_simulation_network(void){

	SIMULATION_NETWORK* simulation_network = malloc(sizeof(SIMULATION_NETWORK));
	

	simulation_network->m_node_list = list_create();

	return simulation_network;
}
//returns network_node with the address given by addr parameter, if it exists in the network, returns null if it doesnt.
network_node* network_get_node(Pointer simulation_network, network_addr addr){
	
	int i,c;

	/*if(is_in_network_prefix(PSIMULATION_NETWORK(simulation_network)->m_area.local_subnet,addr)){
		return 0;
	}*/

	c = list_get_count(PSIMULATION_NETWORK(simulation_network)->m_node_list);

	for(i = 0;i<c;i++){
		network_node* node = list_get_item(PSIMULATION_NETWORK(simulation_network)->m_node_list,i);
		if(IS_SAME_ADDRESS(node->address,addr)){
			return node;
		}
	}
	return 0;
}


network_node* network_create_node(network_addr addr){
	
	network_node* node = malloc(sizeof(network_node));
	
	memset(node,0,sizeof(network_node));
	memcpy(node->address,addr,4);
	
	node->peer.socket = simulation_socket(node,socket_type_raw);
	node->peer.bound_socket_list = list_create();

	return node;
}

void network_add_to_network(Pointer simulation_network, network_node* node){

	//memcpy(&node->prefix.prefix,&PSIMULATION_NETWORK(simulation_network)->m_gateway->prefix,sizeof(network_prefix));
	node->simulation_network = simulation_network;
	list_add_item(PSIMULATION_NETWORK(simulation_network)->m_node_list,node);

}

network_node_chain* network_create_node_chain(void){
	
	network_node_chain* chain = malloc(sizeof(network_node_chain));
	memset(chain,0,sizeof(network_node_chain));

	return chain;
}

void network_free_node(network_node* node){
	free(node);
}

void network_free_node_chain(network_node_chain* chain){
	
	if(chain){
		network_free_node_chain(chain->next);
	}

	network_free_node(chain->current);

	free(chain);

}
