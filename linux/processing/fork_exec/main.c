#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>


void childFunc()
{
	printf("This is ChildFunc!\n");
	printf("Trying to make exec()!\n");
	execl("./sub_process", NULL);	
}

void parentFunc(int childPid)
{
	printf("This is parentFunc!(pid = %d)\n", childPid);
	printf("Start wait function!\n");
	int ret = waitpid(childPid);
	printf("Child Process has ended with ret value = %d\n", ret);
	exit(0);
}

int main()
{
	printf("Programm main start its life!\n");
	int pid = fork();
	if (pid == 0)
	{
		childFunc();
	}
	else 
	{
		parentFunc(pid);
	}
	return 0;
}
