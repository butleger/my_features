#ifndef SERVER_TCP_SOCKET_H
#define SERVER_TCP_SOCKET_H

#include "base_tcp_socket.h"

class ServerTCPSocket: 
	public BaseTCPSocket
{
protected:
	int clientSocket = -1;
public:
	
	ServerTCPSocket(string addr, size_t port, size_t bufferSize=1024);
	void runSocket(size_t que_size = 2);
	string recv(int flags = NULL) override;
	void send(string msg, int flags) override;
};

#endif // SERVER_TCP_SOCKET_H
