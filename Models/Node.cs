﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class Node
    {     

        public List<Route> Routes = new List<Route>();

        public List<Node> AllNodes { get; set; }

        public Point Position { get; set; }

        public int Fuel  { get; set; }

        public Queue<Airplane> Airplanes = new Queue<Airplane>();



        public Node(Point position)
        {                     
            this.Position = position;
            this.Fuel = 100;
        }

        public virtual void RechargeFuel() 
        { 

        }
        

        public void AddRoute(Node node, double weight)
        {
            Routes.Add(new Route(node, weight));
        }
        

    }


}
