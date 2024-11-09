using Airwars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Utiles
{
    public class Genericos
    {
        
        public Bitmap? Mapa { get; set; }
        

        
        public Genericos(Bitmap? ImageMap)
        {
            this.Mapa = ImageMap;
        }
        private void ResizeSprite(Image image, int width, int height)
        {
            // Redimensiona la imagen
            Image Sprite;
            Sprite = new Bitmap(image, new Size(width, height));
        }


        public string GenerateID(int length)
        {

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

        public enum LandType
        {
            Ocean,
            Land
        }

        public double CalculateWeigthRoutes(Node origin, Node destination)
        {
            double distance = CalculateDistance(origin, destination);
            double weight = distance;

            // Ajuste por tipo de destino
            if (destination is AircraftCarrier)
            {
                weight *= 1.5; // Más caro aterrizar en portaaviones
            }

            // Ajuste por ruta interoceánica
            if (IsInteroceanicRoute(origin.Position, destination.Position))
            {
                weight *= 1.2; // Más caro si es interoceánica
            }

            return weight;
        }

        public double CalculateDistance(Node origin, Node destination)
        {
            int dx = origin.Position.X - destination.Position.X;
            int dy = origin.Position.Y - destination.Position.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        public LandType GetLandType(Point position) 
        {
                                       
            Color colorPixel = Mapa.GetPixel(position.X, position.Y);

            if (IsWater(colorPixel))
            {
                return LandType.Ocean;
            }
            else
            {
                return LandType.Land;
            }

        }

        public bool IsWater(Color color)
        {
            return color.R < 25 && color.G < 90 && color.G > 70 && color.B < 150 && color.B > 120;
        }

        public bool IsInteroceanicRoute(Point start, Point end) 
        {
            List<Point> puntosEnLinea = BresenhamLine(start.X, start.Y, end.X, end.Y);

            foreach (Point punto in puntosEnLinea)
            {
                if (GetLandType(punto) == LandType.Ocean)
                {
                    return true;
                }
            }

            return false;
        }



        public List<Point> BresenhamLine(int x0, int y0, int x1, int y1)
        {
            HashSet<Point> uniquePoints = new HashSet<Point>();

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                uniquePoints.Add(new Point(x0, y0));

                if (x0 == x1 && y0 == y1)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }

            // Convertir el HashSet a una lista y devolver
            return uniquePoints.ToList();
        }



    }
}
