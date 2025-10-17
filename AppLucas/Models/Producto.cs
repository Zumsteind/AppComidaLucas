namespace AppLucas.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string UrlImagen { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public bool Disponible { get; set; }
    }
}
