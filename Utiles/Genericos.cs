using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Utiles
{
    internal class Genericos
    {
        public Genericos()
        {
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
    }
}
