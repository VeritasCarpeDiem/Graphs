﻿using System;
using System.Collections.Generic;

namespace DeleteMeHeaps
{
    class Program
    {
        static void Main(string[] args)
        {
            Heaps<int> heap = new Heaps<int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
            heap.Insert(1);
            heap.Insert(9);
            heap.Insert(2);
            heap.Insert(13);
            heap.Insert(10);
            heap.Insert(3);
            Heaps<int>.HeapSort(heap, );

        }
    }
}
