
#ifndef _ROUTER_H_
	#define _ROUTER_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _SIMULATION_H_
	#include "simulation.h"
#endif

Pointer router_create(void);

simulation_addr* router_get_address(Pointer peer);
