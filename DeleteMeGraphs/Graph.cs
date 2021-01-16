using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; set; }

        public int VertexCount => Vertices.Count;

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null)
            {
                throw new NullReferenceException("Vertex is null"); //throw an exception
            }
            else if (vertex.Neighbors.Count != 0)
            {
                throw new Exception("Vertex has neighbors!");
            }
            else if (Vertices.Contains(vertex))
            {
                throw new Exception("Vertex doesn't exist!");
            }
            Vertices.Add(vertex);
        }
        public void AddVertex(T value)
        {
            AddVertex(new Vertex<T>(value));
        }
        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                return true;
            }
            for (int i = 0; i < vertex.Neighbors.Count; i++) //for each neighbor, remove the connection/edge
            {
                RemoveEdge(vertex, vertex.Neighbors[i]);
            }
            return Vertices.Remove(vertex);
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a == null)
            {
                throw new ArgumentNullException();
            }
            if (b == null)
            {
                throw new ArgumentNullException();
            }
            if (!Vertices.Contains(a) && !Vertices.Contains(b))
            {
                return false;
            }
            Vertices[Vertices.IndexOf(a)].Neighbors.Add(b);
            Vertices[Vertices.IndexOf(b)].Neighbors.Add(a);
            return true;

        }
        public void AddEdge(T a, T b)
        {
            Vertex<T> A = Search(a);
            Vertex<T> B = Search(b);

            AddEdge(A, B);
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b) //helper function
        {
            if (a == null)
            {
                throw new ArgumentNullException();
            }
            if (b == null)
            {
                throw new ArgumentNullException();
            }
            if (Vertices.Contains(a) && Vertices.Contains(b) && Vertices[Vertices.IndexOf(a)].Neighbors.Contains(b))
            {
                Vertices[Vertices.IndexOf(a)].Neighbors.Remove(b);
                Vertices[Vertices.IndexOf(b)].Neighbors.Remove(a);
                return true;
            }
            return false;
        }
        public void RemoveEdge(T a, T b)
        {
            Vertex<T> A = Search(a);
            Vertex<T> B = Search(b);

            RemoveEdge(A, B);
        }
        public Vertex<T> Search(T value)
        {

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (value.Equals(Vertices[i].Value))
                {
                    return Vertices[i];
                }
            }
            return null;
        }

        public bool DepthFirstContains(T start, T end) => DepthFirstPath(start, end).Count != 0;

        public List<T> DepthFirstPath(T start, T end)
        {
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            List<T> path = new List<T>();
            Vertex<T> current = Search(start);

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].hasVisited = false;
            }
            stack.Push(current);


            while (stack.Count > 0)
            {

                current = stack.Pop(); //set current to start

                current.hasVisited = true;
                path.Add(current.Value);

                if (current.Value.Equals(end)) //edge case for 2 vertices
                {
                    return path;
                }

                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!current.Neighbors[i].hasVisited)
                    {
                        current.Neighbors[i].hasVisited = true;
                        stack.Push(current.Neighbors[i]);
                    }
                }

            }

            return new List<T>();
        }
        public List<T> BFSPath(T start, T end)
        {
            //bool[] cycle = new bool[Vertices.Count];
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            List<T> path = new List<T>();
            Vertices.ForEach(vertex => vertex.hasVisited = false);

            var startNode = Search(start);
            if (startNode is null) return path;
            var endNode = Search(end);
            if (endNode is null) return path;

            //for (int i = 0; i < cycle.Length; i++)
            //{
                queue.Enqueue(startNode);


                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    current.hasVisited = true;
                    path.Add(current.Value);

                    if (current== endNode)
                    {
                        return path;
                    }

                    for (int j = 0; j < current.Neighbors.Count; j++)
                    {
                        if (!current.Neighbors[j].hasVisited)
                        {
                            current.Neighbors[j].hasVisited = true;
                            queue.Enqueue(current.Neighbors[j]);
                        }
                        else if (queue.Contains(current))
                        {
                            //cycle[i] = true;
                            break;
                        }
                    }                  
                }
           // }
            return new List<T>();
        }
    }
}
