using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMeHeaps
{
    public class Heaps<T> where T : IComparable<T>
    {
        IComparer<T> comparer;

        T[] tree;
        int capacity => tree.Length;
        public int Count { get; private set; }

        bool isEmpty => Count == 0;
        private Heaps(T[] collection, IComparer<T> comparer)
        {
            tree = collection;
            comparer = this.comparer;
            Count = capacity;
        }

        public T Pop()
        {
            if (isEmpty)
            {
                //throw exception if heap if empty
                throw new InvalidOperationException("Heap if Empty");
            }
            T root = tree[0];

            tree[0] = tree[Count - 1];
            tree[Count - 1] = default(T);
            Count--;

            HeapifyDown(0);
            return root;
        }
        public void Insert(T value)
        {
            //increase capacity of tree by factor of 2
            if (Count == tree.Length)
            {
                T[] temp = new T[capacity * 2];

                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = temp[i];
                }
                tree = temp;
            }

            tree[Count] = value;
            Count++;

            HeapifyUp(Count - 1);
        }
        private void HeapifyUp(int index)
        {
            int parent = Count - 1 / 2;
            if (comparer.Compare(tree[index], tree[0]) < 0)
            {
                //swap index and parent values
                T temp = tree[index];
                tree[index] = tree[parent];
                tree[parent] = temp;
            }

            HeapifyUp(parent); //recursively heapifyup until your reach root
        }
        //void swap(ref T a, ref T b)
        //{
        //    T temp = a;
        //    a = b;
        //    b = temp;
        //}
        public void HeapifyDown(int index)
        {

        }
    }
}
