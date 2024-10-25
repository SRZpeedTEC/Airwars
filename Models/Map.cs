using Airwars.Utiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Airwars.Models
{
    public class Map
    {
        public List<Node> Graph { get; set; }
        public int AirportCount = 10;
        public int AircraftCarrierCount = 10;
        private const int MapWidth = 811;
        private const int MapHeight = 1400;

        public Genericos genericos = new Genericos();      
        Random rand = new Random();

        public Map()
        {
            Graph = new List<Node>();
        }

        public void GenerateMap()
        {
            AddNodes();
            GenerateRoutes();        
        }

        public void AddNodes() // AGREGAR VALIDACIONES MAR O TIERRA
        {
            for (int i = 0; i < AirportCount;)
            {
                int x = rand.Next(50, MapWidth - 50);
                int y = rand.Next(100, MapHeight - 50);
                if (genericos.GetLandType(new Point(x, y)) is Genericos.LandType.Land)
                {
                    Airport newAirport = new Airport(new Point(x, y));
                    Graph.Add(newAirport);
                    i++;
                }                
            }

            for (int i = 0; i < AircraftCarrierCount;)
            {
                int x = rand.Next(50, MapWidth - 50);
                int y = rand.Next(100, MapHeight - 50);
                if (genericos.GetLandType(new Point(x, y)) is Genericos.LandType.Ocean) 
                {
                    AircraftCarrier newAircraftCarrier = new AircraftCarrier(new Point(x, y));
                    Graph.Add(newAircraftCarrier);
                    i++;
                }                  
            }
        }

        public void GenerateRoutes()
        {

            foreach (Node node in Graph)
            {
                List<Node> possibleDestinations = Graph.Where(n => n != node).ToList();
                int numberConnections = rand.Next(2, 4);

                for (int i = 0; i < numberConnections; i++)
                {
                    Node destination = possibleDestinations[rand.Next(0, possibleDestinations.Count)];
                    double weight = genericos.CalculateWeigthRoutes(node, destination);
                    AddRoutes(node, destination, weight);
                    possibleDestinations.Remove(destination);
                }
            }
        }

        public void AddRoutes(Node Origin, Node Destination, double Weight)
        {
            Origin.AddRoute(Destination, Weight);
        }  
        
        public void DrawMap(Graphics g)
        {
            foreach (Node node in Graph)
            {
                Brush brush = node is Airport ? Brushes.Green : Brushes.Blue;
                g.FillEllipse(brush, node.Position.X, node.Position.Y, 10, 10);             
            }
        }

   
    }
}                
   

