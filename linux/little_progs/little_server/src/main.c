#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <string.h>
#include <signal.h>
#include <wait.h>
#include "../headers/config_def.h"
#include "../headers/http_work.h"
#include "../headers/socket_work.h"


int server_sock = -1;

void sigint_handler(int signo)
{
	close_connection(server_sock);
	printf("Server closed!\n");
	exit(0);
}

void sigchld_handler(int signo)
{
	int status = 0;
	wait(&status);
	printf("Fork process ended with status %d!\n", status);
	return;
}

int main(int c, char **v)
{
	int client_sock, yes = 1;
	socklen_t addr_size;
	struct sockaddr_in server_addr;
	

	signal(SIGCHLD, sigchld_handler);
	signal(SIGINT, sigint_handler);
	server_sock = socket(AF_INET, SOCK_STREAM, NULL);
	
	if (server_sock < 0)
		fatal("Cant make socket!");
	
	server_addr.sin_family = AF_INET;
	server_addr.sin_port = htons(PORT);
	inet_aton(SERVER_ADDR, (struct in_addr*)&server_addr.sin_addr );
	
	if ( setsockopt(server_sock, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(int)) < 0 )
		fatal("Cant make server addr reusable!");

	if ( bind(server_sock, (struct sockaddr*)&server_addr, sizeof(server_addr)) < 0 )
		fatal("Cant bind server!");
	
	if ( listen(server_sock, 15) < 0 )
		fatal("Cant listen connections!");
	
	while(true)
	{
		struct sockaddr_in client_addr;
		memset(&client_addr, 0, sizeof(client_addr));
		if ( (client_sock = accept(server_sock, (struct sockaddr*)&client_addr, &addr_size)) < 0 )
			fatal("Cant accept connection!\n");	
		async_connection_worker(client_sock, client_addr);
		close(client_sock);
	}
	return 0;
}
