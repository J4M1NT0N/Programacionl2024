using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExamenFinal
{
    public partial class MainWindow : Window
    {
        private AppDbContext _context;
        private List<Producto> productos = new List<Producto>();

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            RecuperarProductos();
            CargarUsuarios();
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            var crearWindow = new CrearWindow();
            if (crearWindow.ShowDialog() == true)
            {
                _context.Productos.Add(crearWindow.Producto);
                _context.SaveChanges();
                ActualizarListaProductos();
            }
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosListBox.SelectedItem is Producto productoSeleccionado)
            {
                var actualizarWindow = new ActualizarWindow(productoSeleccionado);
                if (actualizarWindow.ShowDialog() == true)
                {
                    _context.Productos.Update(actualizarWindow.Producto);
                    _context.SaveChanges();
                    ActualizarListaProductos();
                }
            }
        }

        private void BorrarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosListBox.SelectedItem is Producto productoSeleccionado)
            {
                _context.Productos.Remove(productoSeleccionado);
                _context.SaveChanges();
                ActualizarListaProductos();
            }
        }

        private void RecuperarProductos()
        {
            productos = _context.Productos.ToList();
            ActualizarListaProductos();
        }

        private void CargarUsuarios()
        {
            UsuarioComboBox.ItemsSource = _context.Usuarios.ToList();
        }

        private void ActualizarListaProductos()
        {
            ProductosListBox.ItemsSource = null;
            ProductosListBox.ItemsSource = productos;
        }
    }
}
