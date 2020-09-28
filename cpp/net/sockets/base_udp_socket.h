#ifndef BASE_UDP_SOCKET_H
#define BASE_UDP_SOCKET_H

#include "base_socket.h"
#include <string>

using std::string;

class BaseUDPSocket:
	public BaseSocket
{
public:
	BaseUDPSocket(string addr, size_t port, size_t bufferSize = 1024);
	string recv(int flags = NULL);
	void send(string msg, int flags = NULL);
};

#endif // BASE_UDP_SOCKET_H
