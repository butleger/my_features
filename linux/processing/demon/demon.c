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
	char shit[60];
	sprintf(shit, "Shit!(also pid = %d and session leader pid = %d)\n", pid, getsid(0)); 
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
	else if (pid == 0) // child process
	{
		umask(0);
		char *filename = val[1];
		int new_pid = setsid();
		log = open(filename, O_WRONLY | O_CREAT);
		printf("Childprocess can write into parent files!\n");
		if (log < 0)
		{
			exit(-1);
		}
		close(STDIN_FILENO);
		close(STDOUT_FILENO);
		close(STDERR_FILENO);
		print_shit_and_pid(log, new_pid);
		close(log);
		return 0;
	}
	else // parent process
	{
		sleep(3);
		wait(NULL);
		printf("Main process(pid = %d) has ended, child process pid = %d, session leader pid = %d!\n", getpid(), pid, getsid(0));
		return 0;
	}
}

