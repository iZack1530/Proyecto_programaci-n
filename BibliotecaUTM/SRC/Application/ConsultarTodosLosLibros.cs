using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTM.SRC.Core.Entities;
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM.SRC.Application
{
    public class ConsultarTodosLosLibros : IConsultarTodosLosLibros
    {
        private readonly List<Libro> _libros;
        private readonly Random _random;
        private readonly List<Autor> _autoresGenerados;

        public ConsultarTodosLosLibros()
        {
            _libros = new List<Libro>();
            _random = new Random();
            _autoresGenerados = GenerarAutores(20); // Generate a smaller set of authors
            GenerarLibros(200);
        }

        private List<Autor> GenerarAutores(int cantidad)
        {
            var autores = new List<Autor>();
            string[] nombres = { "Gabriel Garcia Marquez", "Jane Austen", "George Orwell", "Isaac Asimov", "Stephen King", "J.K. Rowling", "Julio Verne", "Agatha Christie", "Arthur Conan Doyle", "Miguel de Cervantes", "Victor Hugo", "Albert Camus", "Molière", "Voltaire", "Jean-Jacques Rousseau" };
            string[] paises = { "Colombia", "Reino Unido", "Estados Unidos", "España", "Francia", "Argentina", "México" };

            for (int i = 0; i < cantidad; i++)
            {
                var autor = new Autor
                {
                    Nombre = nombres[_random.Next(nombres.Length)],
                    Pais = paises[_random.Next(paises.Length)],
                    AnioNacimiento = _random.Next(1700, 2000)
                };
                autores.Add(autor);
            }
            return autores;
        }


        private void GenerarLibros(int cantidad)
        {
            string[] generos = { "Ciencia Ficción", "Fantasía", "Romance", "Misterio", "Thriller", "Historia", "Biografía", "Ciencia", "Cocina", "Poesía" };
            string[] editoriales = { "Editorial Planeta", "Penguin Random House", "HarperCollins", "Anaya", "Santillana", "Akal", "Fondo de Cultura Económica" };

            for (int i = 0; i < cantidad; i++)
            {
                var libro = new Libro
                {
                    Nombre = $"Libro de {_random.Next(1, 1000)} - Tema {_random.NextLetter()}",
                    ISBN = GenerarISBN(),
                    Editorial = editoriales[_random.Next(editoriales.Length)],
                    AnioPublicacion = _random.Next(1900, 2024),
                    Precio = Math.Round((decimal)(_random.NextDouble() * 50.0 + 10.0), 2), // Price between 10.00 and 60.00
                    Autor = _autoresGenerados[_random.Next(_autoresGenerados.Count)], // Assign a random Autor object
                    Genero = generos[_random.Next(generos.Length)]
                };
                _libros.Add(libro);
            }
        }

        private string GenerarISBN()
        {
            return $"{_random.Next(100, 999)}-{_random.Next(1, 9)}-{_random.Next(100000, 999999)}-{_random.Next(1, 9)}";
        }

        public IEnumerable<Libro> Ejecutar()
        {
            return _libros;
        }
    }

    internal static class RandomExtensions // Helper for random letter
    {
        public static char NextLetter(this Random random)
        {
            int num = random.Next(0, 26); // Zero to 25
            char letter = (char)('a' + num);
            return letter;
        }
    }
}