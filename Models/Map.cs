using Airwars.Utiles;
using System;
using System.Collections.Concurrent;
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

        public List<Airplane> AirplanesInMap { get; set; }
        public List<Airport> AirportsInMap { get; set; }
        public List<Airplane> DownedPlanes = new List<Airplane>();

        public Genericos genericos;
        Random rand = new Random();

        

        

        public Map(Bitmap ImageMap)
        {
            Graph = new List<Node>();
            this.ImageMap = ImageMap;
            this.genericos = new Genericos(ImageMap);
            AirplanesInMap = new List<Airplane>();
            AirportsInMap = new List<Airport>();
            
        }

        public void GenerateMap()
        {
            Debug.WriteLine("Generating map");
            AddNodes();
            Debug.WriteLine("Nodes added");
            GenerateRoutes();
            Debug.WriteLine("Routes added");
            _ = StartAirplaneGenerators();



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
                    AirportsInMap.Add(newAirport);
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
            foreach (Node node in Graph)
            {
                node.AllNodes = Graph;
            }
        }

        public void GenerateRoutes()
        {
            List<Node> unconnectedNodes = Graph.ToList(); // Lista de nodos sin conectar
            List<Node> connectedNodes = new List<Node>(); // Nodos ya conectados

            
            if (unconnectedNodes.Count > 0)
            {
                connectedNodes.Add(unconnectedNodes[0]);
                unconnectedNodes.RemoveAt(0);
            }

            Random rand = new Random();

            
            while (unconnectedNodes.Count > 0)
            {
                Node node = unconnectedNodes[0]; 
                Node connectedNode = connectedNodes[rand.Next(connectedNodes.Count)]; 

                
                if (!node.Routes.Any(r => r.destination == connectedNode))
                {
                    double weight = genericos.CalculateWeigthRoutes(node, connectedNode);
                    AddRoutes(node, connectedNode, weight);
                    AddRoutes(connectedNode, node, weight);
                }

                
                connectedNodes.Add(node);
                unconnectedNodes.RemoveAt(0);
            }

            
            foreach (Node node in Graph)
            {
                List<Node> possibleDestinations = Graph.Where(n => n != node).ToList();
                int numberConnections = 1; // Número de conexiones adicionales deseadas por nodo

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

        public async Task StartAirplaneGenerators()
        {
            Random rand = new Random();

            while (true) // Bucle infinito para generar aviones continuamente
            {
                // Retraso aleatorio entre 1 y 5 segundos
                int delay = rand.Next(1000, 5000);
                await Task.Delay(delay); // No bloquea la UI

                
                Airport randomAirport = AirportsInMap[rand.Next(AirportsInMap.Count)];

                if (randomAirport.HangarCapacity > 0)
                {
                    // Crear un nuevo avión y manejarlo asincrónicamente
                    Airplane newAirplane = randomAirport.CreateAirplane();
                    await Task.Run(() => newAirplane.ChooseRandomDestinationAndCalculateRoute());
                    AirplanesInMap.Add(newAirplane);
                }
            }
        }






    }
}
