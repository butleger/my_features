#include <iostream>
#include "server_tcp_socket.h"
using namespace std;

int main()
{
	constexpr size_t PORT = 7777;
	::ServerTCPSocket serv("127.0.0.1", PORT);
	serv.runSocket(2);
	string msg(serv.recv());
	cout << msg << '\n';
}
