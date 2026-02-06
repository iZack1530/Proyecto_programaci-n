using System;

namespace AreaCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Áreas");
            Console.WriteLine("-------------------");
            Console.WriteLine("¿Qué área desea calcular?");
            Console.WriteLine("1. Triángulo");
            Console.WriteLine("2. Cuadrado");
            Console.Write("Seleccione una opción (1 o 2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CalculateTriangleArea();
                    break;
                case "2":
                    CalculateSquareArea();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, reinicie el programa y elija 1 o 2.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }

        static void CalculateTriangleArea()
        {
            Console.WriteLine("\n--- Área de un Triángulo ---");

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
        }

        static void CalculateSquareArea()
        {
            Console.WriteLine("\n--- Área de un Cuadrado ---");

            double side;

            // Solicitar la longitud del lado al usuario
            Console.Write("Ingrese la longitud del lado del cuadrado: ");
            while (!double.TryParse(Console.ReadLine(), out side) || side <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número positivo para el lado.");
                Console.Write("Ingrese la longitud del lado del cuadrado: ");
            }

            // Calcular el área
            double area = side * side;

            // Mostrar el resultado
            Console.WriteLine($"\nEl área del cuadrado con lado {side} es: {area}");
        }
    }
}
