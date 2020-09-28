#ifndef BASE_SOCKET_H
#define BASE_SOCKET_H

#include <string>
#include <exception>
#include <sys/socket.h>
#include <netinet/ip.h>
#include <arpa/inet.h>
#include <unistd.h> 
#include <stdexcept>

using std::string; 

class BaseSocket
{
protected:

	int _socket;
	size_t bufferSize;
	struct sockaddr_in addr;
	size_t port;
public:

	BaseSocket(string addr, size_t port, size_t bufferSize = 1024, int SOCK_TYPE = SOCK_STREAM);
	~BaseSocket();
};

#endif // BASE_SOCKET_H
