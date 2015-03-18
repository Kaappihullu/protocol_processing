
#include "router.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

#include <memory.h>
#include <malloc.h>

#define ADVERTISE_PORT 50

ROUTER* router_create(void){
	
	ROUTER* router = malloc(sizeof(ROUTER));
	memset(router,0,sizeof(ROUTER));

	router->route_advert_list = list_create();

	return router;
}

void router_init(ROUTER* router, network_node* node){
	router->node = node;
	router->advert_socket = simulation_socket(node,socket_type_tcp);


	tcp_listen(router->advert_socket,ADVERTISE_PORT);

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

		list_add_item(router->route_advert_list,entry);
	}

}

