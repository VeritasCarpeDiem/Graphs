using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeleteMeHeaps
{
    public class PriorityQueue<T>
    {

        private T[] Tree = new T[10];

        private IComparer<T> comparer;

        public int Count { get; private set; }

        public bool IsEmpty() => Count == 0;

        public bool Contains(T item) => Tree.Contains(item);

        public PriorityQueue()
            : this(Comparer<T>.Default) { }


        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Count = 0;
        }


        public void Enqueue(T value)
        {
            if (Count == Tree.Length)
            {
                T[] temp = new T[Count * 2];
                for (int i = 0; i < Tree.Length; i++)//tree.CopyTo(temp,0);
                {
                    Tree[i] = temp[i];
                }
                Tree = temp;
            }

            Tree[Count] = value;

            //Heaps<int>.HeapifyUp(Count);
            Count++;
        }

        public T Dequeue()
        {
            T root = Tree[1];

            return root;
        }
    }
}
