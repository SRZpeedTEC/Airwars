using Airwars.Models.AirplaneModuls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;
using System.Diagnostics;
using System.Security.Policy;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using Airwars.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airwars.Models
{
    public class Airplane
    {
        public Guid Guid { get; set; }
        public int fuel = 1500;
        public int CoolDownFly= 0;
        public bool isDestroyed = false;
        public InformacionExtra informacionExtra;
        private Genericos genericos = new Genericos(null);
        private static readonly Random _random = new Random();


        public static int Width { get; } = 25;
        public static int Height { get; } = 50;
        private Image avionImagen;


        public bool inRoute = false; //Determina si el avión ya tiene una nodo destino 
        public List<Node> ShortestPath { get; private set; } = new List<Node>();

        public List<Point> RutaActual { get; private set; }

        public Node CurrentNode { get; set; }

        public Node NextNodeInRoute {  get; set; }
        public Point Position { get; set; }

        public Pilot pilot { get; set; }
        public Copilot copilot { get; set; }
        public Manteinance manteinance { get; set; }
        public SpaceAwarness spaceAwarness { get; set; }

        public List<AirPlaneModule> Tripulacion { get; set; }

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(Position.X, Position.Y, avionImagen.Width, avionImagen.Height);
            }
        }

        public Airplane(Node currentNode)
        {
            Guid = Guid.NewGuid();
            pilot = new Pilot(genericos.GenerateID(3));
            copilot = new Copilot(genericos.GenerateID(3));
            manteinance = new Manteinance(genericos.GenerateID(3));
            spaceAwarness = new SpaceAwarness(genericos.GenerateID(3));
            Tripulacion = new List<AirPlaneModule> { pilot, copilot, manteinance, spaceAwarness };
            CurrentNode = currentNode;
            Position = currentNode.Position;
            string ImagePath = System.IO.Path.Combine("Resources", "Avion.png");
            avionImagen = Image.FromFile(ImagePath);
            avionImagen = new Bitmap(avionImagen, new Size(Width, Height));
            informacionExtra = InformacionExtra.GetInstance();
        }


        public async Task ChooseRandomDestinationAndCalculateRoute()
        {
            
            List<Node> AllNodes = CurrentNode.AllNodes;
            List<Node> AllNodesToVisit = AllNodes.Where(n => n != CurrentNode).ToList();
            Node destinationNode = AllNodesToVisit[_random.Next(AllNodesToVisit.Count)];

            await CalculateShortestPathTo(destinationNode);

            if (ShortestPath.Count > 0)
            {
                Node nextNode = ShortestPath[1];
                RutaActual = genericos.BresenhamLine(Position.X, Position.Y, nextNode.Position.X, nextNode.Position.Y);
                inRoute = true;

                string message = $"El avión {this.Guid} se encuentra en {CurrentNode.Position} y se dirige al nodo {destinationNode.Position}";
                sendMessage(message);
                Debug.WriteLine(message);

                double totalWeight = 0;
                for (int i = 0; i < ShortestPath.Count - 1; i++)
                {
                    Node current = ShortestPath[i];
                    Node next = ShortestPath[i + 1];
                    var route = current.Routes.FirstOrDefault(r => r.destination == next);

                    if (route != null)
                    {

                        string message2 = $" El avión {this.Guid} ira de {current.Position} a {next.Position} con peso {route.weight}";
                        sendMessage(message2);
                        Debug.WriteLine(message2);
                        totalWeight += route.weight;
                    }
                }
                string message3 = $"Peso total de la ruta del avion {this.Guid}: {totalWeight}";
                sendMessage(message3);
                Debug.WriteLine(message3);
            }
            else
            {
                Debug.WriteLine("No se encontró una ruta.");
            }
        }

        private async Task CalculateShortestPathTo(Node destination)
        {
            await Task.Run(() =>
            {
                var distances = new Dictionary<Node, double>();
                var previousNodes = new Dictionary<Node, Node>();
                var priorityQueue = new PriorityQueue<Node, double>();

                foreach (var node in CurrentNode.AllNodes)
                {
                    distances[node] = double.MaxValue;
                }
                distances[CurrentNode] = 0;
                priorityQueue.Enqueue(CurrentNode, 0);

                while (priorityQueue.Count > 0)
                {
                    Node currentNode = priorityQueue.Dequeue();

                    if (currentNode == destination)
                        break;

                    foreach (var route in currentNode.Routes)
                    {
                        Node neighbor = route.destination;
                        double tentativeDistance = distances[currentNode] + route.weight;

                        if (tentativeDistance < distances[neighbor])
                        {
                            distances[neighbor] = tentativeDistance;
                            previousNodes[neighbor] = currentNode;
                            priorityQueue.Enqueue(neighbor, tentativeDistance);
                        }
                    }
                }

                // Reconstruir la ruta más corta
                ShortestPath.Clear();
                for (Node at = destination; at != null; at = previousNodes.ContainsKey(at) ? previousNodes[at] : null)
                {
                    ShortestPath.Insert(0, at);
                }
            });
        }


        public async void MoveAlongPath()
        {
            
                if (inRoute)
                {



                    if (ShortestPath.Count > 0)
                    {



                        if (ShortestPath.Count == 1) // El avión llegó a su destino
                        {
                            inRoute = false;
                            await CurrentNode.HandleAirplane(this);
                            Debug.WriteLine("El avión ha llegado a su destino.");
                            fuel--;
                            return;
                        }

                        Node nextNode = ShortestPath[1]; // El siguiente nodo a alcanzar
                        NextNodeInRoute = nextNode;


                        if (Position == nextNode.Position)
                        {
                            ShortestPath.RemoveAt(1);
                            RutaActual = genericos.BresenhamLine(Position.X, Position.Y, nextNode.Position.X, nextNode.Position.Y);
                            fuel--;
                            return;
                        }


                        RutaActual = genericos.BresenhamLine(Position.X, Position.Y, nextNode.Position.X, nextNode.Position.Y);

                        Position = RutaActual[1];
                        fuel--;
                        foreach (AirPlaneModule module in Tripulacion)
                        {
                        module.Fly();
                        }
                        RutaActual.RemoveAt(0);


                        CurrentNode = nextNode;


                    }
                }
                else
                {
                    //Debug.WriteLine($"No hay ruta calculada para el avion de ID: {Guid} .");
                }
            
            

        }

        public void checkIsDestroyed()
        {
            isDestroyed = true;
        }
            
        public void Draw(Graphics g)
        {
            if (NextNodeInRoute == null)
                return;

           
            float deltaX = NextNodeInRoute.Position.X - Position.X;
            float deltaY = NextNodeInRoute.Position.Y - Position.Y;
            float angle = (float)(Math.Atan2(deltaY, deltaX) * (180 / Math.PI)) + 90;

            
            GraphicsState state = g.Save();

            
            g.TranslateTransform(Position.X, Position.Y);
            
            g.RotateTransform(angle);
            
            g.DrawImage(avionImagen, -avionImagen.Width / 2, -avionImagen.Height / 2);

            
            g.Restore(state);
        }

        public void sendMessage(string message)
        {
            informacionExtra.AddMessage(message);
        }


    }
}
