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
    /// Interaction logic for WindowInputs.xaml
    /// </summary>
    public partial class WindowInputs : Window
    {
        public WindowInputs()
        {
            InitializeComponent();
            //Convertimos todos los nombres de propiedades en un arreglo
            ComboBoxColores.ItemsSource = typeof(Colors).GetProperties();
        }

        private void cbTodos_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = cbTodos.IsChecked == true;
            cboption1.IsChecked = isChecked;
            cboption2.IsChecked = isChecked;
            cboption3.IsChecked = isChecked;

        }



        private void cboption_Checked(object sender, RoutedEventArgs e)
        {
            cbTodos.IsChecked = null;
            if (cboption1.IsChecked == true && cboption2.IsChecked == true && cboption3.IsChecked == true)
            {
                cbTodos.IsChecked = true;
            }
            if (cboption1.IsChecked == false && cboption2.IsChecked == false && cboption3.IsChecked == false)
            {
                cbTodos.IsChecked = false;
            }

        }


    }
}