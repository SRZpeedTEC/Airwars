using Airwars.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Jugador
{
    public class ArmaJugador
    {
        public Point Position { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; }
        public Image Sprite { get; set; }

        


        public ArmaJugador(Point initialPosition, int speed)
        {
            this.Position = initialPosition;
            this.Speed = speed;
            Direction = 1;
            string ImagePath = System.IO.Path.Combine("Resources", "ArmaFinal.png");
            Sprite = Image.FromFile(ImagePath);
            Sprite = new Bitmap(Sprite, new Size(30, 75));
            
        }

        public void Move(int formWidth)
        {

            Position = new Point(Position.X + Speed * Direction, Position.Y);

            // Verifica si ha tocado los bordes
            if (Position.X <= 0 || Position.X + Sprite.Width >= formWidth)
            {
                // Cambia la dirección
                Direction *= -1;
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Sprite, Position);
        }
    }


}
