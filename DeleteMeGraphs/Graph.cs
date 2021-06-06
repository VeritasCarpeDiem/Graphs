
using DeleteMeHeaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeleteMeGraphs
{
    public class Graph<T>
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

            // iterate over all vertices' edges, if the end is vertex, remove the edge from their list of edges
            foreach (var item in Vertices)
            {
                int removedCount = item.Neighbors.RemoveAll(edge => edge.End == vertex);
                //for (int i = 0; i < vertex.Neighbors.Count; i++)
                //{
                //    if (item == vertex)
                //    {
                //        RemoveEdge(item, vertex);
                //    }
                //}
            }


            return Vertices.Remove(vertex);
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b, int dist = 0)
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

            a.Neighbors.Add(new Edge<T>(a, b, dist));

            //Vertices[Vertices.IndexOf(a)].Neighbors.Add(b);
            //Vertices[Vertices.IndexOf(b)].Neighbors.Add(a);
            return true;

        }
        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b)))
            {
                return null;
            }

            foreach (var edge in a.Neighbors)
            {
                if (edge.End == b)
                {
                    return edge;
                }
            }

            return null;
        }
        public bool AddEdge(T a, T b, int dist)
        {
            Vertex<T> A = Search(a);
            Vertex<T> B = Search(b);
            return AddEdge(A, B, dist);
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b) //helper function
        {
            var edge = GetEdge(a, b);

            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }
            a.Neighbors.Remove(edge);
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
                    if (!current.Neighbors[i].isVisited)
                    {
                        current.Neighbors[i].isVisited = true;
                        stack.Push(current.Neighbors[i].End);
                    }
                }

            }

            return new List<T>();
        }

        public List<T> BFSShortestPathByHops(T start, T end)
        {
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            List<T> path = new List<T>();
            Dictionary<Vertex<T>, Vertex<T>> dict = new Dictionary<Vertex<T>, Vertex<T>>();
            //foreach (var vertex in Vertices)
            //{
            //    dict[vertex] = null;
            //}
            Vertices.ForEach(vertex => vertex.hasVisited = false);

            var startNode = Search(start);
            if (startNode is null) return path;
            var endNode = Search(end);
            if (endNode is null) return path;

            dict[startNode] = null;
            queue.Enqueue(startNode);
            var prev = startNode;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();


                current.hasVisited = true;
                //path.Add(current.Value);
                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!current.Neighbors[i].End.hasVisited)
                    {
                        current.Neighbors[i].End.hasVisited = true;
                        queue.Enqueue(current.Neighbors[i].End);
                        dict[current.Neighbors[i].End] = current;

                    }
                    //else if (queue.Contains(current)) break;

                    //prev = current;
                }
            }
            var pathStart = endNode;

            while (pathStart != null)
            {
                path.Add(pathStart.Value);
                //pathStart.hasVisited = true;
                pathStart = dict[pathStart];
            }
            path.Reverse();
            if (path.Contains(endNode.Value)) return path;
            else return new List<T>();
        }

        public IEnumerable<Vertex<T>> Djikstra(T start, T end)
        {
            //Comparer<int> comp = Comparer<int>.Create(DoSomething);
            Comparer<Vertex<T>> comparer = Comparer<Vertex<T>>.Create((x, y) => x.cumulDist.CompareTo(y.cumulDist));
            Heaps<Vertex<T>> queue = new Heaps<Vertex<T>>(comparer);
            
            Vertices.ForEach(vertex => {
                vertex.hasVisited = false;
                vertex.cumulDist = int.MaxValue;
            });

            var startNode = Search(start);
            if (startNode is null) return null;
            var endNode = Search(end);
            if (endNode is null) return null;
            var dic = new Dictionary<Vertex<T>, (Vertex<T> parent, int dist)>();

            dic[startNode] = (null, 0); // set distance of startNode to 0
            queue.Push(startNode);
            while (queue.Count > 0)
            {
                var current = queue.Pop();
                if (!current.hasVisited)
                {
                    current.hasVisited = true;
                    // path.Add(current.Value);

                    if (current == endNode)
                    {
                       break;                                               
                    }
                    foreach (var edge in current.Neighbors)
                    {
                        var neighbor = edge.End;
                        int tentativedist = edge.Dist + dic[current].dist;
                        if (tentativedist < neighbor.cumulDist && !neighbor.hasVisited)
                        {
                            dic[neighbor] = (current, tentativedist);
                            queue.Push(neighbor);
                            //  path.Add(current.Value);
                        }                     
                    }
                }
            }
            ;
            var path = new Stack<Vertex<T>>();

            Vertex<T> temp = endNode;

            while (temp != null)
            {
                path.Push(temp);
                temp = dic[temp].parent;
            }

            return path;
        }

        //private static float Heuristic(Heuristics heuristics,Point start,Point end , float D=1, float D2= 1 )
        //{
        //    float dx = -1;
        //    float dy = -1;
            
        //    switch(heuristics)
        //    {
        //        case Heuristics.Manhattan:
        //            dx = Math.Abs(start.X - end.Y);
        //            dy = Math.Abs(start.Y - end.X);
        //            return D * (dx + dy);
        //        case Heuristics.Diagonal:
        //            dx = Math.Abs(start.X - end.Y);
        //            dy = Math.Abs(start.Y - end.X);
        //            return D * (dx + dy) + (D2 - 2 * D) * Math.Min(dx, dy);
        //        case Heuristics.Euclidean:
        //            dx = Math.Abs(start.X - end.Y);
        //            dy = Math.Abs(start.Y - end.X);
        //            return (float) (D * (Math.Sqrt((dx * dy) + (dy* dx))));
        //        default:
        //            throw new Exception("Enter a valid Heuristic!");
        //    }
           
        //}
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

                if (current == endNode)
                {
                    return path;
                }

                for (int j = 0; j < current.Neighbors.Count; j++)
                {
                    if (!current.Neighbors[j].isVisited)
                    {
                        current.Neighbors[j].isVisited = true;
                        queue.Enqueue(current.Neighbors[j].End);
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
