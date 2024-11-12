using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    public class Copilot : AirPlaneModul
    {
        
        public Copilot(string id)
        {
            this.ID = id;
            this.Rol = "Copilot";
    }
    }
}
