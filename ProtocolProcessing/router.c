
#include "router.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

#ifndef _NETWORK_H_
#include "network.h"
#endif

#include <memory.h>
#include <malloc.h>

#define ADVERTISE_PORT 50

ROUTER* router_create(void){
	
	ROUTER* router = malloc(sizeof(ROUTER));
	memset(router,0,sizeof(ROUTER));

	router->route_advert_list = list_create();
	router->router_network = network_create_simulation_network();

	return router;
}

void router_init(ROUTER* router, network_node* node){
	router->node = node;
	router->advert_socket = simulation_socket(node,socket_type_tcp);

	network_add_simulation_network(router->router_network,node);

	tcp_listen(router->advert_socket,ADVERTISE_PORT);
	
}

void router_node_link(ROUTER* router, network_node* node){

	ROUTE_ADVERT_ENTRY entry;

	network_add_simulation_network(router->router_network,node);

	memcpy(entry.entry_addr,node->address,4);
	memcpy(entry.route_addr,router->node->address,4);
	entry.hops = 1;

	router_advertise_route(router,entry);

}

void router_advertise_all(ROUTER* router){

	int i,c = list_get_count(router->route_advert_list);

	for(i=0;i<c;i++){
		ROUTE_ADVERT_ENTRY* entry = list_get_item(router->route_advert_list,i);
		router_advertise_route(router,*entry);
	}

}

void router_advertise_route(ROUTER* router, ROUTE_ADVERT_ENTRY entry){
	
	int i,c = network_get_node_count(router->router_network);

	entry.hops ++;
	memcpy(entry.route_addr,router->node->address,4);

	for(i=0;i<c;i++){
		network_node* node = network_get_node_by_index(router->router_network,i);

		if(node == router->node){
			continue;
		}

		simulation_send_host(router->node,node->address,&entry,sizeof(ROUTE_ADVERT_ENTRY),ADVERTISE_PORT);

	}

	c = network_get_node_count(router->node->simulation_network);
	
	for(i=0;i<c;i++){
		network_node* node = network_get_node_by_index(router->node->simulation_network,i);

		if(node == router->node){
			continue;
		}

		simulation_send_host(router->node,node->address,&entry,sizeof(ROUTE_ADVERT_ENTRY),ADVERTISE_PORT);

	}

}

Int router_get_entry_index(ROUTER* router, ROUTE_ADVERT_ENTRY* entry){
	
	int i, c = list_get_count(router->route_advert_list);

	for(i = 0;i<c;i++){
		ROUTE_ADVERT_ENTRY* list_entry = list_get_item(router->route_advert_list,i);
		
		if(IS_SAME_ADDRESS(entry->entry_addr,list_entry->entry_addr) && IS_SAME_ADDRESS(entry->route_addr,list_entry->route_addr)){
			return i;
		}

	}
	return -1;
}

void router_do_loop(ROUTER* router){

	if(simulation_socket_available(router->advert_socket)){
		ROUTE_ADVERT_ENTRY* entry = malloc(sizeof(ROUTE_ADVERT_ENTRY));
		simulation_recv(router->advert_socket,entry,sizeof(ROUTE_ADVERT_ENTRY));
		if(router_get_entry_index(router,entry) == -1){
			list_add_item(router->route_advert_list,entry);
			router_advertise_all(router);
		}
	}

}

