using AppLucas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AppLucas.Controllers
{
    public class PedidoController : Controller
    {
        // Página para mostrar el carrito
        public IActionResult Finalizar()
        {
            return View();
        }
    }

   
}