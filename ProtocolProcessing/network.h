
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

#define IS_SAME_ADDRESS(x,y) ((x[0] == y[0]) && (x[1] == y[1]) && (x[2] == y[2]) && (x[3] == y[3]))

typedef struct _network_node{

	network_prefix m_prefix;
	
	Pointer m_child_peer_list;
	Pointer m_child_node_list;
	struct _network_node* m_next;

} network_node;


network_node* create_network_node(void);

Int is_in_network_prefix(network_prefix prefix, network_addr addr);
