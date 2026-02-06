using System.Collections.Generic;
using BibliotecaUTM.SRC.Core.Entities;

namespace BibliotecaUTM.SRC.Core.Usecases
{
    public interface IConsultarLosLibrosQueSuGeneroSeaCiFi
    {
        IEnumerable<Libro> Ejecutar();
    }
}