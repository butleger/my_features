#ifndef SOCKET_WORK_H
#define SOCKET_WORK_H

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <string.h>
#include <sched.h>
#include <wait.h>
#include <sys/stat.h>
#include <fcntl.h>
#include "config_def.h"
#include "http_work.h"


extern int server_sock;

void send_file(int sock, const char *filename);
void close_connection(int sock);
void connection_worker(int client_sock, struct sockaddr_in client_addr);
void async_connection_worker(int client_sock, struct sockaddr_in client_addr);
void fatal(char *msg);
void fatal_and_close(char *msg, int sock);
void fatal_worker(const char *msg, int sock);

#endif // SOCKET_WORK_H