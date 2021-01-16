using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Vertex<T>
    {
        public T Value { get;  set; }

        public List<Vertex<T>> Neighbors {get; set;}
        public bool hasVisited { get; set; }
        public int count => Neighbors.Count;
        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }
       
    }
}
