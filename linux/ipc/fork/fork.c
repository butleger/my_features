#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>


void do_parent_work(int child_pid)
{
	int pid;
	pid_t waited_pid;
	int status;

	pid = getpid();
	printf("[PARENT] pid = %d, child pid = %d\n", pid, child_pid);
	printf("[PARENT] start waiting child!\n");
	waited_pid = wait(&status);
	printf("[PARENT] child process with pid %d return %d\n",
		       	waited_pid,
			status);
}


void do_child_work()
{
	int ppid, pid;
	
	pid  = getpid();
	ppid = getppid();
	printf("[CHILD] pid = %d, parent pid = %d\n", pid, ppid);
}


int main(int c, char **v, char **env)
{
	int pid;

	pid = fork();
	if (pid != 0)
	{
		do_parent_work(pid);
	}
	else 
	{
		do_child_work();
	}
	return 0;
}
