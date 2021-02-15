using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMeGraphs
{
    class Edge<T>
    {
        public Vertex<T> Start { get; set; }
        public Vertex<T> End { get; set; }
        public int Dist { get; set;  }

        public bool hasVisited { get; set; }

        public Edge(Vertex<T> start, Vertex<T> end, int dist)
        {
            Start = start;
            End = end;
            Dist = dist;
            hasVisited = false;
        }
    }
}
