using System;

namespace TriangleAreaCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Área de Triángulo");
            Console.WriteLine("--------------------------------");

            double baseTriangle;
            double heightTriangle;

            // Solicitar la base al usuario
            Console.Write("Ingrese la longitud de la base del triángulo: ");
            while (!double.TryParse(Console.ReadLine(), out baseTriangle) || baseTriangle <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número positivo para la base.");
                Console.Write("Ingrese la longitud de la base del triángulo: ");
            }

            // Solicitar la altura al usuario
            Console.Write("Ingrese la altura del triángulo: ");
            while (!double.TryParse(Console.ReadLine(), out heightTriangle) || heightTriangle <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número positivo para la altura.");
                Console.Write("Ingrese la altura del triángulo: ");
            }

            // Calcular el área
            double area = (baseTriangle * heightTriangle) / 2;

            // Mostrar el resultado
            Console.WriteLine($"\nEl área del triángulo con base {baseTriangle} y altura {heightTriangle} es: {area}");
            Console.WriteLine("Presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}