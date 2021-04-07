#ifndef CLIENT_UDP_SOCKET_H
#define CLIENT_UDP_SOCKET_H

#include "base_udp_socket.h"

class ClientUDPSocket :
	public BaseUDPSocket
{
public:
	ClientUDPSocket(string addr, size_t port, size_t bufferSize = 1024);
};

#endif // CLIENT_UDP_SOCKET_H
