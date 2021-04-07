#include <iostream>
#include "server_tcp_socket.h"
#include "server_udp_socket.h"
using namespace std;

int main()
{
	constexpr size_t PORT = 7777;
	::ServerUDPSocket serv("127.0.0.1", PORT);
	string msg(serv.recv());
	cout << msg << '\n';
}
