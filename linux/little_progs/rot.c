#include <stdlib.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <string.h>


#define STDIN 2

void good_exit(const char *msg)
{	
	msg_exit(msg, 0);
}

void bad_exit(const char *msg)
{
	msg_exit(msg, -1);
}

void msg_exit(const char *msg, int exit_code)
{
	printf("%s\n", msg);
	exit(exit_code);
}

// first args is file second is rotation(number)
int main(int c, int **val)
{
	char buf;
	int fd;


	if (c < 3)
		bad_exit("Specify file and rotation!");	
	
	if (strcmp(val[1], "-") != 0)
		fd = open(val[1], O_RDONLY);
	else 
		fd = STDIN;
	
	if (fd < 0)
	{
		printf("%s: cant open file!\n", val[1]);
		exit(-1);
	}
	
	while(read(fd, &buf, 1))
	{
		buf += atoi(val[2]); // atoi just convert key from string to number
		write(1, &buf, 1);
	}

	return 0;
}

