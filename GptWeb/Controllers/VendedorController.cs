using Microsoft.AspNetCore.Mvc;
using GptWeb.Models;
using GptWeb.Models.ViewModels;
using System.Diagnostics;
using GptWeb.Services;

namespace GptWeb.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IVendedorService _vendedorService;
        private readonly ISetorService _setorService;
        public VendedorController(IVendedorService vendedorService, ISetorService setorService)
        {
            _vendedorService = vendedorService;
            _setorService = setorService;
        }
        public async Task<IActionResult> Index()
        {
            //var vendedores = await _vendedorService.Listar();
            var vendedores = new List<Vendedor>();
            return View(vendedores);
        }

        public async Task<IActionResult> Cadastrar()
        {
            //var setores = await _setorService.Listar();
            var setores = new List<Setor>();
            var viewModel = new VendedorFormViewModel { Setores = setores };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                //var setores = await _setorService.Listar();
                var setores = new List<Setor>();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Setores = setores };
                return View(viewModel);
            }
            //await _vendedorService.Cadastrar(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if(!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Id não informado" });

            //var obj = await _vendedorService.ListarPorId(id.Value);

            var obj = new Vendedor();

            if(obj is null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                //await _vendedorService.Deletar(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Detalhar(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            //var obj = await _vendedorService.ListarPorId(id.Value);

            var obj = new Vendedor();

            if (obj is null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
          
            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if(!id.HasValue)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            //var obj = await _vendedorService.ListarPorId(id.Value);
            var obj = new Vendedor();
 
            if(obj is null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            //var setores = await _setorService.Listar();
            var setores = new List<Setor>();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Setores = setores };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                //var setores = await _setorService.Listar();
                var setores = new List<Setor>();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Setores = setores };
                return View(viewModel);
            }

            if (!id.Equals(vendedor.Id))
                return RedirectToAction(nameof(Error), new { message = "Id é imcompatível" });

            try
            {
                //await _vendedorService.Atualizar(vendedor);
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
    }
}
