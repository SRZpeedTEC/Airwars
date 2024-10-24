using Airwars.Models.AirplaneModuls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Models
{
    public class Airplane
    {
        private Guid Guid { get; set; }
        public int fuel = 100;
        private int CoolDownFly= 0;

        private Pilot pilot { get; set; }
        private Copilot copilot { get; set; }
        private Manteinance manteinance { get; set; }

        private SpaceAwarness spaceAwarness { get; set; }
    }
}
