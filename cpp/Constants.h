#pragma once

#ifndef CONSTANTS_H_
#define CONSTANTS_H_

namespace My 
{
	typedef unsigned int WORD;
	typedef unsigned long int DWORD;
	typedef unsigned char BYTE;

	#define NO_SIZE 0
	#define ONE_NODE 1
	
	#define HEAD_INDEX  0
	#define TAIL_INDEX (this->size - 1)

	#define CAPACITY_STEP 2
	#define START_CAPACITY 10

	#define NO_VERTEX 0
	#define NO_ROUTE 0
	#define NOT_MARKED false
	#define MARKED true
	#define INFINITY 0xffff
 
	#define MIN(a, b) (a) < (b) ? (a) : (b)
	#define MAX(a, b) (a) > (b) ? (a) : (b)
}//namespace My

#endif // !CONSTANTS_H_
