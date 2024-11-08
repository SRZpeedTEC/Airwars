using Airwars.Models.AirplaneModuls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;
using System.Diagnostics;

namespace Airwars.Models
{
    public class Airplane
    {
        public Guid Guid { get; set; }
        public int fuel = 100;
        public int CoolDownFly= 0;
        private Genericos genericos = new Genericos(null);


        public bool inRoute = false; //Determina si el avión ya tiene una nodo destino 
        public List<Node> ShortestPath { get; private set; } = new List<Node>();

        public Node CurrentNode { get; set; }
        public Point Position { get; set; }

        public Pilot pilot { get; set; }
        public Copilot copilot { get; set; }
        public Manteinance manteinance { get; set; }
        public SpaceAwarness spaceAwarness { get; set; }
        public List<AirPlaneModul> Tripulacion { get; set; }
        public Airplane(Node currentNode)
        {
            Guid = Guid.NewGuid();
            pilot = new Pilot(genericos.GenerateID(3));
            copilot = new Copilot(genericos.GenerateID(3));
            manteinance = new Manteinance(genericos.GenerateID(3));
            spaceAwarness = new SpaceAwarness(genericos.GenerateID(3));
            Tripulacion = new List<AirPlaneModul> { pilot, copilot, manteinance, spaceAwarness };
            
            CurrentNode = currentNode;
            Position = currentNode.Position;
        }


        public void ChooseRandomDestinationAndCalculateRoute()
        {
            Random rand = new Random();
            Node DestinationNode = CurrentNode.AllNodes[rand.Next(CurrentNode.AllNodes.Count)];

            if (DestinationNode != CurrentNode)
            {
                CalculateShortestPathTo(DestinationNode);
            }
            else
            {
                ChooseRandomDestinationAndCalculateRoute();
            }
            // Agregar Debug después de calcular la ruta
            Debug.WriteLine($"El avión de prueba se encuentra en {CurrentNode.Position} y quiere ir al nodo {DestinationNode.Position}");

            if (ShortestPath.Count > 0)
            {
                Debug.WriteLine("La ruta a seguir es:");
                double totalWeight = 0;

                for (int i = 0; i < ShortestPath.Count - 1; i++)
                {
                    Node current = ShortestPath[i];
                    Node next = ShortestPath[i + 1];
                    var route = current.Routes.FirstOrDefault(r => r.destination == next);

                    if (route != null)
                    {
                        Debug.WriteLine($"  - De {current.Position} a {next.Position} con peso {route.weight}");
                        totalWeight += route.weight;
                    }
                }

                Debug.WriteLine($"Peso total de la ruta: {totalWeight}");
            }
            else
            {
                Debug.WriteLine("No se encontró una ruta.");
            }
        }

        private void CalculateShortestPathTo(Node destination)
        {
            var distances = new Dictionary<Node, double>();       // Guardar distancias mínimas
            var previousNodes = new Dictionary<Node, Node>();     // Guardar el nodo previo en el camino más corto
            var unvisitedNodes = new List<Node>(CurrentNode.AllNodes);

            foreach (var node in unvisitedNodes)
            {
                distances[node] = double.MaxValue;
            }
            distances[CurrentNode] = 0;

            while (unvisitedNodes.Count > 0)
            {
                
                Node closestNode = null;
                double shortestDistance = double.MaxValue;
                foreach (var node in unvisitedNodes)
                {
                    if (distances[node] < shortestDistance)
                    {
                        shortestDistance = distances[node];
                        closestNode = node;
                    }
                }

                if (closestNode == null)
                    break;

                unvisitedNodes.Remove(closestNode);

                
                foreach (var route in closestNode.Routes)
                {
                    Node neighbor = route.destination;
                    double tentativeDistance = distances[closestNode] + route.weight;

                    if (tentativeDistance < distances[neighbor])
                    {
                        distances[neighbor] = tentativeDistance;
                        previousNodes[neighbor] = closestNode;
                    }
                }

                
                if (closestNode == destination)
                {
                    break;
                }
            }

            // Reconstruir la ruta más corta
            ShortestPath.Clear();
            for (Node at = destination; at != null; at = previousNodes.ContainsKey(at) ? previousNodes[at] : null)
            {
                ShortestPath.Insert(0, at);
            }
        }


        public void MoveAlongPath()
        {
            if (ShortestPath.Count > 0)
            {
                Node nextNode = ShortestPath[1]; // El siguiente nodo a alcanzar
                List<Point> puntosRuta = genericos.BresenhamLine(Position.X, Position.Y, nextNode.Position.X, nextNode.Position.Y);

                foreach (var punto in puntosRuta)
                {
                    Position = punto;
                    // Agregar logica de refescamiento del mapa
                    

                    System.Threading.Thread.Sleep(50); // ajustar el tiempo 
                    Debug.WriteLine($"Avión en camino al nodo en posicion {nextNode.Position} actualmente en {Position} .");
                }

                
                CurrentNode = nextNode;
                ShortestPath.RemoveAt(0);

                if (ShortestPath.Count == 0) // El avión llegó a su destino
                {
                    inRoute = false;
                    Debug.WriteLine("El avión ha llegado a su destino.");
                }
            }
            else
            {
                Debug.WriteLine("No hay ruta calculada.");
            }
        }


    }
}
