using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Airwars.Models
{
    public class Map
    {
        Node[] Grafo = new Node[5];
        int[] IDs = { 1, 2, 3, 4, 5 };
        Random rand = new Random();



        public void GenerateMap()
        {
            int x = rand.Next(1, 5);
            int y = rand.Next(1, 5);

            for (int i = 0; i < Grafo.Length; i++)
            {
                Grafo[i] = new Node(i, new Point(x, y));
                Console.WriteLine("Nodo: " + Grafo[i].ID + " Posicion: " + Grafo[i].Position.X + "," + Grafo[i].Position.Y);
            }


            foreach (Node Node in Grafo)
            {
                Random random = new Random();
                int Routes = random.Next(1, 5); //Rutas para este nodo 

                int[] PossibleRoutes= IDs.Where(id => id != Node.ID).ToArray();

                for (int i = 0; i < Routes; i++)
                {
                    int Route = random.Next(1, Routes); //Posicion de la lista del Nodo al que se le esta asociando
                    int Peso = random.Next(1, 25);

                    Node.AddRoute(Grafo[Route], Peso);

                    PossibleRoutes = IDs.Where(id => id != Route).ToArray();


                }

            }

            foreach (Node Node in Grafo)
            {
                foreach (Route Ruta in Node.Routes )
                {

                    Console.WriteLine($"El nodo {Node.ID} tiene ruta hacia {Ruta.destination.ID}");
                }
            }
            

        }






    }                

    }
}
