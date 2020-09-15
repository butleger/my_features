#ifndef MY_SOCKET_H
#define MY_SOCKET_H

#include <string>

#include <sys/types.h>
#include <sys/socket.h>
#include <stdio.h>
#include <sys/un.h>
#include <unistd.h>
#include <stdlib.h>

using namespace std;

class MySockets
{
private:
    int internalSocket;
    int hostPort;
    int destPort;
    struct sockaddr_in addres;
public:
    MySocket(std::string ip, size_t destPort, size_t hostPort = 0);
};

#endif // MY_SOCKET_H
