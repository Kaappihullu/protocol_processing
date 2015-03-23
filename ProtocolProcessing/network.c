#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include "network.h"

#ifndef _SIMULATION_SOCKET_H_
	#include "simulation_socket.h"
#endif

#ifndef _LIST_H_
	#include "list.h"
#endif

#ifndef _TCP_SOCKET_H_
	#include "tcp_socket.h"
#endif

#ifndef _ROUTER_H_
	#include "router.h"
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

void network_link_network(network_node* node1, network_node* node2){
	router_node_link(node1->node_router,node2);
}

int network_get_route_count(network_node* node){
	return list_get_count(((ROUTER*)node->node_router)->route_advert_list);
}

Pointer network_get_route_by_index(network_node* node, Int index){
	return list_get_item(((ROUTER*)node->node_router)->node,index);	
}

Int network_get_node_count(Pointer simulation_network){
	return list_get_count(PSIMULATION_NETWORK(simulation_network)->m_node_list);
}

network_node* network_get_node_by_index(Pointer simulation_network, Int index){
	network_node* node = list_get_item(PSIMULATION_NETWORK(simulation_network)->m_node_list,index);
	return list_get_item(PSIMULATION_NETWORK(simulation_network)->m_node_list,index);
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


static Int m_network_last_id = 0;

network_node* network_create_node(network_addr addr){
	
	network_node* node = malloc(sizeof(network_node));
	
	memset(node,0,sizeof(network_node));
	node->node_id = ++ m_network_last_id;
	memcpy(node->address,addr,4);
	
	node->peer.socket = simulation_socket(node,socket_type_raw);
	node->peer.bound_socket_list = list_create();

	node->node_router = router_create();
	router_init(node->node_router,node);

	return node;
}

Int network_node_get_id(network_node* node){
	return node->node_id;
}

UInt8* network_node_get_address(network_node* node){
	return (UInt8*)node->address;
}


void network_add_simulation_network(Pointer simulation_network, network_node* node){

	//memcpy(&node->prefix.prefix,&PSIMULATION_NETWORK(simulation_network)->m_gateway->prefix,sizeof(network_prefix));
	node->simulation_network = simulation_network;
	list_add_item(PSIMULATION_NETWORK(simulation_network)->m_node_list,node);

}

network_node_chain* network_create_node_chain(void){
	
	network_node_chain* chain = malloc(sizeof(network_node_chain));
	memset(chain,0,sizeof(network_node_chain));

	return chain;
}

Pointer network_get_listen(network_node* node, int port){
	
	int count = list_get_count(node->peer.bound_socket_list);
	int i;
	for(i = 0;i<count;i++){
		Pointer socket = list_get_item(node->peer.bound_socket_list,i);
		if(!is_listen_port(socket,port)){
			return socket;
		}
	}
	return 0;
}

void network_node_install_packet_sniffer(network_node* node, PACKET_SNIFFER sniffer){
	node->sniffer = sniffer;
}

void network_do_loop(Pointer simulation_network){
	
	int count = network_get_node_count(simulation_network);
	int i;

	for(i=0;i<count;i++){
		network_node* node = network_get_node_by_index(simulation_network,i);

		SOCKET_PACKET* packet = simulation_receive_raw_socket(node);

		if(!packet){
			continue;
		}

		if(!is_tcp_segment(packet)){
			TCP_SEGMENT* packet_tcp = packet->paket_payload;

			Pointer socket = network_get_listen(node,packet_tcp->dest_port);
			if(socket){
				simulation_send(socket,packet->paket_payload + sizeof(TCP_SEGMENT),packet->packet_len - (SOCKET_PACKET_SIZE + sizeof(TCP_SEGMENT)));
			}
		}
		router_do_loop(node->node_router);
		//free_ip_packet(packet);
	}

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
