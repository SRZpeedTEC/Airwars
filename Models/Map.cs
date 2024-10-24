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
        Node[] Grafo = new Node[5];
        int[] IDs = { 0, 1, 2, 3, 4 };
        Random rand = new Random();

        public void GenerateMap()
        {

            int x = rand.Next(1, 5);
            int y = rand.Next(1, 5);

            for (int i = 0; i < Grafo.Length; i++)
            {
                Grafo[i] = new Node(i, new Point(x, y));
                Debug.WriteLine("Nodo: " + Grafo[i].ID + " Posicion: " + Grafo[i].Position.X + "," + Grafo[i].Position.Y);
            }

            
            foreach (Node node in Grafo)
            {
                int routes = rand.Next(1, 3);
                List<int> possibleRoutes = IDs.Where(id => id != node.ID).ToList(); // Rutas posibles

                for (int i = 0; i < routes; i++)
                {
                    if (possibleRoutes.Count == 0) break;

                    int RouteRandom = rand.Next(0, possibleRoutes.Count);
                    int routeID = possibleRoutes[RouteRandom]; 

                    
                    Node destinationNode = Grafo.FirstOrDefault(n => n.ID == routeID);
                    if (destinationNode != null)
                    {
                        int peso = rand.Next(1, 25);
                        node.AddRoute(destinationNode, peso);
                    }

                    possibleRoutes.Remove(routeID); 
                }
            }

            // Mostrar las rutas generadas
            foreach (Node node in Grafo)
            {
                foreach (Route route in node.Routes)
                {
                    Debug.WriteLine($"El nodo {node.ID} tiene ruta hacia {route.destination.ID}");
                }
            }
        }
    }







}                
   

