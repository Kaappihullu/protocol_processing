
#ifndef _NETWORK_H_
	#define _NETWORK_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

typedef struct{
	simulation_addr gateway;
	simulation_addr local_subnet;
} network_area;

typedef struct{
	simulation_addr prefix;
	Int prefix_len;
}network_prefix;


typedef struct _network_node{

	network_prefix m_prefix;
	
	Pointer m_child_list;
	struct _network_node* m_next;

} network_node;


network_node* create_network_node(void);
