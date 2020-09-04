#pragma once
#ifndef LIST_H
#define LIST_H

#include <iostream>
#include "Constants.h"

namespace My
{

    template <typename DataType, typename RawAllocator = std::allocator<DataType>>
    class List
    {
    private:
        struct Node
        {
            Node*    next;
            Node*    last;
            DataType data;
            Node( DataType Data, Node *next = nullptr, Node *last = nullptr );
        };

        typedef typename RawAllocator::template rebind<Node>::other Allocator;//allocator type

        size_t size;
        Node*  head;
        Node*  tail;
        Allocator allocator;

        Node* getNodeByIndex(size_t index);// if have bad index delete all Nodes and throw exception
        void  DeleteAllNodes();//make list clear
        void  DeleteNextNode(Node* beforeDeleting);
        void  Sort(int** ArrayForSort);//sort array of pointer in connection to data where pointers point
        void  CopyConstructAndAllocateNode(Node* destination, const DataType & copyValue);//do copy constructor in destination
        void  MoveConstructAndAllocateNode(Node* destination,       DataType&& copyValue);//do move constructot in destination
        void  DeallocateAndDestroy(Node* toDelete);
        
        template <typename ...Args>
        Node* AllocateAndConstruct(Args... args);//allocate and construct Node with args and return it

    public:

        List();
        List(const My::List<DataType, RawAllocator> & ListForCopy);//copy ctor
        List(List&& ListForMoving);//Move ctor
        virtual ~List();

        virtual void PushBack(DataType Data);
        virtual void PushFront(DataType Data);
        virtual void PopFront();
        virtual void PopBack();
        
        void Insert(DataType Data, size_t index);
        void DeleteByIndex(size_t index);
        void DeleteByData(DataType Data);
        void Reverse();
        void Sort();
        int  getSize() const;
        bool isEmpty() const;

            const int& operator[](size_t index) const;
                  int& operator[](size_t index);
        My::List<DataType, RawAllocator> operator=(const My::List<DataType, RawAllocator>& ListForEquality) &;//copy equality
        My::List<DataType, RawAllocator> operator=(My::List<DataType, RawAllocator>&& ListForMoving) &;//moving equality

        //special + when no need to save objects
        template <typename DataType,typename RawAllocator>
        friend My::List<DataType, RawAllocator> operator+(My::List<DataType, RawAllocator>&& LeftListForSum,
                                                          My::List<DataType, RawAllocator>&& RightListForSum);

        //just connect head of first list to second
        template <typename DataType,typename RawAllocator>
        friend My::List<DataType, RawAllocator> operator+(const My::List<DataType, RawAllocator>& LeftListForSum,
                                                          const My::List<DataType, RawAllocator>& RightListForSum);
        
        template <typename DataType,typename RawAllocator>
        friend My::List<DataType, RawAllocator> operator+(My::List<DataType, RawAllocator>&& ListForAddition,
                                                                                    DataType&& ElementForSum);

        //there are another operators that resolve Type + List in List + Type after body of this
        template <typename DataType,typename RawAllocator>
        friend My::List<DataType, RawAllocator> operator+(const My::List<DataType, RawAllocator>& ListForAddition,
                                                          const DataType& ElementForSum);//make PushBack new element to List
        
        template <typename DataType,typename RawAllocator>
        friend std::ostream& operator<<(std::ostream&   OutStream, const My::List<DataType, RawAllocator>& list);
        
        template <typename DataType,typename RawAllocator>//read one element and push it back
        friend std::istream& operator>>(std::istream& InputStream, My::List<DataType, RawAllocator>& list);

    };

    template <typename DataType,typename Allocator>
    My::List<DataType, Allocator>::List() :
    allocator(Allocator()),
    size(NO_SIZE),
    head(nullptr),
    tail(nullptr)
    {}

    template<typename DataType, typename RawAllocator>
    My::List<DataType, RawAllocator>::List(const My::List<DataType, RawAllocator>& ListForCopy) :
        allocator(Allocator()),
        size(NO_SIZE),
        head(nullptr),
        tail(nullptr)
    {
        Node* ElementForCopy = ListForCopy.head;
        //form new List with copy of old Data
        for (int i = 0; i < ListForCopy.size; ++i)
        {
            this->PushBack(ElementForCopy->data);
            ElementForCopy = ElementForCopy->next;
        }
    }

    template<typename DataType,typename RawAllocator>
    My::List<DataType, RawAllocator>::List(My::List<DataType, RawAllocator>&& ListForMoving) :
        allocator(Allocator()),
        size(NO_SIZE),
        head(nullptr),
        tail(nullptr)
    {
        this->allocator = std::move(ListForMoving.allocator);
        this->size      = std::move(ListForMoving.size);
        this->head      = std::move(ListForMoving.head);
        this->tail      = std::move(ListForMoving.tail);
        ListForMoving.size = 0;//because old list can try to delete moved data 
    }
    
    template <typename DataType, typename RawAllocator>
    My::List<DataType, RawAllocator>::~List()
    {
        DeleteAllNodes();
    }

    template <typename DataType,typename RawAllocator>
    My::List<DataType, RawAllocator>::Node::Node(DataType Data, Node* next, Node* last) :
    data(Data),
    next(next),
    last(last)
    {}

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::Insert(DataType Data, size_t index)
    {
        if (index == HEAD_INDEX)
        {
            PushFront(Data);
            return;
        }
        if (index == size )
        {
            PushBack(Data);
            return;
        }

        Node* NodeBeforeInsertion = getNodeByIndex(index - 1);
        NodeBeforeInsertion->next = AllocateAndConstruct(Data, NodeBeforeInsertion->next, NodeBeforeInsertion);
        
        //make good direction after node that was inserted
        NodeBeforeInsertion->next->next->last = NodeBeforeInsertion->next;
        ++size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::PushBack(DataType Data)
    {
        if (tail == nullptr)
        {
            head = tail = AllocateAndConstruct(Data);
        }
        else
        {
            tail = tail->next = AllocateAndConstruct(Data, nullptr, tail);
        }

        ++size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::PushFront(DataType Data)
    {
        if (tail == nullptr)
        {
            head = tail = AllocateAndConstruct(Data);
        }
        else 
        {
            head = head->last = AllocateAndConstruct(Data, head);
        }

        ++size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::DeleteByIndex(size_t index)
    {
        if (index == HEAD_INDEX)
        {
            PopFront();
            return;
        }
        if (index == TAIL_INDEX)
        {
            PopBack();
            return;
        }

        Node* BeforeDeleting = getNodeByIndex(index - 1);
        Node* ForDeleting = BeforeDeleting->next;

        BeforeDeleting->next = ForDeleting->next;
        //make good direction in Node after Node that will be deleted
        ForDeleting->next->last = BeforeDeleting;
        DeallocateAndDestroy(ForDeleting);
        --size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::DeleteByData(DataType Data)
    {
        Node * forDeleting = head;
        if (forDeleting == nullptr) return;
        if (head->data == Data)
        {
            PopFront();
            return;
        }

        for (int i = 0 ; i < size - 1 ; ++i )
        {
            //if next Node should be deleted
            if (forDeleting->next->data == Data )
            {
                DeleteNextNode(forDeleting);
                return;
            }
            forDeleting = forDeleting->next;
        }
        return;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::PopBack()
    {
        if (tail == nullptr) return;
        if (size == 1)
        {
            DeallocateAndDestroy(head);
            head = nullptr;
            tail = nullptr;
            --size;
            return;
        }
        //one step back and then delete next node
        tail = tail->last;
        DeallocateAndDestroy(tail->next);
        tail->next = nullptr;
        --size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::PopFront()
    {
        if (tail == nullptr) return;
        if (size == 1)
        {
            DeallocateAndDestroy(head);
            head = nullptr;
            tail = nullptr;
            --size;
            return;
        }

        //one step next and then delete last node
        head = head->next;
        DeallocateAndDestroy(head->last);
        head->last = nullptr;
        --size;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::Reverse()
    {
        Node* current = head;
        for (int i = 0; i < size; ++i)
        {
            //swap all direction in Nodes
            std::swap(current->next, current->last);
            current = current->last;
        }
        //also swap first and last Nodes
        std::swap(head, tail);
    }

    //just sort Data in Nodes
    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::Sort()
    {
        Node* Element = head;
        int** ArrayForSort = new int*[size];

        for (int i = 0; i < size; ++i)
        {
            //make arrays of pointers of Node Data elements
            ArrayForSort[i] = &Element->Data;
            Element = Element->next;
        }

        //sort all elements in array with their connection 
        Sort(ArrayForSort);

        delete[] ArrayForSort;
        return;
    }
    template<typename DataType,typename RawAllocator>
    typename My::List<DataType, RawAllocator>::Node* My::List<DataType, RawAllocator>::getNodeByIndex(size_t index)
    {
        //if have bad index delete all nodes and throw exception
        if (index >= size)
        {
            DeleteAllNodes();
            throw std::exception("Bad index!\n");
        }

        Node* result;
        if (index > size / 2)
        {
            result = tail;
            size_t end = size - index - 1;
            for (size_t i = 0; i < end; ++i)
            {
                result = result->last;
            }
        }
        else
        {
            result = head;
            for (int i = 0; i < index; ++i)
            {
                result = result->next;
            }

        }

        return result;
    }

    template <typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::DeleteAllNodes()
    {
        Node* toDelete = head, *help;
        for (int i = 0 ; i < size ; ++i )
        {
            help = toDelete->next;
            DeallocateAndDestroy(toDelete);
            toDelete = help;
        }

        //make list consistent
        size = 0;
        head = nullptr;
        tail = nullptr;
    }

    template<typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::DeleteNextNode(Node* beforeDeleting)
    {

        Node* toDeleting = beforeDeleting->next;
        beforeDeleting->next = toDeleting->next;
        
        //if shouldn`t make connection in Node after deleting Node
        if (toDeleting->next == nullptr)
        {
            beforeDeleting->next = nullptr;
            DeallocateAndDestroy(toDeleting);
            --size;
            return;
        }

        beforeDeleting->next->last = beforeDeleting;
        DeallocateAndDestroy(toDeleting);
        --size;
    }

    template<typename DataType,typename RawAllocator>
    void My::List<DataType, RawAllocator>::Sort(int** ArrayForSort)
    {
        //just bubble sort
        for (int i = 0; i < size ; ++i )
            for (int j = 1 ; j < size - i ; ++j) 
                if (*ArrayForSort[j] < *ArrayForSort[j - 1])
                {
                    int temp             = (*ArrayForSort[j]);
                    *ArrayForSort[j]     = (*ArrayForSort[j - 1]);
                    *ArrayForSort[j - 1] = (temp);
                }
    }

    template<typename DataType, typename RawAllocator>
    void My::List<DataType, RawAllocator>::CopyConstructAndAllocateNode(Node* destination,const DataType& copyValue)
    {
        destination = allocator.allocate(ONE_NODE);
        allocator.construct(destination, copyValue);
    }

    template<typename DataType, typename RawAllocator>
    void My::List<DataType, RawAllocator>::MoveConstructAndAllocateNode(Node* destination, DataType&& copyValue)
    {
        destination = allocator.allocate(ONE_NODE);
        allocator.construct(destination, std::move(copyValue));
    }

    template<typename DataType, typename RawAllocator>
    void My::List<DataType, RawAllocator>::DeallocateAndDestroy(Node* toDelete)
    {
        allocator.destroy(toDelete);
        allocator.deallocate(toDelete, ONE_NODE);
    }

    template<typename DataType, typename RawAllocator>
    template <typename ...Args>
    inline typename List<DataType, RawAllocator>::Node* List<DataType, RawAllocator>::AllocateAndConstruct(Args... args)
    {
        Node* result;
        result = allocator.allocate(ONE_NODE);
        allocator.construct(result, args... );
        return result;
    }

    template <typename DataType,typename RawAllocator>
    const int& My::List<DataType, RawAllocator>::operator[](size_t index) const
    {
        Node* result = getNodeByIndex(index);
        return result->Data;  
    }

    template <typename DataType,typename RawAllocator>
    int& My::List<DataType, RawAllocator>::operator[](size_t index)
    {
        Node* result = getNodeByIndex(index);
        return result->Data; 
    }

    template<typename DataType,typename RawAllocator>
    My::List<DataType, RawAllocator> My::List<DataType, RawAllocator>::operator=(const My::List<DataType, RawAllocator> & ListForEquality) &
    {
        this->DeleteAllNodes();
        Node* ElementForEquality = ListForEquality.head;
        //form new List with copy of old Data
        for (int i = 0; i < ListForEquality.size; ++i)
        {
            this->PushBack(ElementForEquality->Data);
            ElementForEquality = ElementForEquality->next;
        }
        return *this;
    }

    template<typename DataType,typename RawAllocator>
    My::List<DataType, RawAllocator> My::List<DataType, RawAllocator>::operator=(My::List<DataType, RawAllocator>&& ListForMoving) &
    {
        this->DeleteAllNodes();
        this->allocator = std::move(ListForMoving.allocator);
        this->size      = std::move(ListForMoving.size);
        this->head      = std::move(ListForMoving.head);
        this->tail      = std::move(ListForMoving.tail);
        ListForMoving.size = NO_SIZE;
        return *this;
    }

   
    template<typename DataType,typename RawAllocator>//glue 2 list and throw result
    My::List<DataType, RawAllocator> operator+(const My::List<DataType, RawAllocator>& LeftListForSum
                                             , const My::List<DataType, RawAllocator>& RightListForSum)
    {
        My::List<DataType, RawAllocator> result(LeftListForSum);
        typename My::List<DataType, RawAllocator>::Node* ElementForAddition = RightListForSum.head;

        for (int i = 0; i < RightListForSum.size; ++i)
        {
            result.PushBack(ElementForAddition->data);
            ElementForAddition = ElementForAddition->next;
        }

        return result;
    }

    template<typename DataType,typename RawAllocator>//glue 2 list and throw result
    My::List<DataType, RawAllocator> operator+(My::List<DataType, RawAllocator>&& LeftListForSum, 
                                               My::List<DataType, RawAllocator>&& RightListForSum)
    {
        typename My::List<DataType, RawAllocator>::Node* current = RightListForSum.head;

        LeftListForSum.tail->next = RightListForSum.head;
        RightListForSum.head->last = LeftListForSum.tail;
        LeftListForSum.tail = RightListForSum.tail;
        LeftListForSum.size += RightListForSum.size;
        
        RightListForSum.size = 0;
        RightListForSum.head = 0;
        RightListForSum.tail = 0;
        
        return LeftListForSum;
    }

    template<typename DataType,typename RawAllocator>//add new Element at the end
    My::List<DataType, RawAllocator> operator+(My::List<DataType, RawAllocator>&& ListForAddition, DataType&& ElementForSum)
    {
        ListForAddition.PushBack(ElementForSum);
        return ListForAddition;
    }

    template <typename DataType,typename RawAllocator>//add new Element at the end
    My::List<DataType, RawAllocator> operator+(DataType&& ElementForSum, My::List<DataType, RawAllocator>&& ListForAddition)
    {
        return ListForAddition + ElementForSum;
    }


    template<typename DataType,typename RawAllocator>//add new Element at the end
    My::List<DataType, RawAllocator> operator+(const My::List<DataType, RawAllocator>& ListForAddition,const DataType& ElementForSum)
    {
        My::List<DataType, RawAllocator> result(ListForAddition);
        result.PushBack(ElementForSum);
        return result;
    }

    template<typename DataType,typename RawAllocator>//add new Element at the end
    My::List<DataType, RawAllocator> operator+(const DataType& ElementForSum, const My::List<DataType, RawAllocator>& ListForAddition)
    {
        return ListForAddition + ElementForSum;
    }

    template<typename DataType,typename RawAllocator>
    std::ostream& operator<<(std::ostream& OutStream, const My::List<DataType, RawAllocator>& list)
    {
        typename My::List<DataType, RawAllocator>::Node* toOutput = list.head;
        for (int i = 0; i < list.size; ++i)
        {
            OutStream << toOutput->data << " ";
            toOutput = toOutput->next;
        }
        return OutStream;
    }

    template<typename DataType,typename RawAllocator>
    std::istream& operator>>(std::istream& InputStream, My::List<DataType, RawAllocator>& list)
    {
        //add new element in the tail
        DataType newListElement;
        InputStream >> newListElement;
        list.PushBack(newListElement);
        return InputStream;
    }
    
    template<typename DataType,typename RawAllocator>
    int My::List<DataType, RawAllocator>::getSize() const
    {
        return size;
    }

    template<typename DataType, typename RawAllocator>
    inline bool List<DataType, RawAllocator>::isEmpty() const
    {
        return head == nullptr;
    }

} // namespace My

#endif // end of _LIST_H_