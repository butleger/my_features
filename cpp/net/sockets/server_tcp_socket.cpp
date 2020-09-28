#include "server_tcp_socket.h"


ServerTCPSocket::ServerTCPSocket(string addr,
				 size_t port,
				 size_t bufferSize ) : BaseTCPSocket(addr, port, bufferSize)
{
	bind(this->_socket, (struct sockaddr*)&(this->addr), sizeof(this->addr));	
}
	
void ServerTCPSocket::runSocket(size_t que_size)
{	
	struct sockaddr_in clientAddr;
	socklen_t addrSize;
	if (listen(this->_socket, que_size) < 0)
		throw new std::runtime_error("Cant this listen port!\n");
	clientSocket = accept(this->_socket, (struct sockaddr*)&clientAddr, &addrSize);
}

string ServerTCPSocket::recv(int flags)
{
	if ( clientSocket == -1)
	{
		throw new std::runtime_error("Dont accept some connections!");
	}
	char buffer[1024];
	if (::recv(clientSocket, buffer, bufferSize, flags) < 0)
		throw new std::runtime_error("Error in recv");
	return string(buffer);
}

void ServerTCPSocket::send(string msg, int flags) 
{
	msg[msg.size()] = '\0';
	if (::send(clientSocket, msg.c_str(), msg.size(), flags) < 0)
		throw std::runtime_error("Error in send!\n");
}
