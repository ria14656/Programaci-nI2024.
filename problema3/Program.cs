// See https://aka.ms/new-console-template for more information
using System;

namespace CalculoPromedioEstudiante
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPuntajes = 0; 
            int contadorPuntajes = 0; 

            Console.WriteLine("Ingresa los puntajes del alumno (entre 1 y 10). Escribe 'fin' para terminar.");

            while (true)
            {
                Console.Write("Puntaje: ");
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "fin")
                {
                    break; // Salir del bucle si se ingresa "fin"
                }

                if (int.TryParse(entrada, out int puntaje) && puntaje >= 1 && puntaje <= 10)
                {
                    totalPuntajes += puntaje;
                    contadorPuntajes++;
                }
                else
                {
                    Console.WriteLine("inválido. Ingresa un número entre 1 y 10 o escribe 'fin' para terminar.");
                }
            }

            if (contadorPuntajes > 0)
            {
                double promedio = (double)totalPuntajes / contadorPuntajes;
                Console.WriteLine($"El puntaje promedio del alumno es: {promedio:F2}");
            }
            else
            {
                Console.WriteLine("No se ingresaron puntajes válidos.");
            }
        }
    }
}