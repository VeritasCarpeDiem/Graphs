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
         
    
            for (int i = 1; i <6; i++)
            {
                graph.AddVertex(lines[i]);
                lines[i]
               
            }
           

           
            

            graph.AddVertex("karan");
            graph.AddVertex("jin");
            graph.AddVertex("mikah");
            graph.AddVertex("chris");


            graph.AddEdge("karan", "jin");
            graph.AddEdge("jin", "chris");
            graph.AddEdge("jin", "mikah");


            path = graph.BFSPath("karan", "mikah");
            foreach (var item in path)
            {
                Console.WriteLine(item);
            }
            ;
        }
    }
}
