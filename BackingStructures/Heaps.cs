using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMeHeaps
{
    public class Heaps<T>
    {
        private IComparer<T> comparer;

        private T[] tree;
        int capacity => tree.Length;
        public int Count { get; private set; }


        public bool isEmpty => Count == 0;

        //constructor for when heap is empty
        public Heaps(IComparer<T> Comparer)
        {
            tree = new T[0];
            comparer = Comparer;
        }

        //constructor that takes in existing array and sets tree equal to that array. Array is passed by ref
        //private Heaps(T[] collection, IComparer<T> comparer)
        //{
        //    if(collection == null)
        //    {
        //        throw new ArgumentException();
        //    }
        //    foreach (var item in collection)
        //    {
        //        Push(item);
        //    } 
        //    this.comparer = comparer;
        //    Count = capacity;
        //}

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
        public void Push(T value)
        {
            //increase capacity of tree by factor of 2
            if (Count == tree.Length)
            {
                T[] temp = new T[capacity == 0 ? 1 : capacity * 2];

                for (int i = 0; i < tree.Length; i++)//tree.CopyTo(temp,0);
                {
                    temp[i] = tree[i];
                }
                tree = temp;

            }
            tree[Count] = value;
            Count++;

            ;

            HeapifyUp(Count - 1);
        }
        public bool Contains(T value)
        {
            foreach (var item in tree)
            {
                if (comparer.Compare(item, value) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void HeapifyUp(int index)
        {

            if (index == 0)
            {
                return;
            }

            int parent = (index - 1) / 2;
            if (comparer.Compare(tree[index], tree[parent]) < 0)
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

        //for min heap
        public void HeapifyDown(int index) //index is starting node to heaptifydown
        {
            int leftchild = index * 2 + 1;

            if (leftchild >= Count)
            {
                return;
            }
            int rightchild = index * 2 + 2;
            int swapIndex = 0;

            if (rightchild >= Count)
            {
                swapIndex = leftchild;
            }
            else
            {   //if leftchild is less than rightchild,set swapIndex to leftchild
                swapIndex = comparer.Compare(tree[leftchild], tree[rightchild]) < 0 ? leftchild : rightchild;
            }

            if (comparer.Compare(tree[swapIndex], tree[index]) < 0) //if child is less than root, swap
            {
                T temp = tree[index];
                tree[index] = tree[swapIndex];
                tree[swapIndex] = temp;
            }

            //Move down to the next children recursively
            HeapifyDown(swapIndex);
        }

        public void Heapify()
        {
            int root = (Count - 2) / 2;
            //Loop through the elements and heapify down them
            for (int i = root; i > -1; i--)
            {
                HeapifyDown(i);
            }
        }

        //public static int CompareTo2(int x, int y)
        //{
        //    return x.CompareTo(y);
        //}

        public static T[] HeapSort(T[] array, Comparison<T> comparison)
        {
            Heaps<T> heap = new Heaps<T>(Comparer<T>.Create((a, b) => comparison(b, a)));

            heap.Heapify();

            while (heap.Count > 1)
            {
                //swap root with last elementr
                T temp = heap.tree[0];
                heap.tree[0] = heap.tree[heap.Count - 1];
                heap.tree[heap.Count - 1] = temp;

                heap.Count--;
                heap.HeapifyDown(0);
            }

            return heap.tree;
        }
    }

}
