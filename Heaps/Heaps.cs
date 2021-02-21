using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMeHeaps
{
    public class Heaps<T> where T : IComparable<T>
    {

        int capacity;
        int Count;
        T[] arr;

        public Heaps()
        {
            capacity = 5;
            arr = new T[capacity];

            Count = 0;
        }

        public T Pop()
        {
            T value = arr[0];

            Count--;
            return value;
        }
        public void Insert(T value)
        {
            if (Count == arr.Length)
            {
                T[] temp = new T[capacity * 2];

                for (int i = 0; i < arr.Length; i++)
                {
                   arr[i] = temp[i] ;
                }
                arr = temp;
                capacity = capacity * 2;            }

            arr[Count] = value;
            Count++;
        }
        public void HeapifyUp()
        {

        }
    }
}
