using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExamenFinal
{
    public partial class CrearWindow : Window
    {
        public Producto Producto { get; private set; }
        public List<Usuarioo> Usuarios { get; set; }

        public CrearWindow()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            using (var context = new AppDbContext())
            {
                Usuarios = context.Usuarios.ToList();
                UsuarioComboBox.ItemsSource = Usuarios;
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            Producto = new Producto
            {
                Usuario = UsuarioComboBox.SelectedValue.ToString(),
                Nombre = NombreTextBox.Text,
                Precio = decimal.Parse(PrecioTextBox.Text),
                Existencia = int.Parse(ExistenciaTextBox.Text)
            };
            DialogResult = true;
            Close();
        }
    }
}
