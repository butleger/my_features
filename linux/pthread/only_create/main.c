#include <pthread.h>
#include <stdio.h>


#define NUM_OF_THREADS 10
pthread_t 	g_threads[NUM_OF_THREADS];
pthread_attr_t 	g_threads_attr[NUM_OF_THREADS];
int 		g_thread_id[NUM_OF_THREADS]; /* need for good thread capture */


void init_threads();
void init_threads_id();
void init_attrs();
void *thread_routine(void *thread_id_ptr);
void cleanup_threads();


int main(int c, char **v, char **env)
{
	init_threads();
	cleanup_threads();	
	return 0;
}


void init_threads()
{
	init_threads_id();
	init_attrs();
	for (size_t i = 0; i < NUM_OF_THREADS; ++i)
	{
		pthread_create(
			g_threads + i,
			g_threads_attr + i,
			thread_routine,
			(void *)(g_thread_id + i)
		);
	}
}


void init_threads_id()
{
	for (size_t i = 0; i < NUM_OF_THREADS; ++i)
	{
		g_thread_id[i] = i;
	}
}


void init_attrs()
{
	for (size_t i = 0; i < NUM_OF_THREADS; ++i)
	{
		pthread_attr_init(g_threads_attr + i);
	}
}


void *thread_routine(void *thread_id)
{
	printf("[%d] Start doing routine!\n", *(int *)thread_id);
	pthread_exit(NULL);
}


void cleanup_threads()
{
	for (size_t i = 0; i < NUM_OF_THREADS; ++i)
	{
		int result = pthread_join(g_threads[i], NULL);
		printf("[MAIN] %ld ended and return %d\n", i, result);
	}
}
