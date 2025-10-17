using AppLucas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AppLucas.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseUrl = "https://applucassushi-default-rtdb.firebaseio.com/productos.json";

        public ProductosController()
        {
            _httpClient = new HttpClient();
        }

        // ✅ Leer productos desde Firebase y devolverlos a la vista
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(_firebaseUrl);
                response.EnsureSuccessStatusCode();

                string jsonData = await response.Content.ReadAsStringAsync();

                // Deserializamos como lista
                var productos = JsonSerializer.Deserialize<List<Producto>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Filtramos los elementos nulos
                productos = productos?.Where(p => p != null).ToList() ?? new List<Producto>();

                // Devolvemos la lista a la vista
                return View(productos);
            }
            catch (Exception ex)
            {
                return Content($"Error al leer datos de Firebase: {ex.Message}");
            }
        }

        // ✅ Guardar o actualizar un producto en Firebase
        public async Task<bool> GuardarProducto(Producto producto)
        {
            try
            {
                string url = $"https://applucassushi-default-rtdb.firebaseio.com/productos/{producto.Id}.json";
                var json = JsonSerializer.Serialize(producto);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

//public IActionResult Index()
//{
//    string filePath = Path.Combine(_env.WebRootPath, "data", "productos.json");

//    if (!System.IO.File.Exists(filePath))
//        return Content("No se encontró el archivo de productos.");

//    string jsonData = System.IO.File.ReadAllText(filePath);

//    var productos = JsonSerializer.Deserialize<List<Producto>>(jsonData);

//    return View(productos);
//}

