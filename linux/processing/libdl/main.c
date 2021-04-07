#include <stdbool.h>
#include <stdio.h>
#include <dlfcn.h>
#include <unistd.h>
#include <string.h>

void (*hello)(const char *);

bool init_library()
{
	void *hdl = dlopen("./libHello.so", RTLD_LAZY);
	if (hdl == NULL)
	{
		return false;
	}
	hello = (void (*)(const char *))dlsym(hdl, "hello");
	if (hello == NULL)
	{
		return false;
	}
	return true;	
}

int main()
{	
	if (init_library())
	{
		hello("Vasya");	
	}
	return 0;
}
