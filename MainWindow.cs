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
    }
}
