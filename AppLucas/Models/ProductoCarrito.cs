namespace AppLucas.Models
{
    public class ProductoCarrito
    {
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
