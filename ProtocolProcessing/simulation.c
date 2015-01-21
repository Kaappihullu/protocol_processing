
#include "simulation.h"

#include <Windows.h>

typedef struct{
	
	simulation_socket_type m_type;

	Pointer m_in;
	Pointer m_out;

} SOCKET;

typedef struct{
	SOCKET m_socket;

	Int m_port;
	Int m_listen;

} BOUND_SOCKET;

#define PSOCKET(socket) ((SOCKET*)socket)

Pointer simulation_socket(simulation_socket_type type){
	
	SOCKET* socket = malloc(sizeof(SOCKET));
	memset(socket,0,sizeof(SOCKET));
	
	CreatePipe(&socket->m_out,&socket->m_in,0,0);

	socket->m_type = type;

	return socket;
}

Int simulation_write_socket(Pointer socket, Int8* data, Int size){
	
	UInt32 bytesWritten = 0;
	WriteFile(PSOCKET(socket)->m_in,data,size,&bytesWritten,0);

	return bytesWritten;
}

Int simulation_read_socket(Pointer socket,Int8* data , Int size){
	
	UInt32 bytesRead = 0;
	ReadFile(PSOCKET(socket)->m_out,data,size,&bytesRead,0);

	return bytesRead;
}
