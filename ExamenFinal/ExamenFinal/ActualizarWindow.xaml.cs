using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExamenFinal
{
    public partial class ActualizarWindow : Window
    {
        public Producto Producto { get; set; }
        public List<Usuarioo> Usuarios { get; set; }

        public ActualizarWindow(Producto producto)
        {
            InitializeComponent();
            Producto = producto;
            CargarUsuarios();
            LlenarCampos();
        }

        private void CargarUsuarios()
        {
            using (var context = new AppDbContext())
            {
                Usuarios = context.Usuarios.ToList();
                UsuarioComboBox.ItemsSource = Usuarios;
            }
        }

        private void LlenarCampos()
        {
            UsuarioComboBox.SelectedValue = Producto.Usuario;
            NombreTextBox.Text = Producto.Nombre;
            PrecioTextBox.Text = Producto.Precio.ToString();
            ExistenciaTextBox.Text = Producto.Existencia.ToString();
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            Producto.Usuario = UsuarioComboBox.SelectedValue.ToString();
            Producto.Nombre = NombreTextBox.Text;
            Producto.Precio = decimal.Parse(PrecioTextBox.Text);
            Producto.Existencia = int.Parse(ExistenciaTextBox.Text);
            DialogResult = true;
            Close();
        }
    }
}
