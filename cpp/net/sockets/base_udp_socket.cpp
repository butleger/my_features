#include "base_udp_socket.h"

BaseUDPSocket::BaseUDPSocket(	string addr, 
				size_t port,
				size_t bufferSize):
				BaseSocket(addr, port, bufferSize, SOCK_DGRAM)
{}

string BaseUDPSocket::recv(int flags)
{
	char buff[bufferSize];
	socklen_t addr_size = sizeof(addr);
	if (::recvfrom(_socket, buff, bufferSize, flags, (sockaddr*)&addr, &addr_size) < 0)
		throw new std::runtime_error("Error in recvform!\n");
	return string(buff);
}

void BaseUDPSocket::send(string msg, int flags)
{
	msg[msg.size()] = '\0';
	if (::sendto(_socket, msg.c_str(), msg.size(), flags, (sockaddr*)&addr, sizeof(addr)) < 0)
		throw new std::runtime_error("Error in sendto!\n");
}
