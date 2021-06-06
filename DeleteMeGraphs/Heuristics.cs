using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DeleteMeGraphs
{


    public delegate int Heuristic(Vertex<Point> start, Vertex<Point> end);

    public static class Heuristics
    {
        const float SQUARE_ROOT_OF_2 = 1.414213562373095f;
        public static Func<Vertex<Point>, Vertex<Point>, int> Euclidean(int D=1) => (start, end) =>
        {
            int dx = Math.Abs(start.Value.X - end.Value.X);
            int dy = Math.Abs(start.Value.Y - end.Value.Y);
            return (int)(D * Math.Sqrt(dx * dx + dy * dy));
        };

        public static Func<Vertex<Point>, Vertex<Point>, float> Diagonal( int D=1, float D2 = SQUARE_ROOT_OF_2) => (start, end) =>
        {
            int dx = Math.Abs(start.Value.X - end.Value.X);
            int dy = Math.Abs(start.Value.Y - end.Value.Y);
            return D * (dx + dy) + (D2 - 2 * D) * Math.Min(dx, dy);
        };

        public static Func<Vertex<Point>, Vertex<Point>, int> Manhattan(int D=1)
        {
            return (start, end) =>
            {
                int dx = Math.Abs(start.Value.X - end.Value.X);
                int dy = Math.Abs(start.Value.Y - end.Value.Y);
                return D * (dx + dy);
            };
        }

    }

    
}
