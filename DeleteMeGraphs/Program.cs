using System;
using System.Collections.Generic;
using System.IO;


namespace Graphs
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
                
               graph.AddEdge(connection[0], connection[1]);
                
            }
           
            //graph.AddVertex("karan");
            //graph.AddVertex("jin");
            //graph.AddVertex("mikah");
            //graph.AddVertex("chris");


            //graph.AddEdge("karan", "jin");
            //graph.AddEdge("jin", "chris");
            //graph.AddEdge("jin", "mikah");


            //path = graph.BFSPath("karan", "mikah");
            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}
            //;
        }
    }
}
