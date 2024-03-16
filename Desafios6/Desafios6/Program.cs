using System;

class Rectangulo
{
    private readonly double Alto;
    private readonly double Largo;
    private readonly double SuperficieFrontal;

    public Rectangulo(double alto, double largo)
    {
        Alto = alto;
        Largo = largo;
        SuperficieFrontal = Alto * Largo;
    }

    public double ObtenerSuperficieFrontal()
    {
        return SuperficieFrontal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangulo miRectangulo = new Rectangulo(5, 10);

        Console.WriteLine("La superficie frontal del rectángulo es: " + miRectangulo.ObtenerSuperficieFrontal());
    }
}
