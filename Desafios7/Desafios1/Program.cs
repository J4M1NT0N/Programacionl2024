using System;

class Program
{
    static char[,] tablero = new char[3, 3];
    static char jugadorActual = 'X';

    static void InicializarTablero()
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                tablero[fila, columna] = ' ';
            }
        }
    }

    static void ImprimirTablero()
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                Console.Write(tablero[fila, columna]);
                if (columna < 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (fila < 2)
            {
                Console.WriteLine("-----");
            }
        }
    }

    static bool VerificarGanador()
    {
        for (int i = 0; i < 3; i++)
        {
            if (tablero[i, 0] != ' ' && tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2])
            {
                return true;
            }
            if (tablero[0, i] != ' ' && tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i])
            {
                return true;
            }
        }

        if (tablero[0, 0] != ' ' && tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2])
        {
            return true;
        }
        if (tablero[0, 2] != ' ' && tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0])
        {
            return true;
        }

        return false;
    }

    static bool TableroLleno()
    {
        foreach (char casilla in tablero)
        {
            if (casilla == ' ')
            {
                return false;
            }
        }
        return true;
    }

    static void Jugar()
    {
        InicializarTablero();

        while (true)
        {
            Console.WriteLine("Turno de jugador " + jugadorActual);
            ImprimirTablero();

            int fila, columna;
            do
            {
                Console.Write("Ingrese la fila (0, 1 o 2): ");
                fila = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la columna (0, 1 o 2): ");
                columna = int.Parse(Console.ReadLine());
            } while (tablero[fila, columna] != ' ');

            tablero[fila, columna] = jugadorActual;

            if (VerificarGanador())
            {
                ImprimirTablero();
                Console.WriteLine("El jugador " + jugadorActual + " ha ganado!");
                break;
            }
            else if (TableroLleno())
            {
                ImprimirTablero();
                Console.WriteLine("¡Empate!");
                break;
            }

            jugadorActual = (jugadorActual == 'X') ? 'O' : 'X';
            Console.Clear();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido al juego de ToTiTo!");
        Jugar();
    }
}
