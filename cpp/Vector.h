#pragma once
#ifndef  VECTOR_H_
#define VECTOR_H_
#include <iostream>
#include "Constants.h"
#include "Algorithm.h"

namespace My
{

	template <typename DataType,typename Allocator = std::allocator<DataType> >
	class Vector
	{
	private:

		Allocator allocator;
		size_t capacity;//how many memory we allocate
		size_t size;
		DataType* DataArray;

		void ConstructVectorAndSetValue(const DataType& toCopy);//construct objects in DataArray with copyCtor
		void ReallocateAndSetCapacity(size_t newCapacity);//and deallocate old array
		void DestroyAll();
		void DestroyAllAndDeallocate();

	public :

		Vector();
		Vector(size_t startCapacity);
		Vector(size_t startSize,const DataType& initionValue);
		Vector(const Vector<DataType, Allocator>& VectorForCopy);
		Vector(Vector<DataType, Allocator>&& VectorForMoving);
		virtual ~Vector();

		void PushBack(DataType Data);
		void Insert(size_t index, DataType Data);
		void DeleteByIndex(size_t index);
		void Resize(size_t newSize);
		void ResizeAndInitializeNew(size_t newSize, DataType initializeValue);
		void Reserve(size_t newCapacity);

				   const int& operator[](int index) const;
				   	   	 int  operator[](int index);
  Vector<DataType, Allocator> operator=( const Vector<DataType, Allocator>&  VectorForCopyEquality);
  Vector<DataType, Allocator> operator=(       Vector<DataType, Allocator>&& VectorForMoveEquality);

	template<typename DataType, typename Allocator>//sum common indexes and return resulting vector
	friend Vector<DataType, Allocator> operator+(const Vector<DataType, Allocator>& LeftVector, const Vector<DataType, Allocator>& RightVector);
	
	template<typename DataType, typename Allocator>//scalar multy
	friend int operator*(const Vector<DataType, Allocator>& LeftVector, const Vector<DataType, Allocator>& RightVector);
	
	template<typename DataType, typename Allocator>//multy vector on scalar
	friend Vector<DataType, Allocator> operator*(const Vector<DataType, Allocator>& vector, const DataType& scalar);

	template<typename DataType, typename Allocator>//multy vector on scalar
	friend Vector<DataType, Allocator> operator*(const DataType& scalar, const Vector<DataType, Allocator>& vector);

	template<typename DataType, typename Allocator>//pushback new elements
	friend std::ostream& operator<<(std::ostream& out, const Vector<DataType, Allocator>& ReadableVector);
	
	template<typename DataType, typename Allocator>
	friend std::istream& operator>>(std::istream& input, Vector<DataType, Allocator>& DestinationVector);

	
	};

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::ConstructVectorAndSetValue(const DataType& toCopy)//construct all in raw DataArray
	{
		for (size_t index = 0; index < size; ++index)
		{
			allocator.construct(DataArray + index, toCopy);
		}
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::ReallocateAndSetCapacity(size_t newCapacity)//and deallocate old array
	{
		DataType* tempArray = allocator.allocate(newCapacity);
		My::memmove(tempArray, DataArray, capacity * sizeof(DataType));
		
		allocator.deallocate(DataArray, capacity);
		
		DataArray = tempArray;
		capacity = newCapacity;
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::DestroyAll()
	{
		for (size_t index = 0; index < size; ++index)
			allocator.destroy(DataArray + index);
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::DestroyAllAndDeallocate()
	{
		DestroyAll();
		allocator.deallocate(DataArray, capacity);
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::Vector() :
		allocator(Allocator()),
		capacity(START_CAPACITY),
		size(NO_SIZE),
		DataArray( allocator.allocate(capacity) )
	{}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::Vector(size_t startCapacity) :
		allocator(Allocator()),
		capacity(startCapacity),
		size(NO_SIZE),
		DataArray(allocator.allocate(capacity))
	{}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::Vector(size_t startSize,const DataType& initionValue) :
		allocator(Allocator()),
		capacity(startSize*CAPACITY_STEP),
		size(startSize),
		DataArray(allocator.allocate(capacity))
	{
		ConstructVectorAndSetValue(initionValue);
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::Vector(const Vector<DataType, Allocator>& VectorForCopy) :
		allocator(VectorForCopy.allocator),
		capacity(VectorForCopy.capacity),
		size(VectorForCopy.size),
		DataArray(allocator.allocate(capacity))
	{
		for (int index = 0; index < size; ++index)
		{
			allocator.construct(DataArray + index, VectorForCopy[index]);
		}
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::Vector(Vector<DataType, Allocator>&& VectorForMoving) :
		allocator(std::move(VectorForMoving.allocator)),
		capacity(std::move(VectorForMoving.capacity)),
		size(std::move(VectorForMoving.size)),
		DataArray(std::move(VectorForMoving.DataArray))
	{
		VectorForMoving.size = 0;
		VectorForMoving.capacity = 0;
		VectorForMoving.DataArray = 0;
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator>::~Vector()
	{
		DestroyAllAndDeallocate();
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::PushBack(DataType Data)
	{
		if (capacity > size)
		{
			allocator.construct(DataArray + size, std::move(Data));
			++size;
		}
		else
		{
			ReallocateAndSetCapacity(CAPACITY_STEP * capacity);
			allocator.construct(DataArray + size,std::move(Data));
			++size;
		}
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::Insert(size_t index, DataType Data)
	{
		if (capacity > size)
		{
			My::memmove(DataArray + index, DataArray + index + 1,sizeof(DataType) * (size - index));
			allocator.construct(DataArray + index, std::move(Data));
			++size;
		}
		else
		{
			capacity *= CAPACITY_STEP;
			DataType* tempArray = allocator.allocate(capacity);
			My::memmove(tempArray, DataArray, sizeof(DataType) * index);

			allocator.construct(tempArray + index, std::move(Data));
			My::memmove( tempArray + index + 1, DataArray + index, sizeof(DataType)(size - index));
			allocator.deallocate(DataArray, capacity);
			
			DataArray = tempArray;
			++size;
		}
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::DeleteByIndex(size_t index)
	{
		if (index >= size)return;
		allocator.destroy(DataArray + index);
		My::memmove(DataArray + index, DataArray + index + 1, sizeof(DataType)*(size - index));
		--size;
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::Resize(size_t newSize)
	{
		if (newSize <= capacity)
		{
			if (size < newSize)
			{
				size = newSize;
			}
			else
			{
				for (int index = newSize - 1; index < size; ++index)
				{
					allocator.destroy(DataArray + index);
				}
				size = newSize;
			}
		}
		else
		{
			ReallocateAndSetCapacity(newSize * CAPACITY_STEP);
			size = newSize;
		}
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::ResizeAndInitializeNew(size_t newSize, DataType initializeValue)
	{
		if (newSize <= capacity)
		{
			if (size < newSize)
			{
				size = newSize;
			}
			else
			{
				for (size_t index = newSize - 1; index < size; ++index)
				{
					allocator.destroy(DataArray + index);
				}
				size = newSize;
			}
		}
		else
		{
			DataType* tempArray = allocator.allocate(newSize * CAPACITY_STEP);
			My::memmove(tempArray, DataArray, sizeof(DataType) * size);

			DestroyAllAndDeallocate();

			DataArray = tempArray;

			for (size_t index = size; index < newSize; ++index)
			{
				allocator.construct(DataArray + index, initializeValue);
			}

			size = newSize;
			capacity = newSize * CAPACITY_STEP;
		}
	}

	template<typename DataType, typename Allocator>
	void Vector<DataType, Allocator>::Reserve(size_t newCapacity)
	{
		if (newCapacity < capacity)
		{
			Resize(newCapacity);
		}
		else
		{
			ReallocateAndSetCapacity(newCapacity);
		}
	}

	template<typename DataType, typename Allocator>
	const int& Vector<DataType, Allocator>::operator[](int index) const
	{
		return DataArray[index];// in ISO i can do this, cause bad index in vector - UB  
	}

	template<typename DataType, typename Allocator>
	int Vector<DataType, Allocator>::operator[](int index)
	{
		return DataArray[index];
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator> Vector<DataType, Allocator>::operator=(const Vector<DataType, Allocator>& VectorForCopyEquality)
	{
		DestroyAllAndDeallocate();

		DataArray = allocator.allocate(VectorForCopyEquality.capacity);
		size      = VectorForCopyEquality.size;
		allocator = VectorForCopyEquality.allocator;
		capacity  = VectorForCopyEquality.capacity;

		for (size_t index = 0; index < size; ++index)
		{
			allocator.construct(DataArray + index, VectorForCopyEquality[index]);
		}

		return *this;
	}

	template<typename DataType, typename Allocator>
	Vector<DataType, Allocator> Vector<DataType, Allocator>::operator=(Vector<DataType, Allocator>&& VectorForMoveEquality)
	{
		DestroyAllAndDeallocate();

		DataArray = std::move(VectorForMoveEquality.DataArray);
		size      = std::move(VectorForMoveEquality.size);
		allocator = std::move(VectorForMoveEquality.allocator);
		capacity  = std::move(VectorForMoveEquality.capacity);

		return *this;
	}

	template<typename DataType, typename Allocator>//sum common indexes and return resulting vector
	Vector<DataType, Allocator> operator+(const Vector<DataType, Allocator>& LeftVector, const Vector<DataType, Allocator>& RightVector)
	{
		Vector<DataType> result(MAX(LeftVector.size, RightVector.size));

		if (RightVector.size > LeftVector.size)
		{

			for (size_t index = 0; index < LeftVector.size; ++index)
			{
				result.PushBack(RightVector[index] + LeftVector[index]);
			}

			for (size_t index = LeftVector.size; index < RightVector.size; ++index)
			{
				result.PushBack(RightVector[index]);
			}
		} 
		else
		{

			for (size_t index = 0; index < RightVector.size; ++index)
			{
				result.PushBack(RightVector[index] + LeftVector[index]);
			}

			for (size_t index = RightVector.size; index < LeftVector.size; ++index)
			{
				result.PushBack(LeftVector[index]);
			}
		}

		return result;
	}

	template<typename DataType, typename Allocator>
	int operator*(const Vector<DataType, Allocator>& LeftVector, const Vector<DataType, Allocator>& RightVector)
	{
		size_t Size = MIN(LeftVector.size, RightVector.size);
		int result = 0;

		for (size_t index; index < Size; ++index)
		{
			result += LeftVector[index] * RightVector[index];
		}

		return result;
	}

	template<typename DataType, typename Allocator>//multy vector on scalar
	Vector<DataType, Allocator> operator*(const Vector<DataType, Allocator>& vector, const DataType& scalar)
	{
		Vector<DataType, Allocator> result(vector);
		for (size_t index; index < result.size; ++index)
			result[index] *= scalar;

		return result;
	}

	template<typename DataType, typename Allocator>//multy vector on scalar
	Vector<DataType, Allocator> operator*(const DataType& scalar, const Vector<DataType, Allocator>& vector)
	{
		return vector*scalar;
	}

	template<typename DataType, typename Allocator>
	std::ostream& operator<<(std::ostream& out, const Vector<DataType, Allocator>& ReadableVector)
	{
		for (size_t index = 0; index < ReadableVector.size; ++index)
			out << ReadableVector[index] << " ";

		return out;
	}

	template<typename DataType, typename Allocator>
	std::istream& operator>>(std::istream& input, Vector<DataType, Allocator>& DestinationVector)
	{
		DataType temp;
		input >> temp;
		DestinationVector.PushBack(temp);
		return input;
	}

}//namespace My

#endif // ! VECTOR_H_
