using System.Collections.Generic;
using System.Linq; // Needed for Where()
using BibliotecaUTM.SRC.Core.Entities;
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM.SRC.Application
{
    public class ConsultarLosLibrosQueEnSuNombreContengaAlgebra : IConsultarLosLibrosQueEnSuNombreContengaAlgebra
    {
        private readonly IConsultarTodosLosLibros _consultarTodosLosLibros;

        public ConsultarLosLibrosQueEnSuNombreContengaAlgebra(IConsultarTodosLosLibros consultarTodosLosLibros)
        {
            _consultarTodosLosLibros = consultarTodosLosLibros;
        }

        public IEnumerable<Libro> Ejecutar()
        {
            return _consultarTodosLosLibros.Ejecutar()
                                           .Where(libro => libro.Nombre != null && libro.Nombre.IndexOf("Algebra", System.StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}