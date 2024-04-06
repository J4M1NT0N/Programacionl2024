using System;

public class Calculadora
{
    public string Marca { get; set; }
    public string Serie { get; set; }

    public Calculadora(string marca, string serie)
    {
        Marca = marca;
        Serie = serie;
    }

    public double Sumar(double num1, double num2)
    {
        return num1 + num2;
    }

    public double Restar(double num1, double num2)
    {
        return num1 - num2;
    }

    public double Multiplicar(double num1, double num2)
    {
        return num1 * num2;
    }

    public string Dividir(double num1, double num2)
    {
        if (num2 == 0)
        {
            return "Error: No se puede dividir por cero.";
        }
        else
        {
            return (num1 / num2).ToString();
        }
    }
}

public class CalculadoraCientifica : Calculadora
{
    public CalculadoraCientifica(string marca, string serie) : base(marca, serie)
    {
    }

    public double Potencia(double baseNum, double exponente)
    {
        return Math.Pow(baseNum, exponente);
    }

    public double Raiz(double num)
    {
        return Math.Sqrt(num);
    }

    public double Modulo(double num1, double num2)
    {
        return num1 % num2;
    }

    public double Logaritmo(double num)
    {
        return Math.Log(num);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese la marca de la calculadora: ");
        string marca = Console.ReadLine();
        Console.Write("Ingrese la serie de la calculadora: ");
        string serie = Console.ReadLine();

        Console.Write("Ingrese el primer número para la calculadora: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo número para la calculadora: ");
        double num2 = double.Parse(Console.ReadLine());

        Calculadora miCalculadora = new Calculadora(marca, serie);

        Console.WriteLine("Marca de la calculadora: " + miCalculadora.Marca);
        Console.WriteLine("Serie de la calculadora: " + miCalculadora.Serie);

        Console.WriteLine("Suma: " + miCalculadora.Sumar(num1, num2));
        Console.WriteLine("Resta: " + miCalculadora.Restar(num1, num2));
        Console.WriteLine("Multiplicación: " + miCalculadora.Multiplicar(num1, num2));
        Console.WriteLine("División: " + miCalculadora.Dividir(num1, num2));

        Console.WriteLine();

        Console.Write("Ingrese la marca de la calculadora científica: ");
        marca = Console.ReadLine();
        Console.Write("Ingrese la serie de la calculadora científica: ");
        serie = Console.ReadLine();

        Console.Write("Ingrese el número para la calculadora científica: ");
        double num = double.Parse(Console.ReadLine());

        CalculadoraCientifica miCalculadoraCientifica = new CalculadoraCientifica(marca, serie);

        Console.WriteLine("Marca de la calculadora científica: " + miCalculadoraCientifica.Marca);
        Console.WriteLine("Serie de la calculadora científica: " + miCalculadoraCientifica.Serie);

        Console.WriteLine("Potencia: " + miCalculadoraCientifica.Potencia(num, 2));
        Console.WriteLine("Raíz cuadrada: " + miCalculadoraCientifica.Raiz(num));
        Console.WriteLine("Módulo: " + miCalculadoraCientifica.Modulo(num, 3));
        Console.WriteLine("Logaritmo: " + miCalculadoraCientifica.Logaritmo(num));
    }
}
