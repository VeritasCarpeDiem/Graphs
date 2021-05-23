using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DeleteMeGraphs
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class Vertex<T> // IEnumerable<Edge<T>>
    {
        
        public T Value { get;  set; }

        public List<Edge<T>> Neighbors {get; set;}
        
        public int cumulDist { get; set; }

        public bool hasVisited { get; set; }
        public int count => Neighbors.Count;
        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Edge<T>>();
        }

        
        private string GetDebuggerDisplay()
        {
            return $"{Value}";
        }

        //public IEnumerator<Edge<T>> GetEnumerator()
        //{
        //    return Neighbors.GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
