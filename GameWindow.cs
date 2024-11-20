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
        private int totalGameTime = 40;
        private int timeRemaining;
        private bool showroutes = false;
        private System.Windows.Forms.Timer gameTimeTimer;
        private DateTime lastMissileFireTime;
        private Genericos genericos;
        private Map Mapa;
        private int DownedAirplanes = 0;
        public static GameWindow Instance = null;
        public InformacionExtra informacionExtra;
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
            // Configura los controles y eventos solo una vez
            this.MouseDown += GameBox_MouseDown;
            this.MouseUp += GameBox_MouseUp;

            GameBox.MouseDown += GameBox_MouseDown;
            GameBox.MouseUp += GameBox_MouseUp;
            lastMissileFireTime = DateTime.MinValue;


            GameBox.Paint += GameBox_Paint;

            this.Controls.Add(GameBox);

            // Configura los temporizadores solo una vez
            GameTimer = new System.Windows.Forms.Timer();
            GameTimer.Interval = 30; // Actualiza cada 30 ms
            GameTimer.Tick += GameLoop;

            gameTimeTimer = new System.Windows.Forms.Timer();
            gameTimeTimer.Interval = 1000; // Se dispara cada 1 segundo
            gameTimeTimer.Tick += GameTimeTimer_Tick;

            // Llamar a ResetGame para inicializar el estado del juego
            ResetGame();
        }


        public void GameLoop(object sender, EventArgs e)
        {
            ArmaJugador.Move(GameBox.Width);

            for (int i = Misiles.Count - 1; i >= 0; i--)
            {
                Misiles[i].Move();
                bool missileRemoved = false;

                foreach (Airplane avion in Mapa.AirplanesInMap)
                {

                    if (avion.inRoute && Misiles[i].CheckCollision(avion.Hitbox))
                    {
                        Misiles.RemoveAt(i);
                        avion.fuel = 0;
                        avion.checkIsDestroyed();
                        Debug.WriteLine($"El avión de ID {avion.Guid} ha sido destruido");
                        informacionExtra.AirplaneSortedList.Add(avion);
                        informacionExtra.UpdateData();
                        Mapa.DownedPlanes.Add(avion);
                        DownedAirplanes++;
                        UpdateScore();

                        missileRemoved = true;
                        break; // Salir del bucle de aviones, ya que el misil ha sido eliminado
                    }
                }

                if (missileRemoved)
                {
                    continue; // Saltar a la siguiente iteración del bucle de misiles
                }

                if (Misiles[i].IsOffScreen(GameBox.Height))
                {
                    Misiles.RemoveAt(i);
                }
            }

            List<Airplane> airplanesCopy = new List<Airplane>(Mapa.AirplanesInMap);
            foreach (Airplane avion in airplanesCopy)
            {
                if (avion.fuel != 0 && !avion.isDestroyed)
                {
                    avion.MoveAlongPath();
                }
                else
                {

                    Mapa.AirplanesInMap.Remove(avion);
                    Debug.WriteLine($"El avión de ID {avion.Guid} se ha quedado sin combustible"); //si fuese necesario añadir una lista de aviones muertos, habria que agregarle este avion aqui
                }
            }


            GameBox.Invalidate();

        }

        private void GameTimeTimer_Tick(object sender, EventArgs e)
        {
            // Decrementar el tiempo restante
            timeRemaining--;

            // Actualizar el Label del tiempo en pantalla
            UpdateTimeLabel();

            // Verificar si el tiempo se ha agotado
            if (timeRemaining <= 0)
            {
                // Detener los temporizadores
                GameTimer.Stop();
                gameTimeTimer.Stop();

                // Mostrar pantalla de fin de juego o mensaje
                GameOver();
            }
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
            if (showroutes)
            {
                Mapa.DrawRoutes(e.Graphics);
            }

            // Aquí puedes dibujar otros elementos como aviones
            foreach (Airplane avion in Mapa.AirplanesInMap) 

            {
                if (avion.inRoute)
                {
                    avion.Draw(e.Graphics);
                }
            }




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

                    // Comprobar si han pasado 2.5 segundos desde el último disparo
                    TimeSpan timeSinceLastFire = DateTime.Now - lastMissileFireTime;
                    if (timeSinceLastFire.TotalSeconds >= 1)
                    {
                        int missileSpeed = CalculateMissileSpeed(holdSeconds);
                        FireMissile(missileSpeed);

                        // Actualizar el tiempo del último disparo
                        lastMissileFireTime = DateTime.Now;
                    }
                    else
                    {
                        // Opcional: Notificar al jugador que aún no puede disparar
                        // Por ejemplo, mostrar un mensaje o reproducir un sonido
                        Debug.WriteLine("¡Debes esperar 2.5 segundos antes de disparar de nuevo!");
                    }
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


        private void UpdateScore()
        {
            label1.Text = $"Aviones derribados: {DownedAirplanes}";
        }

        private void UpdateTimeLabel()
        {
            lbltimer.Text = $"Tiempo restante: {timeRemaining}s";
        }

        private void GameOver()
        {

            DialogResult finalMessage = MessageBox.Show($"¡Se acabó el tiempo!\nTu puntuacion obtenida fue de: {DownedAirplanes}\n¿Quieres reiniciar?.", "Fin del juego", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (finalMessage == DialogResult.Yes)
            {
                ResetGame();
            }
            else
            {
                this.Close();
            }

        }

        private void ResetGame()
        {
            // Restablecer variables del juego
            Misiles = new List<Misil>();
            ImageMap = new Bitmap(GameBox.Image);
            Mapa = new Map(ImageMap);
            informacionExtra = InformacionExtra.GetInstance();
            Mapa.GenerateMap();

            // Inicializar el arma en la posición inicial
            Point initialPosition = new Point((GameBox.Width / 2), GameBox.Height - 80);
            int armaSpeed = 5;
            ArmaJugador = new ArmaJugador(initialPosition, armaSpeed);

            // Reiniciar variables de juego
            timeRemaining = totalGameTime;
            DownedAirplanes = 0;
            UpdateScore();
            UpdateTimeLabel();
            informacionExtra.clearData();
            informacionExtra.ClearMessages();
            informacionExtra.clearAirplaneOptions();

            // Reiniciar y comenzar los temporizadores
            GameTimer.Stop();
            GameTimer.Start();

            gameTimeTimer.Stop();
            gameTimeTimer.Start();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInfoAdicional_Click(object sender, EventArgs e)
        {
            InformacionExtra informacionExtra = InformacionExtra.GetInstance();
            informacionExtra.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.showroutes = !showroutes;
        }
    }
}
