#include "base_tcp_socket.h"

BaseTCPSocket::BaseTCPSocket(string addr,
	   		     size_t port,
			     size_t bufferSize): BaseSocket(addr, port, bufferSize)
{ }

void BaseTCPSocket::send(string msg, int flags)
{
	msg[msg.size()] = '\0';
	if (::send(_socket, msg.c_str(), msg.size(), flags) < 0)
		throw new std::runtime_error("Error in send!\n");
}

string BaseTCPSocket::recv(int flags)
{
	char buffer[bufferSize];
	if (::recv(_socket, buffer, bufferSize, flags) < 0 )
		throw new std::runtime_error("Error in recv!\n");
	return string(buffer);
}
