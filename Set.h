#pragma once
#ifndef SET_H
#define SET_H

#include "Function.h"
#include "Constants.h"
#include "Algorithm.h"
#include <iostream>

namespace My
{

	template<typename DataType, typename Comparator = My::Less<DataType>, typename RawAllocator = std::allocator<DataType>>
	class Set
	{
	private:

		struct Node
		{
			Node* left;
			Node* right;
			DataType data;
			Node(DataType data, Node* left = nullptr, Node* right = nullptr);
		};
		
		typedef typename RawAllocator::template rebind<Node>::other Allocator;

		Allocator allocator;
		Comparator comparator;
		Node* root;

		template<typename... Args>
		void   AllocateAndConstruct(Node*& rawNode, Args... args);
		void   DeallocateAndDestroy(Node* rawNode);	

		void   AddElement(DataType data, Node*& subTree);
		void   DeleteElement(DataType data, Node *& subTree);
		void   DeleteSubTree(Node* subTree);
		void   CopyTree(Node *& mainTree, Node* subTreeForCopy);
		bool   isFull(Node* root) const;
		bool   Find(DataType data, Node* subTree) const;
		void   getOutStream(std::ostream& out, Node* current) const;
		size_t getDepth(Node* subTree) const;
		size_t Size(Node* subTree) const;

	public :

		Set();
		Set(const Set<DataType, Comparator, RawAllocator>& toCopy);//copy ctor
		Set(Set<DataType, Comparator, RawAllocator>&& toMove);//move ctor
		~Set();

		void   AddElement(DataType data);
		void   DeleteElement(DataType data);
		
		size_t getDepth() const;
		size_t Size() const;
		bool   isFull() const;
		bool   Find(DataType data) const;

		template <typename DataType, typename Comparator, typename RawAllocator>
		friend std::ostream& operator<<(std::ostream& out, const Set<DataType, Comparator, RawAllocator>& set);
		template <typename DataType, typename Comparator, typename RawAllocator>
		friend std::istream& operator>>(std::istream& out, Set<DataType, Comparator, RawAllocator>& set);
	
	};

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::DeallocateAndDestroy(Node* rawNode)
	{
		allocator.destroy(rawNode);
		allocator.deallocate(rawNode, ONE_NODE);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::AddElement(DataType data, Node*& subTree)
	{
		if (subTree == nullptr)
		{
			AllocateAndConstruct(subTree, data);
			return;
		}
		if (comparator(data,subTree->data))
		{
			AddElement(data, subTree->left);
			return;
		}
		else
		{
			AddElement(data, subTree->right);
		}
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::DeleteElement(DataType data, Node *& subTree)
	{
		if (subTree == nullptr)return;

		if (comparator(data, subTree->data))
		{
			DeleteElement(data, subTree->left);
			return;
		}
		else if (data != subTree->data)
		{
			DeleteElement(data, subTree->right);
			return;
		}

		if (subTree->left == nullptr && subTree->right == nullptr)
		{
			DeallocateAndDestroy(subTree);
			subTree = nullptr;
			return;
		}

		if (subTree->left == nullptr)
		{
			Node* help = subTree;
			subTree = subTree->right;
			DeallocateAndDestroy(help);
			return;
		}

		if (subTree->right == nullptr)
		{
			Node* help = subTree;
			subTree = subTree->left;
			DeallocateAndDestroy(help);
			return;
		}

		if (subTree->left->right == nullptr)
		{
			Node* help = subTree;
			subTree = subTree->left;
			subTree->right = help->right;
			DeallocateAndDestroy(help);
			return;
		}
		else
		{
			Node* help = subTree->left;

			while (help->right->right != nullptr)
				help = help->right;

			My::swap(help->right->data, subTree->data);
			DeleteElement(data,help->right);
		}
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::DeleteSubTree(Node* subTree)
	{
		if (subTree == nullptr) return;

		DeleteSubTree(subTree->left);
		DeleteSubTree(subTree->right);
		DeallocateAndDestroy(subTree);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline bool Set<DataType, Comparator, RawAllocator>::Find(DataType data, Node* subTree) const
	{
		if (subTree == nullptr) return false;
		return subTree->data == data || Find(data, subTree->left) || Find(data, subTree->right);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline size_t Set<DataType, Comparator, RawAllocator>::getDepth(Node* subTree) const
	{
		if (subTree == nullptr) return 0;
		return MAX(getDepth(subTree->left), getDepth(subTree->right)) + 1;
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline size_t Set<DataType, Comparator, RawAllocator>::Size(Node* subTree) const
	{
		if (subTree == nullptr) return 0;
		return Size(subTree->left) + Size(subTree->right) + 1;
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::CopyTree(Node*& mainSubTree,Node* subTreeForCopy)
	{
		if (subTreeForCopy == nullptr) return;

		AllocateAndConstruct(mainSubTree,subTreeForCopy->data);
		CopyTree(mainSubTree->left ,subTreeForCopy->left );
		CopyTree(mainSubTree->right,subTreeForCopy->right);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline bool Set<DataType, Comparator, RawAllocator>::isFull(Node* root) const
	{
		if (root == nullptr) return true;

		if (getDepth(root->left) != getDepth(root->right)) return false;

		return isFull(root->left) && isFull(root->right);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::getOutStream(std::ostream& out, Node* current) const
	{
		if (current == nullptr) return;
		getOutStream(out, current->left);
		out << current->data << " ";
		getOutStream(out, current->right);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline Set<DataType, Comparator, RawAllocator>::Set() :
		allocator(Allocator()),
		comparator(Comparator()),
		root(nullptr)
	{}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline Set<DataType, Comparator, RawAllocator>::Set(const Set & toCopy) :
		allocator(toCopy.allocator),
		comparator(toCopy.comparator)
	{
		CopyTree(root, toCopy.root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline Set<DataType, Comparator, RawAllocator>::Set(Set<DataType,Comparator,RawAllocator>&& toMove)
	{
		root	   = std::move(toMove.root);
		comparator = std::move(toMove.comparator);
		allocator  = std::move(toMove.allocator);
		toMove.root = nullptr;
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	Set<DataType, Comparator, RawAllocator>::Node::Node(DataType data, Node* left, Node* right) :
		data(data),
		left(left),
		right(right)
	{}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline Set<DataType, Comparator, RawAllocator>::~Set()
	{
		DeleteSubTree(root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::AddElement(DataType data)
	{
		AddElement(data, root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline void Set<DataType, Comparator, RawAllocator>::DeleteElement(DataType data)
	{
		DeleteElement(data, root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline size_t Set<DataType, Comparator, RawAllocator>::getDepth() const
	{
		return getDepth(root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline size_t Set<DataType, Comparator, RawAllocator>::Size() const
	{
		return Size(root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline bool Set<DataType, Comparator, RawAllocator>::Find(DataType data) const
	{
		return Find(data, root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	inline bool Set<DataType, Comparator, RawAllocator>::isFull() const
	{
		return isFull(root);
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	std::ostream& operator<<(std::ostream& out, const Set<DataType, Comparator, RawAllocator>& set)
	{
		set.getOutStream(out, set.root);
		return out;
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	std::istream& operator>>(std::istream& in,Set<DataType, Comparator, RawAllocator>& set)
	{
		DataType inputData;
		in >> inputData;
		set.AddElement(inputData);
		return in;
	}

	template<typename DataType, typename Comparator, typename RawAllocator>
	template<typename ...Args>
	inline void Set<DataType, Comparator, RawAllocator>::AllocateAndConstruct(Node*& rawNode, Args... args)
	{
		rawNode = allocator.allocate(ONE_NODE);
		allocator.construct(rawNode, args...);
	}

}//namespace My

#endif // !SET_H
