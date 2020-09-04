#pragma once

#ifndef TYPE_CONVERTIONS_H
#define TYPE_CONVERTIONS_H

namespace My
{
	template<typename T>
	struct TypeBase
	{
		typedef T Type;
	};

	struct TrueType
	{
		static constexpr bool value = true;
	};

	struct FalseType
	{
		static constexpr bool value = false;
	};

	template<typename Type> 
	struct RemoveReference : public TypeBase<Type> {};

	template<typename Type>
	struct RemoveReference<Type&> : public TypeBase<Type> {};

	template<typename Type>
	struct RemoveReference<Type&&> : public TypeBase<Type> {};

	template<typename Type>
	struct RemoveConst : public TypeBase<Type> {};

	template <typename Type>
	struct RemoveConst<const Type> : public TypeBase<Type> {};

	template<typename Type>
	struct RemovePointer : public TypeBase<Type> {};
	
	template<typename Type>
	struct RemovePointer<Type*> : public TypeBase<Type> {};

	template<typename Type1, typename Type2>
	struct IsSame : public FalseType {};

	template<typename Type>
	struct IsSame<Type, Type> : public TrueType {};

}//namespace My


#endif // !TYPE_INTERACTIONS_H
