#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sched.h>
#include <sys/types.h>
#include <wait.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <string.h>


void print_shit_and_pid(int fd, int pid)
{
	char shit[30];
	sprintf(shit, "Shit!(also pid = %d)\n", pid); 
	write(fd, shit, strlen(shit));
}

int main(int c, char **val)
{
	int pid;
	int log;
	char buff[] = "File was open and i write into it!\n";
	if (c < 2)
	{
		printf("Specify status file!\n");
		exit(-1);
	}
	if (log < 0)
	{
		printf("%s: Cant find or open or even fucking creat file!\n", val[1]);
		exit(-1);
	}
	pid = fork();
	if (pid < 0)
	{
		printf("Syscall 'fork' return error with number: %d!\n", pid);
		exit(-1);
	}
	else if (pid == 0)
	{
		umask(0);
		setsid();
		//chdir("/");
		log = open(val[1], O_WRONLY|O_CREAT);
		if (log < 0)
		{
			exit(-1);
		}
		close(STDIN_FILENO);
		close(STDIN_FILENO);
		close(STDIN_FILENO);
		print_shit_and_pid(log, pid);
		close(log);
		return 0;
	}
	else 
	{
		printf("Main process has ended!\n");
		return 0;
	}
}

