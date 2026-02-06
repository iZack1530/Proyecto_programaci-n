namespace BibliotecaUTM.SRC.Core.Entities
{
    public class Libro
    {
        public string Nombre { get; set; }
        public string ISBN { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public Autor Autor { get; set; } // Representing a single author object
        public string Genero { get; set; }
    }
}