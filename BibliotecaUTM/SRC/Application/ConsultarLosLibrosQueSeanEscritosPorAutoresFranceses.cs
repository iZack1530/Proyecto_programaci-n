using System.Collections.Generic;
using System.Linq; // Needed for Where()
using BibliotecaUTM.SRC.Core.Entities;
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM.SRC.Application
{
    public class ConsultarLosLibrosQueSeanEscritosPorAutoresFranceses : IConsultarLosLibrosQueSeanEscritosPorAutoresFranceses
    {
        private readonly IConsultarTodosLosLibros _consultarTodosLosLibros;

        public ConsultarLosLibrosQueSeanEscritosPorAutoresFranceses(IConsultarTodosLosLibros consultarTodosLosLibros)
        {
            _consultarTodosLosLibros = consultarTodosLosLibros;
        }

        public IEnumerable<Libro> Ejecutar()
        {
            return _consultarTodosLosLibros.Ejecutar()
                                           .Where(libro => libro.Autor != null && libro.Autor.Pais == "Francia");
        }
    }
}