using Desafio10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desafio10
{
    /// <summary>
    /// Interaction logic for WindowListBox.xaml
    /// </summary>
    public partial class WindowListBox : Window
    {
        public WindowListBox()
        {
            InitializeComponent();
            List<Juego> juegos = new List<Juego>();
            juegos.Add(new Juego { Eq1 = "Barcelona", Eq2 = "Real Madrid", Puntaje1 = 2, Puntaje2 = 3, Progreso = 20 });
            juegos.Add(new Juego { Eq1 = "PSG", Eq2 = "Borusia Dortmund", Puntaje1 = 1, Puntaje2 = 3, Progreso = 50 });
            juegos.Add(new Juego { Eq1 = "Man United", Eq2 = "Man City", Puntaje1 = 2, Puntaje2 = 2, Progreso = 90 });
            lbJuego.ItemsSource = juegos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbJuego.SelectedItem != null)
            {
                MessageBox.Show($"Juego seleccionado: {(lbJuego.SelectedItem as Juego).Eq1} vs {(lbJuego.SelectedItem as Juego).Eq2} ");
            }

        }
    }
}