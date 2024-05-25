using System.Windows;

namespace Semana13BD
{
    public partial class AgregarEditarWindow : Window
    {
        public Producto Producto { get; set; }

        public AgregarEditarWindow(Producto producto)
        {
            InitializeComponent();
            Producto = producto;
            NombreTextBox.Text = Producto.Nombre;
            PrecioTextBox.Text = Producto.Precio.ToString();
            StockTextBox.Text = Producto.Stock.ToString();
        }

        public void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Producto.Nombre = NombreTextBox.Text;
            Producto.Precio = decimal.Parse(PrecioTextBox.Text);
            Producto.Stock = int.Parse(StockTextBox.Text);
            DialogResult = true;
            Close();
        }
    }
}
