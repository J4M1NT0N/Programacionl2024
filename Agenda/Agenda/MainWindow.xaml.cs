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
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Agenda
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Tarea { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tarea = new ObservableCollection<Task>();
            ListaTarea.ItemsSource = Tarea;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombreTarea.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Tarea.Add(new Task
                {
                    Nombre = txtNombreTarea.Text,
                    Descripcion = txtDescripcion.Text,
                    Fecha = dpDate.SelectedDate ?? DateTime.Today
                });

                txtNombreTarea.Clear();
                txtDescripcion.Clear();
                dpDate.SelectedDate = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Ingrese el nombre y la descripcion de la tarea.");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (ListaTarea.SelectedItem != null)
            {
                Tarea.Remove((Task)ListaTarea.SelectedItem);
            }
            else
            {
                MessageBox.Show("");
            }
        }
    }

    public class Task : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged("Fecha");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
