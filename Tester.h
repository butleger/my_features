#pragma once
#ifndef TESTER_H
#define TESTER_H

template <typename Container, typename Generator>
class Tester_base
{
protected :

	Generator generator;

	size_t getRandom();

public :
	
	Tester_base(size_t seed);
	~Tester_base();

	bool Assert();


};

#endif // !TESTER_H
