
#include <Windows.h>

#include "network.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

network_node* create_network_node(void){
	
	network_node* node = malloc(sizeof(network_node));
	memset(node,0,sizeof(network_node));

	return node;
}
//needs a proper bitwise operations.
Int is_in_network_prefix(network_prefix prefix, network_node node){
	
}

