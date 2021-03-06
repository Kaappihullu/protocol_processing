
#include "list.h"

#include <malloc.h>
#include <memory.h>

typedef struct{
	Int m_count;
	Int m_capacity;

	Pointer m_head;

} LIST;

#define POINTER_SIZE 4

#define MEMPOS(pointer,index) (Pointer)(((UInt)(pointer)) + (index*POINTER_SIZE))
#define MEMPOS_ITEM(pointer,index) *(Pointer*)MEMPOS(pointer,index)
#define PLIST(list) ((LIST*)list)

Pointer list_create(void){

	LIST* list = malloc(sizeof(LIST));
	memset(list,0,sizeof(LIST));
	return list;
}


void list_resize(Pointer list, Int nCapacity){

	Pointer nHead = malloc(nCapacity*POINTER_SIZE);
	if(PLIST(list)->m_capacity){
		memcpy(nHead,PLIST(list)->m_head,PLIST(list)->m_capacity*POINTER_SIZE);
	}

	PLIST(list)->m_capacity = nCapacity;
	free(PLIST(list)->m_head);
	PLIST(list)->m_head = nHead;

}

int list_get_count(Pointer list){
	return PLIST(list)->m_count;
}

Pointer list_get_item(Pointer list, Int index){
	return MEMPOS_ITEM(PLIST(list)->m_head,index);
}

void list_set_item(Pointer list, Pointer item, Int index){
	memcpy(MEMPOS(PLIST(list)->m_head,index),&item,4);
}

void list_add_item(Pointer list, Pointer item){

	if(PLIST(list)->m_capacity == PLIST(list)->m_count){
		list_resize(list,PLIST(list)->m_capacity*2 + 1);
	}

	memcpy(MEMPOS(PLIST(list)->m_head,PLIST(list)->m_count++),&item,4);
	//PLIST(list)->m_count++;
}
