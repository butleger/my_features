#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>


#define THREADS_COUNT 10
pthread_t 	g_threads[THREADS_COUNT];
pthread_attr_t	g_threads_attr[THREADS_COUNT];
pthread_mutex_t	g_threads_mutex[THREADS_COUNT];

/* need for good captuting */
int		g_threads_id[THREADS_COUNT];


void init_threads();
void init_threads_id();
void init_threads_attr();
void init_threads_mutex();
void *thread_routine(void *thread_id_ptr);
void enter_critical_section(int thread_id);
void critical_section(int thread_id);
void leave_critical_section(int thread_id);
void spend_free_time(int thread_id);
void wait_all_threads();


int main(int c, char **v)
{
	return 0;
}


void init_threads()
{
	size_t i;

	init_threads_id();
	init_threads_attr();
	init_threads_mutex();
	
	for (i = 0; i < THREADS_COUNT; ++i)
	{
		pthread_create(
			g_threads + i,
			g_threads_attr + i,
			thread_routine, 
			(void *)(g_threads_id + i)
		);
	}
}

void init_threads_id()
{
	size_t i;

	for (i = 0; i < THREADS_COUNT; ++i)
	{
		g_threads_id[i] = i;
	}
}

void init_threads_attr()
{
	size_t i;

	for (i = 0; i < THREADS_COUNT; ++i)
	{
		pthread_init_attr(g_threads_attr + i);
	}
}

void init_threads_mutex()
{
	size_t i;

	for (i = 0; i < THREADS_COUNT; ++i)
	{
		pthread_mutex_init(g_threads_mutex + i, NULL);
	}
}

void *thread_routine(void *thread_id_ptr)
{
	int thread_id = *(int *)_thread_id;
	printf("[%d] Start doing routine!\n", thread_id);
	enter_critical_section( thread_id );
		critical_section( thread_id );
	leave_critical_section( thread_id );
	pthread_exit(NULL);
}

void enter_critical_section(int thread_id)
{

}


void critical_section(int thread_id);
void leave_critical_section(int thread_id);
void spend_free_time(int thread_id);
void wait_all_threads();