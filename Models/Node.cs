using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class Node
    {
        public int ID { get; set; }

        public List<Route> Routes = new List<Route>();

        public Point Position { get; set; }

        public int Fuel = 100;

        public Queue<Airplane> Airplanes { get; set; }



        public Node(int id, Point position)
        {
            this.ID = id;
            this.Position = position;
            this.Routes = new List<Route>();
        }

        public void AddRoute(Node node, int weight)
        {
            Routes.Add(new Route(node, weight));
        }
        

    }


}
