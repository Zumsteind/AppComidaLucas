using System.Text.Json.Serialization;

namespace AppLucas.Models
{
    public class ProductosWrapper
    {
        [JsonPropertyName("productos")]
        public List<Producto> Productos { get; set; } = new();
    }
}
