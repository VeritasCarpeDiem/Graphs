using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeleteMeGraphs
{
    public delegate int Heuristic(Vertex<Point> start, Vertex<Point> end);

    public static class Heuristics
    {
        public static Heuristic Euclidean(int D) => (start, end) =>
        {
            int dx = Math.Abs(start.Value.X - end.Value.X);
            int dy = Math.Abs(start.Value.Y - end.Value.Y);
            return (int)(D * Math.Sqrt(dx * dx + dy * dy));
        };
    }
}
