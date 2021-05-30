using DeleteMeHeaps;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeleteMeGraphs
{
    public static class Pathfinding
    {
        public static IEnumerable<Vertex<Point>> AStar(this Graph<Point> graph, Vertex<Point> start, Vertex<Point> end, Heuristic heuristic)
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
                            dic[neighbor] = (current, tentativeDist, (int)Heuristic(heuristics, current.Value, neighbor.Value));
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
