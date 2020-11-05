#ifndef HTTP_WORK_H
#define HTTP_WORK_H

#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/stat.h>
#include "config_def.h"
#include <sys/types.h>
#include <string.h>
#include <dirent.h>


#define _200_RESPONSE_HEADER "HTTP/1.1 200 NOT OK\r\n" \
		 			  		 "Server: shitty_server\r\n\r\n"

#define _404_RESPONSE_HEADER "HTTP/1.1 404 NOT FOUND\r\n" \
		 			  		 "Server: shitty_server\r\n\r\n"
extern int server_sock;

bool_t is_correct_request(const char *request);
bool_t is_normal_request_size(const char *request);
bool_t is_get_request(const char *request);
bool_t is_file_exist(const char *request);
int get_size_of_file(const char *filename);
char *get_response_filename_unsafe(const char *request, char *out);
char *get_response_filename(const char *request, char *out);
char *make_headers(char *out, const char *request);
char *make_404_headers(char *out);
char *make_200_headers(const char *request, char *out);

#endif // HTTP_WORK_H