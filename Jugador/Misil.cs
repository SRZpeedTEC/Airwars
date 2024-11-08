using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airwars.Jugador
{
    internal class Misil
    {
        public static int DefaultWidth { get; } = 25;
        public static int DefaultHeight { get; } = 50;

        public Point Position { get; set; }
        
        public int Speed { get; set; }
        public Image Sprite { get; set; }

        public Misil(Point initialposition, int speed)
        {
            this.Position = initialposition;
            this.Speed = speed;
            string ImagePath = System.IO.Path.Combine("Resources", "misil.png");
            Sprite = Image.FromFile(ImagePath);
            Sprite = new Bitmap(Sprite, new Size(DefaultWidth, DefaultHeight));

        }

        public void Move()
        {
            Position = new Point(Position.X, Position.Y - Speed);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Sprite, Position);
        }

        public bool IsOffScreen(int screenHeight)
        {
            return Position.Y + Sprite.Height < 0;
        }

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(Position.X, Position.Y, Sprite.Width, Sprite.Height);
            }
        }
        public bool CheckCollision(Rectangle other)
        {
            return this.Hitbox.IntersectsWith(other);
        }

    }
}
