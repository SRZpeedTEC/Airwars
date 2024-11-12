using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models.AirplaneModuls
{
    public class SpaceAwarness : AirPlaneModul
    {
        

        public SpaceAwarness(string id)
        {
            this.ID = id;
            this.Rol = "Asistance";
        }
    }
}
