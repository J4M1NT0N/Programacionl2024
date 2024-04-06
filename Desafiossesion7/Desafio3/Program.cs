using System;
using System.Collections.Generic;
using System.IO;

namespace PolimorfismoCurso
{
    class Auto
    {
        public int HP { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public List<string> HistoriaDeReparaciones { get; set; }

        public Auto(int hp, string color, string marca)
        {
            HP = hp;
            Color = color;
            Marca = marca;
            HistoriaDeReparaciones = new List<string>();
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("Marca: {0} - HP: {1} - Color: {2}", Marca, HP, Color);
        }

        public virtual void Reparar()
        {
            Console.WriteLine("El auto ya está reparado");
        }

        public void AgregarReparacion(string reparacion)
        {
            HistoriaDeReparaciones.Add(reparacion);
        }

        public void GuardarHistoriaDeReparaciones(string modelo)
        {
            string path = $"{Marca}_{modelo}_Reparaciones.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var reparacion in HistoriaDeReparaciones)
                {
                    sw.WriteLine(reparacion);
                }
            }
        }

        public void MostrarHistoriaDeReparaciones(string modelo)
        {
            string path = $"{Marca}_{modelo}_Reparaciones.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    Console.WriteLine($"Historia de Reparaciones de {Marca} {modelo}:");
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
            }
            else
            {
                Console.WriteLine($"No hay historial de reparaciones para {Marca} {modelo}");
            }
        }
    }

    class Audi : Auto
    {
        public Audi(int hp, string color, string modelo) : base(hp, color, "Audi")
        {
            Modelo = modelo;
        }

        public string Modelo { get; set; }

        public void MostrarDetalles()
        {
            Console.WriteLine("Marca: {0} - Modelo: {1} - HP: {2} - Color: {3}", Marca, Modelo, HP, Color);
        }

        public override void Reparar()
        {
            Console.WriteLine("El Audi {0} está reparado", Modelo);
            AgregarReparacion($"Audi {Modelo} reparado");
            GuardarHistoriaDeReparaciones(Modelo);
        }
    }

    class BMW : Auto
    {
        public BMW(int hp, string color, string modelo) : base(hp, color, "BMW")
        {
            Modelo = modelo;
        }

        public string Modelo { get; set; }

        public void MostrarDetalles()
        {
            Console.WriteLine("Marca: {0} - Modelo: {1} - HP: {2} - Color: {3}", Marca, Modelo, HP, Color);
        }

        public override void Reparar()
        {
            Console.WriteLine("El BMW {0} está reparado", Modelo);
            AgregarReparacion($"BMW {Modelo} reparado");
            GuardarHistoriaDeReparaciones(Modelo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var autos = new List<Auto>
            {
                new Audi(200,"azul","A4"),
                new BMW(250, "rojo","M3")
            };

            foreach (var auto in autos)
            {
                auto.Reparar();
            }

            Auto auto1 = new BMW(200, "negro", "Z3");
            Auto auto2 = new Audi(100, "verde", "A3");

            auto1.MostrarDetalles();
            auto2.MostrarDetalles();

            BMW bmwM5 = new BMW(330, "blanco", "M5");
            bmwM5.MostrarDetalles();
            bmwM5.MostrarHistoriaDeReparaciones(bmwM5.Modelo);

            Auto autoB = (Auto)bmwM5;
            autoB.MostrarDetalles();
            autoB.MostrarHistoriaDeReparaciones(bmwM5.Modelo);

            Console.Read();
        }
    }
}
