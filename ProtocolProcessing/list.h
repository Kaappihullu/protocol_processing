
#ifndef _LIST_H_
	#define _LIST_H_
#endif

#ifndef _TYPES_H_
	#include "types.h"
#endif


Pointer list_create(void);

void list_add_item(Pointer list, Pointer item);
Pointer list_get_item(Pointer list, Int index);
void list_set_item(Pointer list, Pointer item, Int index);

int list_get_count(Pointer list);
