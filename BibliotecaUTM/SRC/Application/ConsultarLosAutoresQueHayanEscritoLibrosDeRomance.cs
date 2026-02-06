using System.Collections.Generic;
using System.Linq; // Needed for Where() and Select()
using BibliotecaUTM.SRC.Core.Entities;
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM.SRC.Application
{
    public class ConsultarLosAutoresQueHayanEscritoLibrosDeRomance : IConsultarLosAutoresQueHayanEscritoLibrosDeRomance
    {
        private readonly IConsultarTodosLosLibros _consultarTodosLosLibros;

        public ConsultarLosAutoresQueHayanEscritoLibrosDeRomance(IConsultarTodosLosLibros consultarTodosLosLibros)
        {
            _consultarTodosLosLibros = consultarTodosLosLibros;
        }

        public IEnumerable<Autor> Ejecutar()
        {
            return _consultarTodosLosLibros.Ejecutar()
                                           .Where(libro => libro.Genero == "Romance" && libro.Autor != null)
                                           .Select(libro => libro.Autor)
                                           .Distinct(); // Ensure unique authors
        }
    }
}