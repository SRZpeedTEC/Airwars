using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class Node
    {
        public List<Route> Routes = new List<Route>();
        public List<Node> AllNodes { get; set; }
        public Point Position { get; set; }
        public int Fuel { get; set; }
        public Queue<Airplane> Airplanes = new Queue<Airplane>();

        public Node(Point position)
        {
            this.Position = position;
            this.Fuel = 100;
        }

        public virtual void RechargeFuel()
        {
            // Implementar lógica adicional si es necesario
        }

        public void AddRoute(Node node, double weight)
        {
            Routes.Add(new Route(node, weight));
        }

        public virtual void GenerateAirplane()
        {

        }

        public async Task HandleAirplane(Airplane airplane)
        {
            // Simular el tiempo de espera en el nodo (por ejemplo, 2 segundos)
            await Task.Delay(2000);

            // Recargar una cantidad aleatoria de combustible entre 10 y 50 unidades
            Random random = new Random();
            int fuelToAdd = random.Next(10, 51); // Entre 10 y 50
            airplane.fuel = Math.Min(airplane.fuel + fuelToAdd, 100); // Limitar a un máximo de 100

            Console.WriteLine($"El avión {airplane.Guid} ha sido recargado con {fuelToAdd} unidades de combustible. Combustible actual: {airplane.fuel}");

            
            airplane.ChooseRandomDestinationAndCalculateRoute();
        }
    }
}
