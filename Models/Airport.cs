using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;

namespace Airwars.Models
{
    public class Airport : Node
    {
        public int HangarCapacity = 20;
        public Airport(Point position) : base(position)
        {
            this.Position = position;           
        }

        public override void RechargeFuel()    // NO IMPLEMENTADO
        {
            foreach (Airplane airplane in Airplanes)
            {
                Console.WriteLine("Recharging fuel for airplane");
            }
        }

        public void CreateAirplane()
        {
            //Airplane newAirplane = new Airplane(); lo comenté para hacer una prueba xd en todo caso solo hay que meterle al constructor que el airplane tiene como nodo, este nodo del aeropuerto
            //Airplanes.Enqueue(newAirplane);        
        }

    }
}
