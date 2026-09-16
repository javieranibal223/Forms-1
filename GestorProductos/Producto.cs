using System;

namespace GestorProductos
{
    public class Producto : IEntidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Rubro { get; set; } = string.Empty;
    }
}