
#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <malloc.h>
#include <memory.h>

#include "simulation.h"

#ifndef _ROUTER_H_
	#include "router.h"
#endif

#ifndef _LIST_H_
	#include "list.h"
#endif




static Pointer m_network_list = 0;

#define PSIMULATION_NETWORK(network) ((SIMULATION_NETWORK*)network)



void simulation_start(void){
	if(!m_network_list){
		m_network_list = list_create();
	}
}
