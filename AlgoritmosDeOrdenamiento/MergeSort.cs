using Airwars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
namespace Airwars.AlgoritmosDeOrdenamiento
{
    public class MergeSort
    {
        public static List<Airplane> MergeSortAvionesDerribados(List<Airplane> aviones)
        {
            if (aviones.Count <= 1)
            {
                return aviones;
            }

            int mid = aviones.Count / 2;
            List<Airplane> left = aviones.GetRange(0, mid);
            List<Airplane> right = aviones.GetRange(mid, aviones.Count - mid);

            left= MergeSortAvionesDerribados(left);
            right = MergeSortAvionesDerribados(right);

            return Merge(left, right);
           
        }

        
        private static List<Airplane> Merge(List<Airplane> left, List<Airplane> right)
        {
            List<Airplane> result = new List<Airplane>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                string leftID = left[i].Guid.ToString().Replace("-", "");
                string rightID = right[j].Guid.ToString().Replace("-", "");

                if (string.Compare(leftID, rightID) <= 0)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
            
        }
        
    }
}*/
