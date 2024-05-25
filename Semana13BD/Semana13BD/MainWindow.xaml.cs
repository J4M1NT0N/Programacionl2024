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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana13BD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            recoverData();
        }

        private void recoverData()
        {

            DataAccess dataAccess = new DataAccess();
            List<Alumno> alumnosConDapper = dataAccess.GetAllDapper();
            myDataGrid.ItemsSource = alumnosConDapper;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow insertWindow = new InsertWindow();
            insertWindow.Show();
            insertWindow.Closed += Window_Closed;
        }

        private void Window_Closed(object? sender, EventArgs e)
        {
            recoverData();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Alumno)myDataGrid.SelectedItem).Id;
            UpdateWindow updateWindow = new UpdateWindow(id);
            updateWindow.Show();
            updateWindow.Closed += Window_Closed;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Alumno)myDataGrid.SelectedItem).Id;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas eliminar el registro?", "Confirmacion de borrado", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.Delete(id);
                MessageBox.Show("El registro ha sido eliminado");
                recoverData();

            }
        }
    }
    public partial class MainWindow : Window
    {
        private List<Producto> Productos = new List<Producto>();
        private List<Venta> Ventas = new List<Venta>();

        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var nuevoProducto = new Producto { Id = Productos.Count + 1, Nombre = "Nuevo Producto", Precio = 0.0m, Stock = 0 };
            Productos.Add(nuevoProducto);
            ProductosDataGrid.Items.Refresh();
        }

        private void EditarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosDataGrid.SelectedItem is Producto productoSeleccionado)
            {
                productoSeleccionado.Nombre = "Producto Editado";
                ProductosDataGrid.Items.Refresh();
            }
        }

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosDataGrid.SelectedItem is Producto productoSeleccionado)
            {
                Productos.Remove(productoSeleccionado);
                ProductosDataGrid.Items.Refresh();
            }
        }

        private void AgregarVenta_Click(object sender, RoutedEventArgs e)
        {
            var nuevaVenta = new Venta { Id = Ventas.Count + 1, ProductoId = 1, Cantidad = 1, Fecha = DateTime.Now };
            Ventas.Add(nuevaVenta);
            VentasDataGrid.Items.Refresh();
        }

        private void EditarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.SelectedItem is Venta ventaSeleccionada)
            {
                ventaSeleccionada.Cantidad = 5;
                VentasDataGrid.Items.Refresh();
            }
        }

        private void EliminarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.SelectedItem is Venta ventaSeleccionada)
            {
                Ventas.Remove(ventaSeleccionada);
                VentasDataGrid.Items.Refresh();
            }
        }
    }
}