#include "base_socket.h"

BaseSocket::BaseSocket(	string addr,
			size_t port,
			size_t bufferSize,
			int SOCK_TYPE)// SOCK_DGRAM SOCK_STREAM RAW_SOCK
{
	addr[addr.size()] = '\0';
	this->bufferSize = bufferSize;
	_socket = socket(AF_INET, SOCK_TYPE, NULL);
	
	if (_socket == -1)
		throw new std::runtime_error("Cant make socket!\n");

	inet_aton(addr.c_str(), &this->addr.sin_addr);
	this->addr.sin_family = AF_INET;

	if (port >= 65535 || port < 1)
		throw new std::invalid_argument("Bad port!");
	this->port = port;
}

BaseSocket::~BaseSocket()
{
	close(_socket);
}
