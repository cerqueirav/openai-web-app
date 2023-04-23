using Microsoft.AspNetCore.Mvc;
using GptWeb.Services;
using GptWeb.Models;
using GptWeb.Models.ViewModels;
using System.Diagnostics;

namespace GptWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IVendedorService _vendedorService;

        public PedidoController(IPedidoService pedidoService, IVendedorService vendedorService)
        {
            _pedidoService = pedidoService;
            _vendedorService = vendedorService;
        }

        public async Task<IActionResult> Index()
        {
            //var pedidos = await _pedidoService.Listar();
            var pedidos = new List<Pedido>();
            return View(pedidos);
        }

        public async Task<IActionResult> Cadastrar()
        {
            //var vendedores = await _vendedoresService.Listar();
            var vendedores = new List<Vendedor>();
            var viewModel = new PedidoFormViewModel { Vendedores = vendedores };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                //var vendedores = await _vendedoresService.Listar();
                //var viewModel = new PedidoFormViewModel { Pedido = pedido, Vendedores = vendedores };

                var viewModel = new Object();
                return View(viewModel);
            }
            //await _vendedorService.Cadastrar(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            //var obj = await _pedidoService.ListarPorId(id.Value);

            var obj = new Vendedor();

            if (obj is null)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                //await _pedidoService.Deletar(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Detalhar(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            //var obj = await _pedidoService.ListarPorId(id.Value);

            var obj = new Vendedor();

            if (obj is null)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            //var obj = await _pedidoService.ListarPorId(id.Value);
            var obj = new Pedido();

            if (obj is null)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível editar, pedido inválido!" });

            //var vendedores = await _vendedorService.Listar();
            //PedidoFormViewModel viewModel = new PedidoFormViewModel { Pedido = obj, Vendedores = vendedores };

            var viewModel = new Object();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                //var vendedores = await _vendedorService.Listar();

                //var viewModel = new PedidoFormViewModel { Pedido = pedido, Vendedores = vendedores };

                var viewModel = new Object();
                return View(viewModel);
            }

            if (!id.Equals(pedido.Id))
                return RedirectToAction(nameof(Error), new { message = "Id é imcompatível" });

            try
            {
                //await _pedidoService.Atualizar(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
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
