#include <stdio.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/ip.h>
#include <memory.h>
#include <stdlib.h>
#include <string.h>
#include <netinet/in.h>
#include <netdb.h>
#include <unistd.h>
#include <arpa/inet.h>


#define PORT 7000

int main(int argc, char** argv)
{
	size_t masterSocket, slaveSocket, sinSize, messageLength, i;
	struct sockaddr_in myAdress, clientAdress;
	int yes = 1;
       	
	char* IP = "192.168.1.32";
	char message[1024];
	char* helloMessage = "You soccesfully connected to server!\n\0";


	if ( (masterSocket = socket(AF_INET, SOCK_STREAM, 0)) == -1 )
	{
		printf("We was crashed in socket!\0");
		return -1;
	}

	myAdress.sin_family = AF_INET;
	myAdress.sin_port = htons(PORT);
       	//inet_aton(IP, &myAdress.sin_addr);
	myAdress.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
	memset(&(myAdress.sin_zero), '\0', 8);
	
	//if ( setsockopt ( masterSocket, SOL_SOCKET, SO_REUSEADDR, &yes , sizeof(int) ) == -1 )
	//{
	//	printf("Something wrong in setsockopt!\0");
	//	return -1;
	//}

	if ( bind(masterSocket, (struct sockaddr *)&myAdress, sizeof(struct sockaddr)) == -1 )
	{
		printf("We fucked in bind!\0");
		return -1;
	}

	if ( listen(masterSocket, 2) == -1 )
	{
		printf("We fucked in listen!\0");
		return -1;
	}

 
	
	sinSize = sizeof(struct sockaddr);
		
	slaveSocket = accept(masterSocket, (struct sockaddr*)&slaveSocket, &sinSize);
		
	if (slaveSocket == -1)
	{
		printf("We fucked in accept!\0");
		return -1;
	}
	
	char* adress = inet_ntoa(clientAdress.sin_addr);

	printf("We get connections from %s on port %d\n\0", adress,
							ntohs(clientAdress.sin_port));
	
	send(slaveSocket, helloMessage, strlen(helloMessage), 0);
	while(1)
	{
		messageLength = recv(slaveSocket, &message, 1024, 0);
		if (messageLength == 1 && message[0] == '0')
		{
			printf("Here cycle should be ended!)\n");
			break;
		}
		printf("CLIENT: ");
		for ( i = 0 ; i < messageLength; ++i)
			putchar(message[i]);
		send(slaveSocket, message, messageLength, 0);
	}
	
	
	close(slaveSocket);

return 0;
}
