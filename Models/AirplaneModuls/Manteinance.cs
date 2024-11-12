using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    public class Manteinance : AirPlaneModul
    {          
        
        public Manteinance(string id)
        {
            this.ID = id;
            this.Rol = "Asistance";
        }
    }
}
