#include "client_tcp_socket.h"
#include <iostream>

int main()
{
	using namespace std;
	constexpr size_t PORT = 7777;
	try
	{
		ClientTCPSocket client_sock("127.0.0.1", PORT);	
		client_sock.send(string("Hello there!"));
	}
	catch(exception e)
	{
		cout << e.what(); 
	}
	return 0;
}
