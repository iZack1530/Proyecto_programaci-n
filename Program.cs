using System;
using System.Linq; // For .ToList() and other LINQ operations if needed
using BibliotecaUTM.SRC.Application;
using BibliotecaUTM.SRC.Core.Entities; // Needed for Libro and Autor
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido a la Biblioteca UTM!");

            // Initialize the main book source
            IConsultarTodosLosLibros consultarTodosLosLibrosService = new ConsultarTodosLosLibros();

            // Initialize other use cases with their dependencies
            IConsultarLosLibrosQueSuGeneroSeaCiFi consultarCiFiLibrosService = new ConsultarLosLibrosQueSuGeneroSeaCiFi(consultarTodosLosLibrosService);
            IConsultarLosLibrosQueEnSuNombreContengaAlgebra consultarAlgebraLibrosService = new ConsultarLosLibrosQueEnSuNombreContengaAlgebra(consultarTodosLosLibrosService);
            IConsultarLosLibrosQueSeanEscritosPorAutoresFranceses consultarFrancesLibrosService = new ConsultarLosLibrosQueSeanEscritosPorAutoresFranceses(consultarTodosLosLibrosService);
            IConsultarLosAutoresQueHayanEscritoLibrosDeRomance consultarAutoresRomanceService = new ConsultarLosAutoresQueHayanEscritoLibrosDeRomance(consultarTodosLosLibrosService);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Consultar todos los libros");
                Console.WriteLine("2. Consultar los libros que su género sea Ciencia Ficción");
                Console.WriteLine("3. Consultar los libros que en su nombre contenga \"Algebra\"");
                Console.WriteLine("4. Consultar los libros que sean escritos por autores franceses");
                Console.WriteLine("5. Consultar los autores que hayan escrito libros de romance");
                Console.WriteLine("0. Salir");
                Console.Write("Por favor, seleccione una opción: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MostrarLibros(consultarTodosLosLibrosService.Ejecutar(), "Todos los Libros");
                        break;
                    case "2":
                        MostrarLibros(consultarCiFiLibrosService.Ejecutar(), "Libros de Ciencia Ficción");
                        break;
                    case "3":
                        MostrarLibros(consultarAlgebraLibrosService.Ejecutar(), "Libros con \"Algebra\" en el nombre");
                        break;
                    case "4":
                        MostrarLibros(consultarFrancesLibrosService.Ejecutar(), "Libros de Autores Franceses");
                        break;
                    case "5":
                        MostrarAutores(consultarAutoresRomanceService.Ejecutar(), "Autores de Libros de Romance");
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Gracias por usar la Biblioteca UTM. ¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void MostrarLibros(IEnumerable<Libro> libros, string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ({libros.Count()} encontrados) ---");
            if (!libros.Any())
            {
                Console.WriteLine("No se encontraron libros para esta categoría.");
                return;
            }

            int count = 1;
            foreach (var libro in libros)
            {
                Console.WriteLine($"\nLibro #{count++}");
                Console.WriteLine($"  Nombre: {libro.Nombre}");
                Console.WriteLine($"  ISBN: {libro.ISBN}");
                Console.WriteLine($"  Editorial: {libro.Editorial}");
                Console.WriteLine($"  Año de Publicación: {libro.AnioPublicacion}");
                Console.WriteLine($"  Precio: {libro.Precio:C}");
                Console.WriteLine($"  Autor: {libro.Autor?.Nombre} ({libro.Autor?.Pais}, Nacido en {libro.Autor?.AnioNacimiento})");
                Console.WriteLine($"  Género: {libro.Genero}");
            }
        }

        static void MostrarAutores(IEnumerable<Autor> autores, string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ({autores.Count()} encontrados) ---");
            if (!autores.Any())
            {
                Console.WriteLine("No se encontraron autores para esta categoría.");
                return;
            }

            int count = 1;
            foreach (var autor in autores)
            {
                Console.WriteLine($"\nAutor #{count++}");
                Console.WriteLine($"  Nombre: {autor.Nombre}");
                Console.WriteLine($"  País: {autor.Pais}");
                Console.WriteLine($"  Año de Nacimiento: {autor.AnioNacimiento}");
            }
        }
    }
}
