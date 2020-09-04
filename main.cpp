#include <iostream>
#include <stack>
#include <list>
#include <algorithm>
#include "Polynom.h"
#include "TypeConvertions.h"

using namespace std;

template <typename T>
list<T> getReverse(list<T>& l)
{
	stack<T> s;
	list<T> result;

	for_each(l.begin(), l.end(), [&s, &result](T element)
		{
			s.push(element);
			result.push_front(s.top());
			s.pop();
		});
	return result;
}

int main()
{
	/*auto Print = [](int element) {cout << element << " "; };
	list<int> l1;
	int a1[] = { 1,2,3,4,5,6 };
	for (size_t i = 0; i < 6; ++i)
		l1.push_back(a1[i]);

	for_each(l1.begin(), l1.end(), Print);
	cout << endl;

	list<int> l2 = getReverse(l1);
	for_each(l2.begin(), l2.end(), Print);*/

	Polynom p;
	cin >> p;
	cin >> p;
	cout << p;
	cout << (!p);

	//int a;
	//cout << typeid(move(3)).name() << endl;
	//cout << My::IsSame<decltype(a), My::RemoveReference<decltype(move(3))>::Type>::value << endl;*/
	return 0;
}