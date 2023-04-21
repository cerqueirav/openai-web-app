using Microsoft.AspNetCore.Mvc;
using GptWeb.Services;
using GptWeb.Models;

namespace GptWeb.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PesquisaSimples(DateTime? dataMinima, DateTime? dataMaxima)
        {
            //var result = await _pedidoService.ListarPorDataSimples(dataMinima, dataMaxima);
            var result = new List<Pedido>();
            return View(result);
        }
        public async Task<IActionResult> PesquisaAgrupada(DateTime? dataMinima, DateTime? dataMaxima)
        {
            //var result = await _pedidoService.ListarPorDataAgrupada(dataMinima, dataMaxima);
            var result = new List<Pedido>();
            return View(result);
        }
    }
}
