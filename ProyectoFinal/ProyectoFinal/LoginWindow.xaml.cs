using System.Windows;

namespace ProyectoFinal
{
    public partial class LoginWindow : Window
    {
        private const string UsuarioCorrecto = "Santiforce";
        private const string ContraseñaCorrecta = "12345";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username == UsuarioCorrecto && password == ContraseñaCorrecta)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
