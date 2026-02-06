using System;
using System.Collections.Generic;
using MercaditoUTM.SRC.Core.Usecases;
using MercaditoUTM.SRC.Application;
using MercaditoUTM.SRC.Core.Entities; // Needed for Articulo

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Generando y mostrando 25 artículos aleatorios:");
Console.WriteLine("---------------------------------------------");

// Instantiate the use case
IConsultarProductos consultarProductos = new ConsultarProductosAleatorios();

// Execute the use case to get the list of articles
List<Articulo> articulos = consultarProductos.Ejecutar();

// Display the articles
foreach (var articulo in articulos)
{
    Console.WriteLine($"Nombre: {articulo.Nombre}, Precio: {articulo.Precio:C}, SKU: {articulo.SKU}, Stock: {articulo.Stock}, Marca: {articulo.Marca}");
}

Console.WriteLine("---------------------------------------------");
Console.WriteLine("Fin de la lista de artículos.");
