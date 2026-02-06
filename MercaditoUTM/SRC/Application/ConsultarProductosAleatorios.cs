using System;
using System.Collections.Generic;
using MercaditoUTM.SRC.Core.Entities;
using MercaditoUTM.SRC.Core.Usecases;

namespace MercaditoUTM.SRC.Application
{
    public class ConsultarProductosAleatorios : IConsultarProductos
    {
        public List<Articulo> Ejecutar()
        {
            List<Articulo> articulos = new List<Articulo>();
            Random random = new Random();

            string[] nombres = { "Camiseta", "Pantalón", "Zapatos", "Gorra", "Calcetines", "Chaqueta", "Bufanda", "Guantes", "Reloj", "Anillo" };
            string[] marcas = { "MarcaA", "MarcaB", "MarcaC", "MarcaD", "MarcaE" };

            for (int i = 0; i < 25; i++)
            {
                articulos.Add(new Articulo
                {
                    Nombre = nombres[random.Next(nombres.Length)] + " " + (i + 1),
                    Precio = Math.Round((decimal)(random.NextDouble() * 100) + 10, 2), // Price between 10 and 110
                    SKU = $"SKU-{random.Next(1000, 9999)}",
                    Stock = random.Next(0, 100), // Stock between 0 and 99
                    Marca = marcas[random.Next(marcas.Length)]
                });
            }

            return articulos;
        }
    }
}