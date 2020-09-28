#include "client_tcp_socket.h"
#include <iostream>

int main()
{
	using namespace std;
	constexpr size_t PORT = 7777;
	ClientTCPSocket client_sock("127.0.0.1", PORT);
	client_sock.send(string("Hello there!"));
	return 0;
}
