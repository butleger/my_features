#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sched.h>
#include <sys/types.h>
#include <wait.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <string.h>


void doMainProcShit(int child_pid)
{
	printf("This is Main Process, sub process have pid = %d!\n", child_pid);
	printf("Start waiting!\n");
	printf("Get resulting: %d", waitpid(child_pid, NULL, NULL));
	exit(0);
}

void doSubProcShit()
{
	int shit;
	printf("This is sub proccess!\n");
	printf("Start sleeping!\n");
	scanf("%d", &shit);
	exit(0);
}

int main(int c, char **val)
{
	int pid;
	int log = open(val[1], O_CREAT|O_WRONLY);
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
	}
	write(log, buff, strlen(buff));
	close(log);
	return 0;
}

