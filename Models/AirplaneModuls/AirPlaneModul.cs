using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    abstract public class AirPlaneModule
    {
        public string ID { get; set; }
        public string Rol;
        public double flightHours;

        public void Fly()
        {
            flightHours += 0.1;
        }
    }
}
