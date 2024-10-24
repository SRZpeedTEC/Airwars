using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;

namespace Airwars.Models
{
    public class Airport : Node
    {
        public int HangarCapacity = 20;
        public Airport(int id, Point position) : base(id, position)
        {
            this.ID = id;
            this.Position = position;           
        }

        public void RechargeFuel()
        {
            foreach (Airplane airplane in Airplanes)
            {
                Console.WriteLine("Recharging fuel for airplane");
            }
        }

        public void CreateAirplane()
        {
            Airplane newAirplane = new Airplane();
            Airplanes.Enqueue();
        }

    }
}
