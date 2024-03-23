using System;

class Program
{
    static void CalcularDescuento(int[,] compras)
    {
        int[] totalCompras = new int[5];

        for (int cliente = 0; cliente < 5; cliente++)
        {
            for (int compra = 0; compra < 5; compra++)
            {
                totalCompras[cliente] += compras[cliente, compra];
            }
        }

        for (int cliente = 0; cliente < 5; cliente++)
        {
            int descuento = 0;
            if (totalCompras[cliente] >= 100 && totalCompras[cliente] <= 1000)
            {
                descuento = 10;
            }
            else if (totalCompras[cliente] > 1000)
            {
                descuento = 20;
            }

            Console.WriteLine("Cliente " + (cliente + 1) + ": Total de compras = " + totalCompras[cliente] + ", Descuento = " + descuento + "%");
        }
    }

    static void Main(string[] args)
    {
        int[,] compras = {
            {45, 200, 300, 140, 30},
            {600, 700, 800, 900, 1000},
            {1100, 120, 1300, 1400, 1500},
            {600, 100, 1800, 1900, 2000},
            {19, 22, 23, 15, 20}
        };

        CalcularDescuento(compras);
    }
}
