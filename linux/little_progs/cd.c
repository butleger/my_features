#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>

int main(int c, char **val)
{
	int status;
	if (c < 2)
	{
		printf("Specify path!\n");
		exit(-1);
	}
	if ((status = chdir(val[1])) < 0)
		printf("Find mistake with number %d!\n", status);
	printf("Directory of this program changed!\n");
}
