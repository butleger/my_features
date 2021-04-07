#include "../headers/socket_work.h"


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
		fatal_worker("Error in async_connection_worker!", client_sock);
	return;
}

void connection_worker(int client_sock, struct sockaddr_in client_addr)
{
	char headers[2048];
	char request[2048];
	char filename[50];
	memset(headers, 0, 2048);
	memset(request, 0, 2048);
	
	recv(client_sock, request, 2048, (int)NULL);
	printf("%s\n", request);
	make_headers(headers, request);

	sprintf(filename, "%s/", DIR_ROOT); // making /%BASE_ROOT%/%FILE_FROM_REQUEST%
	get_response_filename(request, filename + strlen(DIR_ROOT) + 1);
	
	send(client_sock, headers, strlen(headers), (int)NULL);
	send_file(client_sock, filename);
	close_connection(client_sock);
	return;
}

void send_file(int sock, const char *filename)
{
	int fd = open(filename, O_RDONLY);
	char temp[1];

	if (fd < 0)
	{
		printf("%s\n", filename);
		fatal_worker("Cant open file!\n", sock);
	}
	while(read(fd, temp, 1))
		send(sock, temp, 1, (int)NULL);
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

void fatal_worker(const char *msg, int sock)
{
	close_connection(sock);
	printf("%s\n", msg);
	exit(-1);
}

void close_connection(int sock)
{
	shutdown(sock, SHUT_RDWR);
	close(sock);
}

