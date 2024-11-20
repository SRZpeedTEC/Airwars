using Airwars.Utiles;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



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
            foreach (var node in Graph)
            {
                foreach (var route in node.Routes)
                {
                    // Dibuja la línea de la ruta
                    Pen pen = new Pen(Color.Gray, 1);
                    g.DrawLine(pen, node.Position, route.destination.Position);

                    
                        // Calcula el punto medio de la línea para colocar el peso
                        Point start = node.Position;
                        Point end = route.destination.Position;

                        int midX = (start.X + end.X) / 2;
                        int midY = (start.Y + end.Y) / 2;

                        // Crea una fuente y un pincel para el texto
                        Font font = new Font("Arial", 8);
                        Brush brush = Brushes.Black;

                        // Prepara el texto del peso
                        string weightText = route.weight.ToString("F1"); // Formato con un decimal

                        // Dibuja el texto del peso en el punto medio
                        g.DrawString(weightText, font, brush, midX, midY);
                    
                }
            }
        }


        public async Task StartAirplaneGenerators()
        {
            Random rand = new Random();

            while (true) // Bucle infinito para generar aviones continuamente
            {
                if (AirplanesInMap.Count < 10)
                {

                    int delay = rand.Next(1000, 5000);
                    await Task.Delay(delay);


                    Airport randomAirport = AirportsInMap[rand.Next(AirportsInMap.Count)];

                    if (randomAirport.HangarCapacity > 0)
                    {
                        // Crear un nuevo avión y manejarlo asincrónicamente
                        Airplane newAirplane = randomAirport.CreateAirplane();
                        await Task.Run(() => newAirplane.ChooseRandomDestinationAndCalculateRoute());
                        AirplanesInMap.Add(newAirplane);
                    }
                }
                else
                {

                    int delay = rand.Next(7000, 15000);
                    await Task.Delay(delay);


                    Airport randomAirport = AirportsInMap[rand.Next(AirportsInMap.Count)];

                    if (randomAirport.HangarCapacity > 0)
                    {

                        Airplane newAirplane = randomAirport.CreateAirplane();
                        await Task.Run(() => newAirplane.ChooseRandomDestinationAndCalculateRoute());
                        AirplanesInMap.Add(newAirplane);
                    }

                }
            }
        }






    }
}
