#include "client_tcp_socket.h"

ClientTCPSocket::ClientTCPSocket(string remoteAddr,
			   size_t port, 
			   size_t bufferSize):
					BaseTCPSocket(remoteAddr, port, bufferSize)
{
	if (connect(this->_socket, (struct sockaddr*)&this->addr, sizeof(this->addr)) < 0)
		throw new std::runtime_error("Cant connect to socket!\n");
}
