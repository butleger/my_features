#pragma once

#ifndef ALGORITHM_H
#define ALGORITHM_H

#include "Constants.h"


namespace My
{
	using namespace My;

	void memmove(void* destination, void* resource, size_t byteSize)
	{
		DWORD* _destination = (DWORD*)destination;
		DWORD* _resource    = (DWORD*)resource;//cast all to DWORD
		size_t size = byteSize / sizeof(DWORD);//how many DWORDS in byteSize

		for (size_t i = 0; i < size; ++i)//at start copy all in big portions
			*(_destination++) = *(_resource++);

		BYTE* __destination = (BYTE*)_destination;//cast rest data to BYTE
		BYTE* __resource	= (BYTE*)_resource;
		size = byteSize % sizeof(WORD);//how many BYTEs should be copyed

		for (size_t i = 0; i < size; ++i)//copy remain data in small portions
			*(__destination++) = *(__resource++);
	}

	template <typename Type>
	void swap(Type first, Type second)
	{
		Type temp = std::move(first);
		first	  = std::move(second);
		second	  = std::move(temp);
	}

}//namespace My
#endif // !_ALGORITHM_H_
