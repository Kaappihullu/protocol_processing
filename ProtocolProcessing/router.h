
#ifndef _ROUTER_H_
	#define _ROUTER_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif



typedef struct{

	network_addr entry_addr;
	network_addr route_addr;

	Int hops;

} ROUTE_ADVERT_ENTRY;

typedef struct{

	Pointer advert_socket;
	Pointer route_advert_list;

	Pointer router_network;


	network_node* node;

} ROUTER;

/*
 * A very simplistic replacement for BGP
 */

ROUTER* router_create(void);

void router_init(ROUTER* router, network_node* node);

void router_do_loop(ROUTER* router);

void router_init_route_table(ROUTER* router);

network_node* router_get_route_node(network_addr addr);

void router_node_link(ROUTER* router, network_node* node);

//advertise that we can route to this address.
void router_advertise_route(ROUTER* router ,ROUTE_ADVERT_ENTRY entry);
void router_advertise_all(ROUTER* router);

