// See https://aka.ms/new-console-template for more information
using System;

namespace CalculoVolumenCajas
{
    class Caja
    {
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }

        public double CalcularVolumen()
        {
            return Alto * Ancho * Profundidad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Cuántas cajas deseas ingresar? ");
            int cantidadCajas = int.Parse(Console.ReadLine());

            double volumenTotal = 0;

            for (int i = 1; i <= cantidadCajas; i++)
            {
                Console.WriteLine($"Caja {i}:");
                Console.Write("Alto: ");
                double alto = double.Parse(Console.ReadLine());
                Console.Write("Ancho: ");
                double ancho = double.Parse(Console.ReadLine());
                Console.Write("Profundidad: ");
                double profundidad = double.Parse(Console.ReadLine());

                Caja caja = new Caja { Alto = alto, Ancho = ancho, Profundidad = profundidad };
                volumenTotal += caja.CalcularVolumen();
            }

            double volumenPromedio = volumenTotal / cantidadCajas;

            Console.WriteLine($" total de las cajas: {volumenTotal:F2}");
            Console.WriteLine($"Volumen promedio de las cajas: {volumenPromedio:F2}");
        }
    }
}
