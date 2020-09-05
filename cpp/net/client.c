#include <sys/socket.h>
#include <sys/types.h>
#include <stdio.h>
#include <netinet/ip.h>
#include <memory.h>
#include <unistd.h>
#include <string.h>
#include <stdlib.h>
#include <netdb.h>
#include <netinet/in.h>


#define PORT 7000

int main(void)
{
	struct sockaddr_in serverAdress;
	size_t connectSocket = 0, messageLength = 0, i = 0, len;
	int yes = 1;

	char* IP = "192.168.1.32";
	char message[1024];
	char hello[] = "Hello!\n\0";
	memset(message, '\0', 1024);
	if ( (connectSocket = socket(AF_INET, SOCK_STREAM, 0)) == -1 )
	{
		printf("We fucked up in the socket!\0");
		return -1;
	}

	serverAdress.sin_family = AF_INET;
	serverAdress.sin_port = htons(PORT);
	serverAdress.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
	memset(&(serverAdress.sin_zero), 0, 8);

	if ( (i = connect(connectSocket, (struct sockaddr*)&serverAdress, sizeof(struct sockaddr))) == -1)
	{
		printf("We fucked up in connection!\0");
		return -1;
	}
	
	messageLength = recv(connectSocket, message, 1024, 0);
	printf("SERVER: ");
	for ( i = 0 ; i < messageLength ; ++i )
		putchar(message[i]);

	while (1)
	{
		scanf("%s", message);
		len = strlen(message);
		message[len] = '\n';
		message[len + 1] = '\0';
		len+=2;
		send(connectSocket, message, len, 0);
		messageLength = recv(connectSocket, message, 1024, 0);
		printf("SERVER: ");
		for (i = 0 ; i < messageLength ; ++i)
			putchar(message[i]);

	}

	close(connectSocket);
}

