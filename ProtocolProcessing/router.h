
#ifndef _ROUTER_H_
	#define _ROUTER_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

#ifndef _NETWORK_H_
	#include "network.h"
#endif

Pointer router_create(void);

network_addr* router_get_address(Pointer peer);

void router_set_address(Pointer peer, network_addr addr);
