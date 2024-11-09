using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;

namespace Airwars.Models
{
    using System.Threading.Tasks;

    public class Airport : Node
    {
        public int HangarCapacity = 20;
        private bool generatingAirplanes = false; // Controla si se están generando aviones
        

        public Airport(Point position) : base(position)
        {
            this.Position = position;
            
        }

        public override void RechargeFuel()
        {
            foreach (Airplane airplane in Airplanes)
            {
                Console.WriteLine("Recharging fuel for airplane");
            }
        }

        public Airplane CreateAirplane()
        {
            
            Airplane newAirplane = new Airplane(this);
            HangarCapacity--;
            return newAirplane;

        }

        
    }
}
