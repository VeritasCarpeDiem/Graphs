﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeleteMeHeaps;



namespace DeleteMeGraphs
{
    class Program
    {

        static void Main(string[] args)
        {
           
            //hacked

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


            //path = graph.BFSShortestPathByHops("LAX","HOU");

            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}          

            var result = graph.Djikstra("STL", "JFK");
            foreach (var item in path)
            {
                Console.WriteLine(item);
            }

            path = graph.BFSShortestPathByHops("LAX", "HOU");

            foreach (var item in path)
            {
                Console.WriteLine(item);
            }

            //path = graph.Djikstra("STL", "LAX");
            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}

            string[] names = new string[] { "Sally", "Jin", "Paul" };
            Foo<string> foo = new Foo<string>(names);

            foreach (var item in foo)
            {
                Console.WriteLine(item);
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
