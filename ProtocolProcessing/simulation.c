
#include "simulation.h"

#ifndef _LIST_H_
	#include "list.h"
#endif

#include <Windows.h>


typedef struct _NetworkNode{

	Pointer m_nodes;
	network_prefix m_prefix;

	struct _NetworkNode* m_next;

} NetworkNode;


typedef Int (*socket_read_func)(Pointer,Int8*,Int);
typedef Int (*socket_write_func)(Pointer,Int8*,Int);

typedef struct{
	
	simulation_socket_type m_type;

	Pointer m_in;
	Pointer m_out;

	socket_read_func m_read;
	socket_write_func m_write;

} SOCKET;

typedef struct{
	SOCKET m_socket;

	Int m_port;
	Int m_listen;

} BOUND_SOCKET;

#define PSOCKET(socket) ((SOCKET*)socket)

Int simulation_write_raw_socket(Pointer socket, Int8* data, Int size){
	
	UInt32 bytesWritten = 0;
	WriteFile(PSOCKET(socket)->m_in,data,size,&bytesWritten,0);
	
	return bytesWritten;
}

Int simulation_read_raw_socket(Pointer socket,Int8* data , Int size){

	UInt32 bytesRead = 0;
	ReadFile(PSOCKET(socket)->m_out,data,size,&bytesRead,0);

	return bytesRead;
}

Int simulation_read_socket(Pointer socket,Int8* data , Int size){
	
	return PSOCKET(socket)->m_read(socket,data,size);
}

Int simulation_write_socket(Pointer socket,Int8* data , Int size){
	
	return PSOCKET(socket)->m_write(socket,data,size);
}


Pointer simulation_socket(simulation_socket_type type){
	
	SOCKET* socket = malloc(sizeof(SOCKET));
	memset(socket,0,sizeof(SOCKET));
	
	CreatePipe(&socket->m_out,&socket->m_in,0,0);

	socket->m_read = simulation_read_raw_socket;
	socket->m_write = simulation_write_raw_socket;

	socket->m_type = type;

	return socket;
}