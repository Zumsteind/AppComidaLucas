using AppLucas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AppLucas.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ProductosController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(_env.WebRootPath, "data", "productos.json");

            if (!System.IO.File.Exists(filePath))
                return Content("No se encontró el archivo de productos.");

            string jsonData = System.IO.File.ReadAllText(filePath);

            var productos = JsonSerializer.Deserialize<List<Producto>>(jsonData);

            return View(productos);
        }
    }
}

