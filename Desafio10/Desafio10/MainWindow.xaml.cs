using Desafio10;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Desafio10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeJuegos();
        }

        private void InitializeJuegos()
        {
            List<Juego> juegos = new List<Juego>();

            string filePath = "C:\\Users\\LENOVO\\Desktop\\Git Hub\\Programacionl2024\\Desafio10\\Desafio10\\textojuego.txt";

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] datos = line.Split(',');
                if (datos.Length == 5)
                {
                    Juego juego = new Juego()
                    {
                        Eq1 = datos[0],
                        Eq2 = datos[1],
                        Puntaje1 = Convert.ToInt32(datos[2]),
                        Puntaje2 = Convert.ToInt32(datos[3]),
                        Progreso = Convert.ToInt32(datos[4])
                    };
                    juegos.Add(juego);
                }
            }

            lbJuego.ItemsSource = juegos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbJuego.SelectedItem != null)
            {
                MessageBox.Show("Juego Seleccionado: " + (lbJuego.SelectedItem as Juego).Eq1 + " " +
                (lbJuego.SelectedItem as Juego).Puntaje1 + " " + (lbJuego.SelectedItem as Juego).Eq2 + " " + (lbJuego.SelectedItem as Juego).Puntaje2);
            }
        }
    }
}
