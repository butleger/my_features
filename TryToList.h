#pragma once
#include <iostream>
#include "Constants.h"
#include "TypeConvertions.h"
namespace Test
{
	template <typename DataType, typename Allocator = std::allocator<DataType>>
	class List 
	{
	private:
		struct Node
		{
			Node* next;
			DataType Data;
			Node(DataType Data,Node* next = nullptr);
		};

		typename Allocator::template rebind<Node>::other allocator;
		Node* head;
		int size;

	public :
		List();
		~List();

		void PushFront(DataType Data);
		const size_t getSize() const;
		//void Insert(DataType Data, size_t index);
		//void DeleteByIndex(size_t index);

		template <typename DataType, typename Allocator = std::allocator<DataType>>
		friend std::ostream& operator<<(std::ostream& out,const Test::List<DataType, Allocator>& list);
	};

	template<typename DataType, typename Allocator = std::allocator<DataType>>
	std::ostream& operator<<(std::ostream& out, const Test::List<DataType, Allocator>& list)
	{
		typename My::RemoveReference<decltype(list)>::_Type::Node* current = list.head;
		for (size_t i = 0; i < list.size; ++i)
		{
			out << current->Data << " ";
			current = current->next;
		}
		return out;
	}
	template<typename DataType, typename Allocator>
	inline List<DataType, Allocator>::Node::Node(DataType Data,Node* next) :
		Data(Data),
		next(next)
	{}

	template <typename DataType, typename Allocator>
	Test::List<DataType, Allocator>::List() :
		allocator(typename Allocator::template rebind<Node*>::other()),
		head(nullptr),
		size(NO_SIZE)
	{}

	template <typename DataType, typename Allocator>
	Test::List<DataType, Allocator>::~List()
	{
		Node* help = head;
		for (size_t i = 0; i < size; ++i)
		{
			help = help->next;
			allocator.destroy(head);
			allocator.deallocate(head, 1);
			head = help;
		}
	}

	template <typename DataType, typename Allocator>
	void Test::List<DataType, Allocator>::PushFront(DataType Data)
	{
		Node* newHead = allocator.allocate(1);
		allocator.construct(newHead, Data, head);
		head = newHead;
		++size;
	}

	template<typename DataType, typename Allocator>
	const size_t List<DataType, Allocator>::getSize() const
	{
		return size;
	}

	/*template <typename DataType, typename Allocator>
	void Test::List<DataType, Allocator>::Insert(DataType Data, size_t index);

	template <typename DataType, typename Allocator>
	void Test::List<DataType, Allocator>::DeleteByIndex(size_t index);*/
}