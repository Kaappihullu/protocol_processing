#define WIN32_LEAN_AND_MEAN
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
Int is_in_network_prefix(network_prefix prefix, network_addr addr){
	
	int i;

	for(i=0;8*(i+1)<prefix.prefix_len;i++){
		if(prefix.prefix[i] != addr[i]){
			return 1;
		}
	}
	return 0;
}

