
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

void router_init_route_table(ROUTER* router){
	int i, c = network_get_node_count(router->node->simulation_network);
	
	for(i=0;i<c;i++){
		int index;
		network_node* node = network_get_node_by_index(router->node->simulation_network,i);
		ROUTE_ADVERT_ENTRY* entry = malloc(sizeof(ROUTE_ADVERT_ENTRY));

		if(IS_SAME_ADDRESS(node->address,router->node->address)){
			continue;
		}

		entry->hops = 1;
		memcpy(entry->entry_addr,node->address,4);
		memcpy(entry->route_addr,router->node->address,4);

		index = router_get_entry_index(router,entry);
		if(index == -1){
			list_add_item(router->route_advert_list,entry);
		}else{
			free(entry);
		}

	}

	c = network_get_node_count(router->router_network);
	
	for(i=0;i<c;i++){
		int index;
		network_node* node = network_get_node_by_index(router->router_network,i);
		ROUTE_ADVERT_ENTRY* entry = malloc(sizeof(ROUTE_ADVERT_ENTRY));

		if(IS_SAME_ADDRESS(node->address,router->node->address)){
			continue;
		}

		entry->hops = 1;
		memcpy(entry->entry_addr,node->address,4);
		memcpy(entry->route_addr,router->node->address,4);

		index = router_get_entry_index(router,entry);
		if(index == -1){
			list_add_item(router->route_advert_list,entry);
		}else{
			free(entry);
		}

	}


}

void router_init(ROUTER* router, network_node* node){
	
	router->node = node;
	router->advert_socket = simulation_socket(node,socket_type_tcp);

	network_add_simulation_network(router->router_network,node);

	tcp_listen(router->advert_socket,ADVERTISE_PORT);
	


}

ROUTE_ADVERT_ENTRY router_get_route(ROUTER* router, network_addr dst){
	
	int i,c = list_get_count(router->route_advert_list);

	ROUTE_ADVERT_ENTRY selected_entry;
	selected_entry.hops = 100;

	for(i=0;i<c;i++){
		ROUTE_ADVERT_ENTRY* entry = list_get_item(router->route_advert_list,i);
		
		if(IS_SAME_ADDRESS(entry->entry_addr,dst)){
			if(selected_entry.hops > entry->hops){
				selected_entry = *entry;
			}
		}

	}
	return selected_entry;
}

network_node* router_get_route_node(ROUTER* router, network_addr dst){
	
	ROUTE_ADVERT_ENTRY entry = router_get_route(router,dst);
	network_node* node = 0;
	//no record in routing table.
	if(entry.hops == 100){
		node = network_get_node(router->node->simulation_network,dst);
		if(node == 0){
			node = network_get_node(router->router_network,dst);
		}
	}else if(IS_SAME_ADDRESS(entry.route_addr,router->node->address)){
		node = network_get_node(router->node->simulation_network,entry.entry_addr);

		if(node == 0){
			node = network_get_node(router->router_network,entry.entry_addr);
		}
	}else{//destination is not reachable directly from this node.
		node = network_get_node(router->router_network,entry.route_addr);
		if(node == 0){
			node = network_get_node(router->node->simulation_network,entry.route_addr);
		}
	}

	if(node == 0){
		return 0;
	}

	return node;
}

void router_node_link(ROUTER* router, network_node* node){

	ROUTE_ADVERT_ENTRY* entry  = malloc(sizeof(ROUTE_ADVERT_ENTRY));

	Pointer tmp_network = node->simulation_network;
	network_add_simulation_network(router->router_network,node);
	node->simulation_network = tmp_network;

	memcpy(entry->entry_addr,node->address,4);
	memcpy(entry->route_addr,router->node->address,4);
	entry->hops = 1;

	list_add_item(router->route_advert_list,entry);

	router_advertise_all(router);
	//router_advertise_route(router,entry);

}

void router_advertise_all(ROUTER* router){

	int i,c = list_get_count(router->route_advert_list);

	for(i=0;i<c;i++){
		ROUTE_ADVERT_ENTRY* entry = list_get_item(router->route_advert_list,i);
		router_advertise_route(router,*entry);
	}

	c = network_get_node_count(router->node->simulation_network);

	for(i=0;i<c;i++){
		ROUTE_ADVERT_ENTRY entry;
		network_node* node = network_get_node_by_index(router->node->simulation_network,i);

		entry.hops = 1;
		memcpy(entry.route_addr,router->node->address,4);
		memcpy(entry.entry_addr,node->address,4);
		router_advertise_route(router,entry);
	}

}

void router_advertise_route(ROUTER* router ,ROUTE_ADVERT_ENTRY entry){
	
	int i,c = network_get_node_count(router->router_network);
	Pointer tmp_network;

	entry.hops ++;
	memcpy(entry.route_addr,router->node->address,4);

	//yeah...
	//tmp_network = router->node->simulation_network;
	//router->node->simulation_network = router->router_network;

	for(i=0;i<c;i++){
		network_node* node = network_get_node_by_index(router->router_network,i);

		if(node == router->node){
			continue;
		}
		simulation_send_host(router->node,node->address,&entry,sizeof(ROUTE_ADVERT_ENTRY),ADVERTISE_PORT);

	}
	//router->node->simulation_network = tmp_network;
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

	router_init_route_table(router);

	if(simulation_socket_available(router->advert_socket)){
		ROUTE_ADVERT_ENTRY* entry = malloc(sizeof(ROUTE_ADVERT_ENTRY));
		int index;
		simulation_recv(router->advert_socket,entry,sizeof(ROUTE_ADVERT_ENTRY));
		
		if(IS_SAME_ADDRESS(entry->route_addr,entry->entry_addr) || IS_SAME_ADDRESS(router->node->address,entry->entry_addr)){
			free(entry);
			return;
		}
		
		index = router_get_entry_index(router,entry);

		if(index == -1){
			
			list_add_item(router->route_advert_list,entry);
			router_advertise_route(router,*entry);
			//router_advertise_all(router);
		}else{
			ROUTE_ADVERT_ENTRY* list_entry = list_get_item(router->route_advert_list,index);

			if(list_entry->hops > entry->hops){
				
				free(list_get_item(router->route_advert_list,index));
				list_set_item(router->route_advert_list,list_entry,index);
				
			}else{
				free(entry);
			}
		}
	}

}

