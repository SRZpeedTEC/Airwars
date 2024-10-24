using System.Diagnostics;

namespace Airwars
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GameWindow Game_Window = new GameWindow();
            Game_Window.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Prueba de Grafo");
            Pruebas pruebas = new Pruebas();
            pruebas.PruebaGrafo();
        }
    }
}
