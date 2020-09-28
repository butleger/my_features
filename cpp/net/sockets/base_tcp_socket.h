#ifndef BASE_TCP_SOCKET_H
#define BASE_TCP_SOCKET_H

#include <string>

#include <iostream>
#include <stdio.h>
#include <unistd.h>
#include "base_socket.h"
#include <sys/socket.h>


class BaseTCPSocket :
	public BaseSocket
{
public:
	BaseTCPSocket(string addr,
		      size_t port,
		      size_t bufferSize = 1024);
	virtual void send(string msg, int flags = NULL);
	virtual string recv(int flags = NULL);
};

#endif // BASE_TCP_SOCKET_H
