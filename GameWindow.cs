using Airwars.Jugador;
using Airwars.Models;
using Airwars.Models.AirplaneModuls;
using Airwars.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airwars
{
    public partial class GameWindow : Form
    {

        private ArmaJugador ArmaJugador;
        private List<Misil> Misiles;
        private System.Windows.Forms.Timer GameTimer;
        private Genericos genericos;
        private Map Mapa;
        public static GameWindow Instance = null;
        public Bitmap ImageMap;

        private DateTime mouseDownTime;

        public static GameWindow GetInstance()
        {
            if (Instance == null)
            {
                Instance = new GameWindow();
            }
            return Instance;
        }

        public GameWindow()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            InitializeGame();

        }

        private void InitializeGame()
        {
            // Inicializa la lista de misiles
            Misiles = new List<Misil>();
            ImageMap = new Bitmap(GameBox.Image);
            Mapa = new Map(ImageMap);
            Mapa.GenerateMap();

            // Inicializa el arma en la posición inferior central del formulario
            Point initialPosition = new Point((GameBox.Width / 2), GameBox.Height - 80);
            int armaSpeed = 5;
            ArmaJugador = new ArmaJugador(initialPosition, armaSpeed);

            // Configura el temporizador del juego
            GameTimer = new System.Windows.Forms.Timer();
            GameTimer.Interval = 20; // Actualiza cada 20 ms 
            GameTimer.Tick += GameLoop;
            GameTimer.Start();

            this.MouseDown += GameBox_MouseDown;
            this.MouseUp += GameBox_MouseUp;

            // Configura el evento de redimensionamiento del formulario
            GameBox.MouseDown += GameBox_MouseDown;
            GameBox.MouseUp += GameBox_MouseUp;

            // Suscribirse al evento Paint del PictureBox
            GameBox.Paint += GameBox_Paint;

            this.Controls.Add(GameBox);


        }

        public void GameLoop(object sender, EventArgs e)
        {
            ArmaJugador.Move(GameBox.Width);

            for (int i = Misiles.Count - 1; i >= 0; i--)
            {
                Misiles[i].Move();

                if (Misiles[i].IsOffScreen(GameBox.Height))
                {
                    Misiles.RemoveAt(i);
                }
                           
            }




            GameBox.Invalidate();

        }


        private void GameBox_Paint(object sender, PaintEventArgs e)
        {

            // Dibuja el arma
            ArmaJugador.Draw(e.Graphics);

            // Dibuja los misiles
            foreach (var misil in Misiles)
            {
                misil.Draw(e.Graphics);
            }

            Mapa.DrawMap(e.Graphics);
            Mapa.DrawRoutes(e.Graphics);

            // Aquí puedes dibujar otros elementos como aviones
        }



        private void GameBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Verificar si el clic ocurrió dentro del PictureBox
                if (GameBox.ClientRectangle.Contains(e.Location))
                {
                    mouseDownTime = DateTime.Now;
                }
            }
        }

        private void GameBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GameBox.ClientRectangle.Contains(e.Location))
                {
                    TimeSpan holdTime = DateTime.Now - mouseDownTime;
                    double holdSeconds = holdTime.TotalSeconds;

                    int missileSpeed = CalculateMissileSpeed(holdSeconds);
                    FireMissile(missileSpeed);
                }
            } 
            
            // Obtener las coordenadas del mouse en el PictureBox al hacer MouseUp
            Point mousePosition = e.Location;

            // Imprimir las coordenadas en consola o hacer algo con ellas
            Debug.WriteLine($"Mouse Up en coordenadas: X = {mousePosition.X}, Y = {mousePosition.Y}");



        }

        private int CalculateMissileSpeed(double holdSeconds)
        {
            // Define la velocidad mínima y máxima del misil
            int minSpeed = 5;
            int maxSpeed = 20;

            // Calcula la velocidad proporcional al tiempo de presionado
            int speed = minSpeed + (int)(holdSeconds * 10);

            // Asegura que la velocidad esté dentro de los límites
            if (speed > maxSpeed)
                speed = maxSpeed;

            return speed;
        }

        private void FireMissile(int speed)
        {
            // Crea un nuevo misil en la posición del arma
            Point misilPosition = new Point(ArmaJugador.Position.X + ArmaJugador.Sprite.Width / 2 - Misil.DefaultWidth / 2, ArmaJugador.Position.Y - Misil.DefaultHeight);
            Misil nuevoMisil = new Misil(misilPosition, speed);
            Misiles.Add(nuevoMisil);
        }

        private void GameCanvas_Resize(object sender, EventArgs e)
        {

            if (ArmaJugador.Position.X + ArmaJugador.Sprite.Width > GameBox.Width)
            {
                ArmaJugador.Position = new Point(GameBox.Width - ArmaJugador.Sprite.Width, ArmaJugador.Position.Y);
            }

        }


        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void GameBox_Click(object sender, EventArgs e)
        {

        }
    }
}
