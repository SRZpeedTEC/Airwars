using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    public class Pilot : AirPlaneModul
    {
        public string Rol = "Pilot";
        public Pilot(string id)
        {
            this.ID = id;
        }
    }
}
