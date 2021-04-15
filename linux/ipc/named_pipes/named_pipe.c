#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <string.h>


#define BUF_SIZE 128
#define false 0
#define true 1
typedef int bool;


void usage(char *path)
{
	printf("Usage: %s [read|write] PIPENAME \n", path);
	exit(-1);
}


void fatal(char *msg)
{
	printf("%s\n", msg);
	exit(-1);
}


int get_pipe(char *pipepath, int flags)
{

	int pipe_fd;
	pipe_fd	= open(pipepath, flags);
	if (pipe_fd < 0)
	{
		fatal("Cant open pipe!");
	}
	else 
	{
		return pipe_fd;
	}
}


bool pipe_exist(char *path)
{
	bool result;
	int fd = open(path, O_RDONLY);
	if (fd < 0)
		result = false;
	else 
		result = true;
	close(fd);
	return result;

}


void create_pipe(char *pipepath)
{
	unlink(pipepath);
	if ( mkfifo(pipepath, 0777) < 0 )
		fatal("Cant mkfifo!");
}


int main(int c, char **v, char **env)
{
	char *pipepath;
	char *command;
	int pipe_fd;
	char buf[BUF_SIZE];

	if (c < 3)
	{
		usage(v[0]);
	}
	pipepath = v[2];
	command  = v[1];

	if ( strncmp(command, "read", 4) == 0 )
	{

		create_pipe(pipepath);
		pipe_fd = open(pipepath, O_RDONLY);
		while (read(pipe_fd, buf, 1))
		{
			write(STDOUT_FILENO, buf, 1);
		}
	}
	else if ( strncmp(command, "write", 5) == 0)
	{
		pipe_fd = open(pipepath, O_WRONLY);
		scanf("%s", buf);
		dprintf(pipe_fd, "%s", buf);
	}
	else 
	{
		usage(v[0]);
	}
	return 0;
}
