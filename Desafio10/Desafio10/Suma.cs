using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desafio10
{
    public class Suma : INotifyPropertyChanged
    {

        private string num1;
        private string num2;
        private string resultado;
        public string Num1
        {
            get { return num1; }
            set
            {
                decimal numero;
                bool respuesta = decimal.TryParse(value, out numero);
                if (respuesta)
                {
                    num1 = value;
                }
                OnPropertyChanged("Num1");
                OnPropertyChanged("Resultado");
            }

        }

        public string Num2
        {
            get { return num2; }
            set
            {
                decimal numero;
                bool respuesta = decimal.TryParse(value, out numero);
                if (respuesta)
                {
                    num2 = value;
                }
                OnPropertyChanged("Num2");
                OnPropertyChanged("Resultado");
            }

        }

        public string Resultado
        {
            get
            {
                decimal res = decimal.Parse(Num1) + decimal.Parse(Num2);
                return res.ToString();
            }
            set
            {
                decimal res = decimal.Parse(Num1) + decimal.Parse(Num2);
                resultado = res.ToString();
                OnPropertyChanged("Resultado");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}