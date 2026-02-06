using System.Collections.Generic;
using System.Linq;
using BibliotecaUTM.SRC.Core.Entities;
using BibliotecaUTM.SRC.Core.Usecases;

namespace BibliotecaUTM.SRC.Application
{
    public class ConsultarLosLibrosQueSuGeneroSeaCiFi : IConsultarLosLibrosQueSuGeneroSeaCiFi
    {
        private readonly IConsultarTodosLosLibros _consultarTodosLosLibros;

        public ConsultarLosLibrosQueSuGeneroSeaCiFi(IConsultarTodosLosLibros consultarTodosLosLibros)
        {
            _consultarTodosLosLibros = consultarTodosLosLibros;
        }

        public IEnumerable<Libro> Ejecutar()
        {
            return _consultarTodosLosLibros.Ejecutar()
                                           .Where(libro => libro.Genero == "Ciencia Ficción");
        }
    }
}