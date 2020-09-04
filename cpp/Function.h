#pragma once
#ifndef FUNCTIONS_H
#define FUNCTIONS_H

namespace My
{
	template <typename ValueType>
	class Less
	{
	public :
		bool operator()(ValueType left, ValueType right)
		{
			return left < right;
		}
		
		template <typename newValueType>
		struct rebind
		{
			typedef Less<newValueType> other;
		};
	};

	template <typename ValueType>
	class Greater
	{
	public:
		bool operator()(ValueType left, ValueType right)
		{
			return right < left;
		}

		template <typename newValueType>
		struct rebind
		{
			typedef Less<newValueType> other;
		};
	};
}//namespace My

#endif // !FUNCTIONS_H
