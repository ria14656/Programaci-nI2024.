using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string textoEjemplo = "Este es mi correo electrónico: ariatnav63@gmail.com. Por favor, envíeme un correo con sus cnsultas.";

        // Expresión regular para encontrar direcciones de correos electrónicos
        string patronCorreo = @"\b[\w\.-]+@[\w\.-]+\.\w+\b";

        // Crear una instancia de la clase Regex con el patrón
        Regex regex = new Regex(patronCorreo);

        // Buscar todas las coincidencias en el texto
        MatchCollection direccionesEncontradas = regex.Matches(textoEjemplo);

        // Imprimir las direcciones encontradas
        foreach (Match direccion in direccionesEncontradas)
        {
            Console.WriteLine(direccion.Value);
        }
    }
}
