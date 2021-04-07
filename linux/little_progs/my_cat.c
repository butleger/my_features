#include <unistd.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>


void printFilesByNames(const char **filenames, int qtty)
{
	int i = 0;
	for (i = 0; i < qtty; ++i)
	{
		printFileByName(filenames[i]);
		printf("\n");
	}
}

void printFileByName(char *filename)
{
	int fd;	
	if (strcmp(filename, "-") == 0 || strcmp(filename, "--") == 0)
		fd = 1;
	else
		fd = open(filename, O_RDONLY);
	if (fd < 0)
		no_file(filename);

	printFile(fd);
}

void printFile(int fd)
{
	char buf;
	while (read(fd, &buf, 1))
		write(1, &buf, 1);	
}

void no_file(const char *filename)
{
	printf("%s: no such file!\n", filename);
	exit(-1);
}

void bad_exit(const char *msg)
{
	printf("%s\n", msg);
	exit(-1);
}

void readAndPrint()
{
	printFile(2);
}



int main(int c, char **val)
{
	if (c == 1)
	{
		readAndPrint();
	}
	else if (c == 2)
	{
		printFileByName(val[1]);
	}
	else if (c > 2)
	{
		printFilesByNames(val + 1, c - 1);
	}
	return 0;
}
