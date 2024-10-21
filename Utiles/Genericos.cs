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
    }
}
