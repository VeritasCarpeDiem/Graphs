using DeleteMeHeaps;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeleteMeGraphs
{
    public static class AStar
    {
        public static int DoSomething(Func<string, int> func)
        {
            return func("hello");
        }

        public static int DoSomething2()
        {
            return DoSomething(getLength);
        }

        public static int getLength(string str)
        {
            return str.Length;
        }



        public static IEnumerable<Vertex<Point>> AStarPathFinding(this Graph<Point> graph, Vertex<Point> start, Vertex<Point> end, Func<Vertex<Point>,Vertex<Point>, int> heuristic)
        {

            
            if (!graph.Vertices.Contains(start) && !graph.Vertices.Contains(end))
            {
                return null;
            }
            Comparer<Vertex<Point>> Comparer = Comparer<Vertex<Point>>.Create((x, y) => x.cumulDist.CompareTo(y));
            Heaps<Vertex<Point>> PriorityQueue = new Heaps<Vertex<Point>>(Comparer);
            var dic = new Dictionary<Vertex<Point>, (Vertex<Point> founder, int dist, int finaldist)>();

            //set each vertex to un visited
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                graph.Vertices[i].hasVisited = false;
                dic.Add(graph.Vertices[i], (null, int.MaxValue, int.MaxValue));
            }

            dic[start] = (null, 0, heuristic(start, end));
            PriorityQueue.Push(start);

            while (PriorityQueue.Count > 1)
            {
                var current = PriorityQueue.Pop();
                current.hasVisited = true;
                if (!current.hasVisited)
                {
                    current.hasVisited = true;
                    foreach (var edge in current.Neighbors)
                    {
                        var neighbor = edge.End;
                        int tentativeDist = edge.Dist + dic[current].dist;



                        if (tentativeDist < neighbor.cumulDist && !neighbor.hasVisited)
                        {
                            dic[neighbor] = (current, tentativeDist, tentativeDist + heuristic(edge.End, end));
                            PriorityQueue.Push(neighbor);
                            //  path.Add(current.Value);
                        }
                        if (!PriorityQueue.Contains(neighbor) && !neighbor.hasVisited)
                        {
                            PriorityQueue.Push(neighbor);
                        }
                    }
                }

            }

            return null;
        }
    }
}
