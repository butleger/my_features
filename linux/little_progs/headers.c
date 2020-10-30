#include <stdio.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <netdb.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <string.h>
#include <unistd.h>

#define HTTP_PORT 80

void bad_exit(const char *msg)
{
	printf("%s\n", msg);
	exit(-1);
	return;
}

void print_domain_info(struct hostent *host)
{
	int i = -1;
	printf("Name of machine: \"%s\"\n", host->h_name);
	if (host->h_aliases[0]) // if domain have aliases print them else no
		printf("Aliases :\n");
	while(host->h_aliases[++i]) // wouldn print if there is no aliases
		printf("\t%s\n", host->h_aliases[i]);
	i = -1;
	printf("Adresses :\n"); // at least one address should be
	while (host->h_addr_list[++i])
		printf("\t%s\n", inet_ntoa(*(struct in_addr*)host->h_addr_list[i]));
	return;
}

void print_headers(const char *_web_page)
{
	int i = 0;
	while (_web_page[i] != '\r' || _web_page[i + 1] != '\n' || _web_page[i + 2] != '\r' || _web_page[i + 3] != '\n')
	{
		write(1, _web_page + i, 1);
		i++;
	}
	printf("\n");
	return;
}

char web_page[1000000];

char * get_text_of_site(const char * addr, const char *hostname)
{
	char GET_message[100];
	struct sockaddr_in target_addr;
	int sock, web_page_size;
	
	sprintf(GET_message, "GET / HTTP/1.1\r\nHost: %s\r\n\r\n\0", hostname);

	if ((sock = socket(AF_INET, SOCK_STREAM, NULL)) < 0)
		bad_exit("Cant make socket!");
	
	target_addr.sin_family = AF_INET;
	target_addr.sin_port = htons(HTTP_PORT);
	inet_aton(addr, (struct in_addr*)&target_addr.sin_addr);
	
	if (connect(sock, (struct sockaddr*)&target_addr, sizeof(target_addr)))
		bad_exit("Cant connect to thins addres!");
	
	send(sock, GET_message, strlen(GET_message), NULL);
	web_page_size = recv(sock, web_page, 1000000, NULL);
	web_page[web_page_size] = '\0';
	return web_page;
}

int main(int c, char **v)
{
	struct hostent *target_host;

	if (c < 2)
		bad_exit("Specify the address!");
	if (!(target_host = gethostbyname(v[1])))
		bad_exit("Cant resolve your domain!");
	print_domain_info(target_host);
	printf("\n\nHEADERS:\n");
	print_headers( get_text_of_site( inet_ntoa(*(struct in_addr*)target_host->h_addr_list[0]), target_host->h_name ));	
	return 0;
}
