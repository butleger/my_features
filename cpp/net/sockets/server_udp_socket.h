#ifndef SERVER_UDP_SOCKET_H
#define SERVER_UDP_SOCKET_H

#include "base_udp_socket.h"

class ServerUDPSocket:
	public BaseUDPSocket
{
public:
	ServerUDPSocket(string addr, size_t port, size_t bufferSize = 1024);
};

#endif // SERVER_UDP_SOCKET_H
