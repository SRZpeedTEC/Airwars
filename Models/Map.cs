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
        public Bitmap ImageMap { get; set; }
        public int AirportCount = 7;
        public int AircraftCarrierCount = 4;
        private const int MapWidth = 1400;
        private const int MapHeight = 811;

        public Genericos genericos;      
        Random rand = new Random();

        public Map(Bitmap ImageMap)
        {
            Graph = new List<Node>();
            this.ImageMap = ImageMap;
            this.genericos = new Genericos(ImageMap);
        }

        public void GenerateMap()
        {
            Debug.WriteLine("Generating map");
            AddNodes();
            Debug.WriteLine("Nodes added");
            GenerateRoutes();    
            Debug.WriteLine("Routes added");
        }

        public void AddNodes() 
        {
            for (int i = 0; i < AirportCount;)
            {
                int x = rand.Next(50, MapWidth - 50);
                int y = rand.Next(200, MapHeight - 50);
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
        public void GenerateMap()
        {
            AddNodes();
            GenerateRoutes();
            PruebaShortestPath();
        }

        public void GenerateRoutes()
        {

            List<Node> unconnectedNodes = Graph.ToList();

            foreach (Node node in Graph)
            {
                List<Node> possibleDestinations = Graph.Where(n => n != node).ToList();
                int numberConnections = rand.Next(1, 2);

                for (int i = 0; i < numberConnections; i++)
                {
                    Node destination = possibleDestinations[rand.Next(0, possibleDestinations.Count)];
                    if (!node.Routes.Any(r => r.destination == destination))
                    {
                        double weight = genericos.CalculateWeigthRoutes(node, destination);
                        AddRoutes(node, destination, weight);
                        AddRoutes(destination, node, weight);
                        possibleDestinations.Remove(destination);
                    }
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

        public void DrawRoutes(Graphics g)
        {
            foreach (var nodo in Graph)
            {
                foreach (var arista in nodo.Routes)
                {
                    // Dibujar línea entre nodos
                    g.DrawLine(Pens.Black, nodo.Position, arista.destination.Position);
                    
                }
            }
        }
                    AircraftCarrier newAircraftCarrier = new AircraftCarrier(new Point(x, y));
                    Graph.Add(newAircraftCarrier);
                    i++;
                }                  
            }

            foreach (Node node in Graph )
            {
                node.AllNodes = Graph;
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

        public void PruebaShortestPath()
        {
            Airplane AvionDePrueba = new Airplane(Graph[0]);
            AvionDePrueba.ChooseRandomDestinationAndCalculateRoute();

        }


   
    }
}                
   

