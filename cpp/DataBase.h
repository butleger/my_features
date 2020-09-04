#pragma once
#ifndef DATA_BASE_H
#define DATA_BASE_H

#include <algorithm>
#include <set>
#include <vector>
#include <list>

template <typename Data, typename Container>
class DataBase
{
private:

	Container container;

public :

	DataBase();
	~DataBase();
	
	Data Query(bool (*predicate)(Data element));
	void PutData(Data data);
	void DeleteData(Data data);

};

template<typename Data, typename Container>
inline DataBase<Data, Container>::DataBase() :
	container(Container())
{}

template<typename Data, typename Container>
inline DataBase<Data, Container>::~DataBase()
{}

template<typename Data, typename Container>
inline Data DataBase<Data, Container>::Query(bool (*predicate)(Data element))
{
	auto result = std::find_if(container.begin(), container.end(), predicate);
	if (result == container.end()) throw std::exception("Dont Have element!\n");
	return *result;
}

template<typename Data, typename Container>
inline void DataBase<Data, Container>::PutData(Data data)
{
	container.insert(container.begin(), data);
}

template<typename Data, typename Container>
inline void DataBase<Data, Container>::DeleteData(Data data)
{
	auto toDelete = std::find(container.begin(), container.end(), data);
	if (toDelete == container.end())return;
	container.erase(toDelete);
}

#endif // !DATA_BASE_H

