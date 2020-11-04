#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <sys/stat.h>
#include <string.h>
#include <signal.h>
#include <sched.h>
#include <wait.h>


#define DIR_ROOT "www"
#define PORT 3333
#define SERVER_ADDR "127.0.0.1"
#define true 1
int server_sock = -1;


void close_connection(int sock)
{
	shutdown(sock, SHUT_RDWR);
	close(sock);
}

int get_size_of_file(const char *filename)
{
	struct stat file_stat;
	if ( stat(filename, &file_stat) < 0 )
		return -1;
	else 
		return file_stat.st_size;
}

char *make_response(const char *request, char *out)
{
	return out;
}

void connection_worker(int client_sock, struct sockaddr_in client_addr)
{
	char msg[50];
	sprintf(msg, "Hello, %s!\n", inet_ntoa(client_addr.sin_addr));
	send(client_sock, msg, strlen(msg), NULL);
	close_connection(client_sock);
	return;
}

void async_connection_worker(int client_sock, struct sockaddr_in client_addr)
{
	void fatal_and_close(char *msg, int sock);
	pid_t new_pid = 0;
	
	if ((new_pid = fork()) > 0) // parent process
		return;
	else if (new_pid == 0) // child process
	{
		connection_worker(client_sock, client_addr);
		exit(0);
	}
	else // error
		fatal_and_close("Error in async_connection_worker!", client_sock);
	return;
}

void fatal(char *msg)
{
	if (server_sock != -1)
		close_connection(server_sock);
	printf("%s\n", msg);
	exit(-1);
}

void fatal_and_close(char *msg, int sock)
{
	close_connection(sock);
	fatal(msg);
}

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
	
	if ( setsockopt(server_sock, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(int)) )
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
