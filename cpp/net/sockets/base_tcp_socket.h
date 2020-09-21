#ifndef BASE_TCP_SOCKET_H
#define BASE_TCP_SOCKET_H

#include <string>
#include <sys/socket.h>
#include <netinet/ip.h>
#include <arpa/inet.h>
#include <iostream>
#include <exception>
#include <stdio.h>
#include <unistd.h>

using std::string; 

class BaseTCPSocket
{
protected:
	int _socket;
	size_t port;
	struct sockaddr_in addr;
public:
	BaseTCPSocket(string addr, size_t port)
	{
		if (port > 65535 || port < 0)
		{
			throw new std::invalid_argument("Bad data for port!");
		}
		addr[addr.size()] = '\0';
		this->_socket = socket(AF_INET, SOCK_STREAM, NULL);
		inet_aton(addr.c_str(), &this->addr.sin_addr);
		this->addr.sin_family = AF_INET;
		this->addr.sin_port = htons(port);
		this->port = port;
	}

	virtual void send(string msg)
	{
		msg[msg.size()] = '\0';
		write(_socket, msg.c_str(), msg.size());
	}

	virtual string recv()
	{
		char buffer[1024];
		read(_socket, buffer, 1024);
		return string(buffer);
	}

	virtual ~BaseSocket()
	{
		close(_socket);
	}
};

#endif // BASE_SOCKET_H
