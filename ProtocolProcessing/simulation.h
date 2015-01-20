
#ifndef _SIMULATION_H_
	#define _SIMULATION_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif

Int simulation_bind(Pointer socket,Int port);
Int simulation_listen(Pointer socket);
Pointer simulation_connect(UInt8 addr[4]);
Pointer simulation_accept(Pointer socket);


Int8* simulation_read_packet(Pointer socket,Int32* size);

Int simulation_broadcast_write(Int8* data, Int size);
Int8* simulation_broadcast_read(Int size);
Int simulation_broadcast_poll(void);
