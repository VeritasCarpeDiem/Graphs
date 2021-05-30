using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeleteMeHeaps;
using System.Text.Json;
using System.Drawing;

namespace DeleteMeGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<String> graph = new Graph<String>();
            List<String> path = new List<String>();
            //string[] lines = File.ReadAllLines("AirportProblem.txt");

            string connections = File.ReadAllText("AirportProblemEdges.json");
            string verticies = File.ReadAllText("AirportProblemVerticies.json");

            string[] airportsModels = JsonSerializer.Deserialize<string[]>(verticies);
            EdgeModel[] connectionModels = JsonSerializer.Deserialize<EdgeModel[]>(connections);

            for (int i = 0; i < connectionModels.Length; i++)
            {
                Console.WriteLine(connectionModels[i].ToString());
            }
            ;
            foreach(var airport in airportsModels) //add it to the graph
            {
                graph.AddVertex(airport);
            }

            for (int i = 0; i < connectionModels.Length; i++)
            {
                graph.AddEdge(connectionModels[i].Start, connectionModels[i].End, connectionModels[i].Distance);
            }
            ;
            //int startOfConnects = int.Parse(lines[0]) + 1;
            //HashSet<string> airportNames = new HashSet<string>();
            //int i;
            //for (i = 1; i < startOfConnects; i++)
            //{
            //    string[] airports = lines[i].Split(',');
            //    foreach (var airport in airports)
            //    {
            //        airportNames.Add(airport);
            //    }
            //}

            //foreach (var item in airportNames)
            //{
            //    graph.AddVertex(item);
            //}
            //for (; i < lines.Length; i++)
            //{
            //    string[] connection = lines[i].Split(',');

            //    graph.AddEdge(connection[0], connection[1], int.Parse(connection[2]));

            //}

            //var result = graph.Djikstra("STL", "JFK");
            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}

            //path = graph.BFSShortestPathByHops("LAX", "HOU");

            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] names = new string[] { "Sally", "Jin", "Paul" };
            //Foo<string> foo = new Foo<string>(names);

            //foreach (var item in foo)
            //{
            //    Console.WriteLine(item);
            //}

            Graph<Point> graph1;

            graph1.AStar();

            var path = graph.AStar("STL", "JFK");
            foreach(var airport in path)
            {
                Console.WriteLine(airport);
            }
        }

        public class Foo<T> : IEnumerable<T>
        {
            List<T> names;

            public Foo(T[] arr)
            {
                this.names = new List<T>(arr);
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < names.Count; i++)
                {
                    yield return names[i];
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }

    }
}
