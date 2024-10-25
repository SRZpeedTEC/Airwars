using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    abstract public class AirPlaneModul
    {
        public string ID { get; set; }
        public string Rol;
        public int flightHours;

        public void Fly()
        {
            flightHours++;
        }
    }
}
