using Airwars.Models.AirplaneModuls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Utiles;

namespace Airwars.Models
{
    public class Airplane
    {
        public Guid Guid { get; set; }
        public int fuel = 100;
        public int CoolDownFly= 0;
        private Genericos genericos = new Genericos();
        public Pilot pilot { get; set; }
        public Copilot copilot { get; set; }
        public Manteinance manteinance { get; set; }
        public SpaceAwarness spaceAwarness { get; set; }
        public Airplane()
        {
            Guid = Guid.NewGuid();
            pilot = new Pilot(genericos.GenerateID(3));
            copilot = new Copilot(genericos.GenerateID(3));
            manteinance = new Manteinance(genericos.GenerateID(3));
            spaceAwarness = new SpaceAwarness(genericos.GenerateID(3));
        }
    }
}
