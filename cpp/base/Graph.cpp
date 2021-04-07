#include "Graph.h"


void My::Graph::deleteGraphAndNullingVertex()
{
	deleteMatrix(graph, vertex);
	vertex = 0;
}

My::Graph::Graph() :
	vertex(NO_VERTEX),
	graph(nullptr)
{}

My::Graph::Graph(size_t vertex, int** graph) :
	vertex(vertex)
{
	this->graph = initMatrix<int>(vertex, vertex);
	for (size_t i = 0; i < vertex; ++i)
		for (size_t j = 0; j < vertex; ++j)
			this->graph[i][j] = graph[i][j];
}

My::Graph::~Graph()
{
	deleteMatrix(graph, vertex);
}

void My::Graph::readGraphFromConsole()
{
	this->deleteGraphAndNullingVertex();

	std::cout << "Input quantity of vertex :\n";
	std::cin >> this->vertex;
	std::cout << "Input adjacency matrix :\n";
	graph = initMatrix<int>(vertex, vertex);
	for (size_t i = 0; i < vertex; ++i)
		for (size_t j = 0; j < vertex; ++j)
			std::cin >> graph[i][j];
}

bool My::Graph::readGraphFromFile(std::string fileName)
{
	this->deleteGraphAndNullingVertex();

	std::ifstream fin(fileName);
	if (!fin.is_open()) return false;

	graph = initMatrix<int>(vertex, vertex);

	fin >> vertex;
	for (size_t i = 0; i < vertex; ++i)
		for (size_t j = 0; j < vertex; ++j)
			fin >> graph[i][j];
	return true;
}

void My::Graph::BFS(size_t start, void(*Logic)(size_t vertex))
{
	if (Logic == nullptr) Logic = [](size_t vertex) { std::cout << vertex << " "; };
	bool* isMarked = setArray(initArray<bool>(vertex), vertex, NOT_MARKED);
	std::queue<int> q;

	q.push(start);
	isMarked[start] = MARKED;
	
	size_t temp;
	while (!q.empty())
	{
		temp = q.front(); q.pop();
		Logic(temp);
		for (size_t i = 0; i < vertex; ++i)
		{
			if (graph[temp][i] != NO_ROUTE && !isMarked[i])
			{
				isMarked[i] = MARKED;
				q.push(i);
			}
		}
	}

	deleteArray(isMarked);
}

void My::Graph::DFS(size_t start, void(*Logic)(size_t vertex))
{
	if (Logic == nullptr) Logic = [](size_t vertex) { std::cout << vertex << " "; };

	bool* isMarked = setArray(initArray<bool>(vertex), vertex, NOT_MARKED);
	std::stack<int> s;

	s.push(start);
	isMarked[start] = MARKED;

	size_t temp;

	while (!s.empty())
	{
		temp = s.top(); s.pop();
		Logic(temp);
		for (size_t i = 0; i < vertex; ++i)
		{
			if (graph[temp][i] != NO_ROUTE && !isMarked[i])
			{
				isMarked[i] = MARKED;
				s.push(i);
			}
		}
	}

	deleteArray(isMarked);
}

int* My::Graph::DistancesByDejkstra(size_t start)
{
	int* distances = setArray(initArray<int>(vertex),vertex, INT_MAX);
	bool* isMarked = setArray(initArray<bool>(vertex), vertex, NOT_MARKED);

	distances[start] = 0;//its important in another way wont working


	auto minimalDistance = [isMarked,distances, this]()->int {
		
		int minPath	= INFINITY;
		int minIndex = -1;

		for (size_t i = 0; i < vertex; ++i)
		{
			if (!isMarked[i] && distances[i] < minPath)
			{
				minPath = distances[i];
				minIndex = i;
			}
		}
		if (minIndex != -1)isMarked[minIndex] = MARKED;
		return minIndex;
	};


	int temp;
	for (size_t i = 0; i < vertex; ++i)
	{
		temp = minimalDistance();
		if (temp == -1)
		{
			std::cout << "dont have ways!\n";
			deleteArray(isMarked);
			return distances;
		}

		for (size_t i = 0; i < vertex; ++i)
		{
			if (graph[temp][i] != NO_ROUTE)
			{
				distances[i] = MIN(distances[i], distances[temp] + graph[temp][i]);
			}
		}

	}
	deleteArray(isMarked);
	return distances;
}

int* My::Graph::PathByDejkstra(size_t end, size_t start)
{
	int*  distances = setArray(initArray<int>(vertex), vertex, INT_MAX);
	bool* isMarked  = setArray(initArray<bool>(vertex), vertex, NOT_MARKED);
	int* route		= setArray(initArray<int>(vertex), vertex, NO_ROUTE);
	
	distances[start] = 0;//its important in another way wont working
	route[start] = start;

	auto minimalDistance = [isMarked, distances, this]()->int {

		int minPath = INFINITY;
		int minIndex = -1;

		for (size_t i = 0; i < vertex; ++i)
		{
			if (!isMarked[i] && distances[i] < minPath)
			{
				minPath = distances[i];
				minIndex = i;
			}
		}
		if (minIndex != -1)isMarked[minIndex] = MARKED;
		return minIndex;
	};


	int temp;
	for (size_t i = 0; i < vertex; ++i)
	{
		temp = minimalDistance();
		if (temp == -1)
		{
			std::cout << "dont have ways!\n";
			deleteArray(isMarked);
			deleteArray(distances);
			return route;
		}

		for (size_t i = 0; i < vertex; ++i)
		{
			if (graph[temp][i] != NO_ROUTE)
			{
				if (distances[i] > distances[temp] + graph[temp][i])
				{
					distances[i] = distances[temp] + graph[temp][i];
					route[i] = temp;
				}
				else
				{

				}
			}
		}

	}
	deleteArray(isMarked);
	deleteArray(distances);
	return route;
}

std::pair<int**,int*> My::Graph::Floyd()
{
	int** result = initMatrix<int>(vertex, vertex);
	int* route = setArray(initArray<int>(vertex), vertex, -1);
	for (size_t i = 0; i < vertex; ++i)
		for (size_t j = 0; j < vertex; ++j)
			result[i][j] = graph[i][j];

	for (size_t k = 0; k < vertex; ++k)
	{
		for (size_t i = 0; i < vertex; ++i)
		{
			for (size_t j = 0; j < vertex; ++j)
			{
				if (result[i][k] == NO_ROUTE || result[k][j] == NO_ROUTE)
				{
					continue;
				}
				else
				{
					if (result[i][j] == NO_ROUTE)
					{
						result[i][j] = result[i][k] + result[k][j];
						route[j] = k; 
					}
					else
					{
						result[i][j] = MAX(result[i][k] + result[k][j], result[i][j]);
					}
				}
			}
		}		
	}
	return std::make_pair(result, route);
}

std::ostream& My::operator<<(std::ostream& out, const Graph& graph)
{
	out << graph.vertex << " ";
	for (size_t i = 0; i < graph.vertex; ++i)
	{
		for (size_t j = 0; j < graph.vertex; ++j)
			out << graph.graph[i][j] << " ";
		out << "\n";
	}

	return out;
}

std::istream& My::operator>>(std::istream& in, Graph& graph)
{
	in >> graph.vertex;
	for (size_t i = 0; i < graph.vertex; ++i)
		for (size_t j = 0; j < graph.vertex; ++j)
			in >> graph.graph[i][j];
	return in;
}
