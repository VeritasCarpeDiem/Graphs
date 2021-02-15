using System;
using System.Collections.Generic;
using System.IO;


namespace DeleteMeGraphs
{
    class Program
    {

        static void Main(string[] args)
        {
            Graph<String> graph = new Graph<String>();
            List<String> path = new List<String>();
            string[] lines = File.ReadAllLines("AirportProblem.txt");

            // Read, Parse, and Calculate the distance between LAX and HOU
            //for (int i = 0; i <7; i++)
            //{
            //    graph.AddVertex(lines[i]);
            //    if()
            //    graph.AddEdge();

            //}
            int startOfConnects = int.Parse(lines[0]) + 1;
            HashSet<string> airportNames = new HashSet<string>();
            int i;
            for (i = 1; i < startOfConnects; i++)
            {
                string[] airports = lines[i].Split(',');
                foreach (var airport in airports)
                {
                    airportNames.Add(airport);
                }
            }

            foreach (var item in airportNames)
            {
                graph.AddVertex(item);
            }
            for (; i < lines.Length; i++)
            {
                string[] connection = lines[i].Split(',');

                graph.AddEdge(connection[0], connection[1], int.Parse(connection[2]));

            }

            path = graph.BFSShortestPathByHops("LAX","HOU");

            foreach (var item in path)
            {
                Console.WriteLine(item);
            }

            List<string> reverse = new List<string>();

            for (int j = 0; j < path.Count; j++)
            {
                reverse.Add(path[path.Count - j-1]);
                 
            }
            foreach (var item in reverse)
            {
                Console.WriteLine(item);
            }

            graph.Djikstra("STL", "LAX");
            ;
        }
       
    }
}
