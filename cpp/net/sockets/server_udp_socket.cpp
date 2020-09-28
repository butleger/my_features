#include "server_udp_socket.h"

ServerUDPSocket::ServerUDPSocket(string addr,
				 size_t port,
				 size_t bufferSize) : BaseUDPSocket(addr, port, bufferSize)
{
	bind(this->_socket, (sockaddr*)&this->addr, sizeof(this->addr));
}
