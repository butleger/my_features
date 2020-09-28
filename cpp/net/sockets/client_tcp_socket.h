#ifndef CLIENT_TCP_SOCKET_H
#define CLIENT_TCP_SOCKET_H

#include "base_tcp_socket.h"

class ClientTCPSocket:
	public BaseTCPSocket
{
public:
	ClientTCPSocket(string remoteAddr, size_t port, size_t bufferSize = 1024);
};

#endif // CLIENT_TCP_SOCKET_H
