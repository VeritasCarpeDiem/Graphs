using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMeGraphs
{
    class EdgeModel
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Distance { get; set; }

        public EdgeModel()//empty contructor for json serialization
        {
            

        }
        public EdgeModel(string start, string end, int distance)
        { 
            Start = start;
            End = end;
            Distance = distance;
        }

        public override string ToString()
        {
           return  $"Edge: Start:{Start}, End:{End}, Distance:{Distance}";
        }

    }
}
