using System;
using System.Collections.Generic;

class Program
{
    static List<string> tareas = new List<string>();

    static void MostrarTareas()
    {
        Console.WriteLine("\nLista de tareas:");
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas por realizar.");
        }
        else
        {
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tareas[i]);
            }
        }
    }

    static void CrearTarea()
    {
        Console.Write("Ingrese la nueva tarea: ");
        string nuevaTarea = Console.ReadLine();
        tareas.Add(nuevaTarea);
        Console.WriteLine("Tarea agregada con éxito.");
    }

    static void EliminarTarea()
    {
        MostrarTareas();
        Console.Write("Ingrese el número de la tarea que desea eliminar: ");
        int numeroTarea = int.Parse(Console.ReadLine());

        if (numeroTarea >= 1 && numeroTarea <= tareas.Count)
        {
            tareas.RemoveAt(numeroTarea - 1);
            Console.WriteLine("Tarea eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("Número de tarea no válido.");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Mostrar tareas");
            Console.WriteLine("2. Crear tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MostrarTareas();
                    break;
                case 2:
                    CrearTarea();
                    break;
                case 3:
                    EliminarTarea();
                    break;
                case 4:
                    Console.WriteLine("Vuelva Pronto!!");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
