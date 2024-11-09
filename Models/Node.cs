using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static readonly Random _random = new Random();

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
            await Task.Delay(5000);

            // Recargar una cantidad aleatoria de combustible entre 150 y 900 unidades
            int fuelToAdd = _random.Next(150, 900);
            airplane.fuel = Math.Min(airplane.fuel + fuelToAdd, 1000);

            Debug.WriteLine($"El avión {airplane.Guid} ha sido recargado con {fuelToAdd} unidades de combustible. Combustible actual: {airplane.fuel}");

            await Task.Run(async () => await airplane.ChooseRandomDestinationAndCalculateRoute());
        }
    }
}
