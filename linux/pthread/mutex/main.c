#include <pthread.h>
#include <stdio.h>


#define NUM_OF_THREADS 10
pthread_t 	g_threads[NUM_OF_THREADS];
pthread_attr_t 	g_threads_attr[NUM_OF_THREADS];
pthread_mutex_t g_mutex;
int 		g_thread_id[NUM_OF_THREADS]; /* need for good thread capture */



void init_threads();
void init_threads_id();
void init_attrs();
void init_mutex();
void *thread_routine(void *thread_id_ptr);
void enter_critical_section(int thread_id);
void critical_section(int thread_id);
void leave_critical_section(int thread_id);
void spend_free_time(int thread_id);
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
	init_mutex();
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


void init_mutex()
{
	pthread_mutex_init(&g_mutex, NULL);
}


void *thread_routine(void *_thread_id)
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
	while ( !pthread_mutex_trylock(&g_mutex) )
	{
		spend_free_time(thread_id);
	}
	critical_section(thread_id);
}


void critical_section(int thread_id)
{
	int max_cycles = 10000000;
	printf("[%d] Entered CRITICAL REGION\n", thread_id);
	for (size_t i = 0; i < max_cycles; ++i)
	{
		/* just spendind time  */
		++i;
		--i;
	}
}


void leave_critical_section(int thread_id)
{
	pthread_mutex_unlock(&g_mutex);
}


void spend_free_time(int thread_id)
{
	/* just call scheduler, but can do something good */
	pthread_yield();
}


void cleanup_threads()
{
	for (size_t i = 0; i < NUM_OF_THREADS; ++i)
	{
		int result = pthread_join(g_threads[i], NULL);
		printf("[MAIN] %ld ended and return %d\n", i, result);
	}
}
