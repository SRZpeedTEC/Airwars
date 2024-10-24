using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airwars.Models;

namespace Airwars
{
    internal class Pruebas
    {
        Map Mapa = new Map();

        public Pruebas()
        {
            
        }

        public void PruebaGrafo()
        {
            Mapa.GenerateMap();
        }

    }
}
