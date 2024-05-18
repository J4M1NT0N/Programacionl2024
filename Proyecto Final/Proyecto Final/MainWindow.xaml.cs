using System.Collections.ObjectModel;
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

namespace Proyecto_Final
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Transaccion> transacciones = new ObservableCollection<Transaccion>();

        public MainWindow()
        {
            InitializeComponent();

            dgTransacciones.ItemsSource = transacciones;
        }

        private void cmbTipoTransaccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmbTipoTransaccion.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string tipoTransaccion = selectedItem.Content.ToString();
                lblCantidad.Visibility = tipoTransaccion == "Compra" || tipoTransaccion == "Venta" ? Visibility.Visible : Visibility.Collapsed;
                txtCantidad.Visibility = tipoTransaccion == "Compra" || tipoTransaccion == "Venta" ? Visibility.Visible : Visibility.Collapsed;
                txtTipoMoneda.Visibility = tipoTransaccion == "Compra" || tipoTransaccion == "Venta" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void RegistrarTransaccion_Click(object sender, RoutedEventArgs e)
        {
            string tipo = (cmbTipoTransaccion.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Por favor, seleccione un tipo de transacción.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string descripcion = txtDescripcion.Text;
            decimal monto;
            decimal cantidad;

            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida para la transacción.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string tipoMoneda = txtTipoMoneda.Text;

            transacciones.Add(new Transaccion { Tipo = tipo, Descripcion = descripcion, Monto = monto, Cantidad = cantidad, TipoMoneda = tipoMoneda });

            txtDescripcion.Clear();
            txtMonto.Clear();
            txtCantidad.Clear();
            txtTipoMoneda.Text = "Q";
        }



    }
}