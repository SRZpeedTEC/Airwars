using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class Route
    {
        public Node destination { get; set; }
        public double weight { get; set; }

        public Route(Node node, double weight)
        {
            this.destination = node;
            this.weight = weight;
        }
    }
}
