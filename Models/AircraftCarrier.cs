using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class AircraftCarrier : Node
    {
        public int HangarCapacity = 20;
        public AircraftCarrier(Point position) : base(position)
        {
            this.Position = position;
        }

        public override void RechargeFuel() // NO IMPLEMENTADO
        {
            foreach (Airplane airplane in Airplanes)
            {
                Console.WriteLine("Recharging fuel for airplane");
            }
        }

    }
}
