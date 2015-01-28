#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include "network.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

#include <malloc.h>
#include <memmory.h>

network_node* network_create_node(void){
	
	network_node* node = malloc(sizeof(network_node));
	memset(node,0,sizeof(network_node));

	return node;
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

