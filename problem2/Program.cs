﻿// See https://aka.ms/new-console-template for more information
using System;

namespace Desafío_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Establecer si el numero positivo es Primo {0}");
            int n = 0;
            int c = 0;
            Console.WriteLine("Ingrese un numero Positivo:");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < (n + 1); i++)
            {
                if (n % i == 0)
                {
                    c++;
                }
            }
            if (c != 2)
            {
                Console.WriteLine("No es un numero Primo:");
            }
            else
            {
                Console.WriteLine("Si es un numero Primo:");
            }
        }
    }
}