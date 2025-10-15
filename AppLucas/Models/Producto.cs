namespace AppLucas.Models
{
    public class Producto
    {
        public required string Nombre { get; set; }
        public required string UrlImagen { get; set; }
        public decimal Precio { get; set; }

        public decimal Descuento { get; set; }
        public bool Disponible { get; set; }
    }
}
