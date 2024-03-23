using System;
using System.Collections.Generic;

class Program
{
    static char[,] tablero = new char[3, 3];
    static List<string> tareas = new List<string>();
    static char jugadorActual = 'X';

    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Jugar ToTiTo");
            Console.WriteLine("2. Calcular Descuentos");
            Console.WriteLine("3. Lista de Tareas");
            Console.WriteLine("4. Salir");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    JugarToTiTo();
                    break;
                case "2":
                    CalcularDescuentos();
                    break;
                case "3":
                    ManejarTareas();
                    break;
                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void JugarToTiTo()
    {
        InicializarTablero();
        bool hayGanador = false;
        int turnos = 0;

        while (!hayGanador && turnos < 9)
        {
            DibujarTablero();
            Console.WriteLine($"Turno del jugador {jugadorActual}:");
            Console.WriteLine("Ingrese la fila y columna para marcar (ejemplo: 2 3):");
            string[] entrada = Console.ReadLine().Split(' ');
            int fila = int.Parse(entrada[0]) - 1;
            int columna = int.Parse(entrada[1]) - 1;

            if (tablero[fila, columna] == ' ')
            {
                tablero[fila, columna] = jugadorActual;
                turnos++;

                if (VerificarGanador(fila, columna))
                {
                    hayGanador = true;
                    DibujarTablero();
                    Console.WriteLine($"El jugador {jugadorActual} ha ganado!");
                }
                else
                {
                    jugadorActual = jugadorActual == 'X' ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("La posición está ocupada. Intente de nuevo.");
            }
        }

        if (!hayGanador && turnos == 9)
        {
            Console.WriteLine("Es un empate!");
        }
    }

    static void InicializarTablero()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tablero[i, j] = ' ';
            }
        }
    }

    static void DibujarTablero()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tablero[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---------");
        }
    }

    static bool VerificarGanador(int fila, int columna)
    {
        // Verificar fila
        if (tablero[fila, 0] == jugadorActual && tablero[fila, 1] == jugadorActual && tablero[fila, 2] == jugadorActual)
            return true;
        // Verificar columna
        if (tablero[0, columna] == jugadorActual && tablero[1, columna] == jugadorActual && tablero[2, columna] == jugadorActual)
            return true;
        // Verificar diagonales
        if (tablero[0, 0] == jugadorActual && tablero[1, 1] == jugadorActual && tablero[2, 2] == jugadorActual)
            return true;
        if (tablero[0, 2] == jugadorActual && tablero[1, 1] == jugadorActual && tablero[2, 0] == jugadorActual)
            return true;

        return false;
    }

    static void CalcularDescuentos()
    {
        double[,] montosCompras = {
            { 150.0, 200.0, 250.0, 300.0, 350.0 },
            { 60.0, 75.0, 80.0, 45.0, 60.0 },
            { 110.0, 100.0, 250.0, 300.0, 350.0 },
            { 50.0, 5.0, 10.0, 45.0, 10.0 },
            { 170.0, 500.0, 50.0, 30.0, 350.0 },
           
            // ... otros clientes
        };

        CalculadoraDescuentos.AplicarDescuentos(montosCompras);
    }

    static void ManejarTareas()
    {
        string input;
        do
        {
            Console.WriteLine("\n1. Mostrar Tareas\n2. Agregar Tarea\n3. Eliminar Tarea\n4. Volver");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    MostrarTareas();
                    break;
                case "2":
                    Console.WriteLine("Ingrese la tarea a agregar:");
                    string tarea = Console.ReadLine();
                    AgregarTarea(tarea);
                    break;
                case "3":
                    Console.WriteLine("Ingrese el índice de la tarea a eliminar:");
                    int indice = Convert.ToInt32(Console.ReadLine()) - 1;
                    EliminarTarea(indice);
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (input != "4");
    }

    static void MostrarTareas()
    {
        Console.WriteLine("Tareas:");
        for (int i = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tareas[i]}");
        }
    }

    static void AgregarTarea(string tarea)
    {
        tareas.Add(tarea);
        Console.WriteLine("Tarea agregada.");
    }

    static void EliminarTarea(int indice)
    {
        if (indice >= 0 && indice < tareas.Count)
        {
            tareas.RemoveAt(indice);
            Console.WriteLine("Tarea eliminada.");
        }
        else
        {
            Console.WriteLine(" inválido.");
        }
    }
}

public class CalculadoraDescuentos
{
    public static void AplicarDescuentos(double[,] montosCompras)
    {
        for (int i = 0; i < montosCompras.GetLength(0); i++)
        {
            double totalCompras = 0;
            for (int j = 0; j < montosCompras.GetLength(1); j++)
            {
                totalCompras += montosCompras[i, j];
            }

            double descuento = CalcularDescuento(totalCompras);
            double totalConDescuento = totalCompras - (totalCompras * descuento);

            Console.WriteLine($"Cliente {i + 1}: Total antes de descuento: {totalCompras:C2}, Descuento: {descuento:P2}, Total con descuento: {totalConDescuento:C2}");
        }
    }

    private static double CalcularDescuento(double totalCompras)
    {
        if (totalCompras > 1000)
        {
            return 0.20; // 20% de descuento
        }
        else if (totalCompras >= 100)
        {
            return 0.10; // 10% de descuento
        }
        
        return 0; // No aplica descuento
    }
}