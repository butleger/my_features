#pragma once
#ifndef GRAPH_H
#define GRAPH_H

#include <stack>
#include <iostream>
#include <queue>
#include <fstream>
#include "Constants.h"

namespace My
{
	class Graph
	{
	private:
	
		int** graph;
		int vertex;

		void  deleteGraphAndNullingVertex();
		
		template <typename T>
		T*  initArray(size_t size);
		template <typename T>
		T** initMatrix(size_t stringSize, size_t columnSize);
		template <typename T>
		T*  setArray(T* array,size_t size, T value);
		template <typename T>
		void  deleteArray(T* arrayForDeleting);
		template <typename T>
		void deleteMatrix(T** matrixForDeleting, size_t stringSize);

	public :

		 Graph();
		 Graph(size_t vertex, int** graph);
		~Graph();

		void readGraphFromConsole();
		bool readGraphFromFile(std::string fileName);

		std::pair<int**,int*> Floyd();//path lengths and route
		void BFS(size_t start = 0, void (*Logic)(size_t vertex) = nullptr);
		void DFS(size_t start = 0, void (*Logic)(size_t vertex) = nullptr);
		int* DistancesByDejkstra(size_t start = 0);
		int* PathByDejkstra(size_t end, size_t start = 0);

		friend std::ostream& operator<<(std::ostream& out,const Graph& graph);
		friend std::istream& operator>>(std::istream& in ,      Graph& graph);
};

	

	template<typename T>
	inline T* Graph::initArray(size_t size)
	{
		return new T[size];
	}

	template<typename T>
	inline T** Graph::initMatrix(size_t stringSize, size_t columnSize)
	{
		T** result = new T*[stringSize];
		for (size_t i = 0; i < columnSize; ++i)
			result[i] = new T[columnSize];
		return result;
	}

	template<typename T>
	inline T* Graph::setArray(T* array,size_t size, T value)
	{
		for (size_t i = 0; i < size; ++i)
			array[i] = value;
		return array;
	}

	template<typename T>
	inline void Graph::deleteArray(T* arrayForDeleting)
	{
		delete[] arrayForDeleting;
	}

	template<typename T>
	inline void Graph::deleteMatrix(T** matrixForDeleting, size_t stringSize)
	{
		for (size_t i = 0; i < stringSize; ++i)
			deleteArray(matrixForDeleting[i]);
		deleteArray(matrixForDeleting);
	}

}


#endif // !GRAPH_H
