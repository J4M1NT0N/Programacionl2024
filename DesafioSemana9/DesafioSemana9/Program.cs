using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Por favor ingrese un texto:");
        string texto = Console.ReadLine();

        string patron = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        Regex regex = new Regex(patron);

        MatchCollection coincidencias = regex.Matches(texto);

        Console.WriteLine("Estas son las direcciones de correo electrónico encontradas:");

        foreach (Match coincidencia in coincidencias)
        {
            Console.WriteLine(coincidencia.Value);
        }
    }
}