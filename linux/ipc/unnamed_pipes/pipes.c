#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <stdio.h>
#include <stdlib.h>


void fatal(const char *msg)
{
	printf("%s\n", msg);
	exit(-1);
}


void do_parent_work(int write_fd)
{
	int pid;
	int status;
	pid_t child_pid;

	pid = getpid();
	dprintf(write_fd, "Hello from %d!", pid);
	child_pid = wait(&status);
	printf("[PARENT] Child(pid = %d) return %d\n", child_pid, status);
}


void do_child_work(int read_fd)
{
	char buf[128];
	int bytes_read;
	
	bytes_read = read(read_fd, buf, 128);
	buf[bytes_read] = '\0';
	printf("[CHILD] recieve message \"%s\"", buf);
}


int main(int c, char **v, char **env)
{
	int pipes[2];
	int pid;
	
	if (pipe(pipes) < 0)
	{
		fatal("Cant do pipe()!");
	}
	
	pid = fork();
	if (pid < 0)
	{
		fatal("Cant do fork()!");
	}

	if (pid == 0)
	{
		do_child_work(pipes[0]);
	}
	else 
	{
		do_parent_work(pipes[1]);
	}
	
	return 0;
}

