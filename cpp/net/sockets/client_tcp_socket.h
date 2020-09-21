#ifndef CLIENT_TCP_SOCKET_H
#define CLIENT_TCP_SOCKET_H

#include "base_tcp_socket.h"

class ClientSocket:
	public BaseTCPSocket
{
public:
	ClientSocket(string remoteAddr, size_t port):
		BaseTCPSocket(remoteAddr, port)
	{
		connect(this->_socket, (struct sockaddr*)&this->addr, sizeof(this->addr));
	}
};

#endif // CLIENT_TCP_SOCKET_H
