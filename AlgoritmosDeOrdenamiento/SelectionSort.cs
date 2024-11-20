using Airwars.Models.AirplaneModuls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.AlgoritmosDeOrdenamiento
{
    public class SelectionSort
    {
        public static List<AirPlaneModule> SelectionSortTripulacion(List<AirPlaneModule> tripulacion, string criterio)
        {
            int n = tripulacion.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    bool condition = false;
                    switch (criterio.ToLower())
                    {
                        case "id":
                            condition = string.Compare(tripulacion[j].ID, tripulacion[min_idx].ID) < 0;
                            break;
                        case "rol":
                            condition = string.Compare(tripulacion[j].Rol, tripulacion[min_idx].Rol) < 0;
                            break;
                        case "flighthours":
                            condition = tripulacion[j].flightHours < tripulacion[min_idx].flightHours;
                            break;
                    }

                    if (condition)
                    {
                        min_idx = j;
                    }
                }

                if (min_idx != i)
                {
                    AirPlaneModule temp = tripulacion[min_idx];
                    tripulacion[min_idx] = tripulacion[i];
                    tripulacion[i] = temp;
                }
            }
            return tripulacion;
        }
    }
}
