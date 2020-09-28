#include "client_udp_socket.h"

ClientUDPSocket::ClientUDPSocket(string addr,
				 size_t port,
				 size_t bufferSize):BaseUDPSocket(addr, port, bufferSize)
{}
