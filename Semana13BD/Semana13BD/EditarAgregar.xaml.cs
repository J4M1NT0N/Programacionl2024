using System;
using System.Windows;

namespace Semana13BD
{
    public partial class EditarAgregar : Window
    {
        public Venta Venta { get; set; }

        public EditarAgregar(Venta venta)
        {
            InitializeComponent();
            Venta = venta;
            ProductoIdTextBox.Text = Venta.ProductoId.ToString();
            CantidadTextBox.Text = Venta.Cantidad.ToString();
            FechaDatePicker.SelectedDate = Venta.Fecha;
        }

        public void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Venta.ProductoId = int.Parse(ProductoIdTextBox.Text);
            Venta.Cantidad = int.Parse(CantidadTextBox.Text);
            Venta.Fecha = FechaDatePicker.SelectedDate.GetValueOrDefault();
            DialogResult = true;
            Close();
        }
    }
}
