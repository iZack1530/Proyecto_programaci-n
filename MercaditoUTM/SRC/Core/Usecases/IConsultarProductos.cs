using System.Collections.Generic;
using MercaditoUTM.SRC.Core.Entities;

namespace MercaditoUTM.SRC.Core.Usecases
{
    public interface IConsultarProductos
    {
        List<Articulo> Ejecutar();
    }
}