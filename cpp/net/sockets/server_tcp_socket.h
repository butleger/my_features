#ifndef SERVER_TCP_SOCKET_H
#define SERVER_TCP_SOCKET_H

#include "base_tcp_socket.h"

class ServerTCPSocket: 
	public BaseTCPSocket
{
private:
	int clientSocket = -1;
public:
	ServerTCPSocket(string addr, size_t port):
		BaseSocket(addr, port)
	{
		bind(this->_socket, (struct sockaddr*)&(this->addr), sizeof(this->addr));	
	}
	
	void runSocket(size_t que_size)
	{
		listen(this->_socket, que_size);
		clientSocket = accept(this->_socket, NULL, NULL);
	}

	string recv() override
	{
		if ( clientSocket == -1)
		{
			throw new std::invalid_argument("Dont accept some connections!");
		}
		char buffer[1024];
		read(clientSocket, buffer, 1024);
		return string(buffer);
	}

	void send(string msg) override
	{
		msg[msg.size()] = '\0';
		write(clientSocket, msg.c_str(), msg.size());
	}


};

#endif // SERVER_TCP_SOCKET_H
