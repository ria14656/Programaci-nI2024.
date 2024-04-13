// See https://aka.ms/new-console-template for more information
using System;

namespace Desafío_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Desafio1();
        }
        public static void Desafio1()
        {
            Console.WriteLine("Ingrese un Numero Positivo");
            int numerosABuscar = int.Parse(Console.ReadLine());
            while (numerosABuscar != 1)
            {
                for (int i = 1; i < (numerosABuscar); i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("Los numeros Pares son {0}", i);
                    }
                    if (i % 2 >= 1)
                    {
                        continue;
                    }
                }

                Console.WriteLine("Ingrese Numero Positivo");
                numerosABuscar = int.Parse(Console.ReadLine());
            }
        }
    }
}


