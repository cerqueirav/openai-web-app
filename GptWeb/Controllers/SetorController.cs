using GptWeb.Services;
using Microsoft.AspNetCore.Mvc;
using GptWeb.Models;

namespace GptWeb.Controllers
{
    public class SetorController : Controller
    {
        private readonly ISetorService _setorService;

        public SetorController(ISetorService setorService)
        {
            _setorService = setorService;
        }

        public async Task<IActionResult> Index()
        {
            //return View(await _setorService.Listar());
            return View(new List<Setor>());
        }

        public async Task<IActionResult> Detalhar(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            //var setor = await _setorService.ListarPorId(id.Value);

            var setor = new Setor();

            if (setor is null)
                return NotFound();
            
            return View(setor);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("Id,Nome")] Setor Setor)
        {
            if (ModelState.IsValid)
            {
                //await _setorService.Cadastrar(Setor);
                return RedirectToAction(nameof(Index));
            }
            return View(Setor);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id is null)
                return NotFound();

            var setor = new Setor();
            //var setor = await _shopWebService.ConsultarPorId(id);

            if (setor is null)
                return NotFound();
            
            return View(setor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nome")] Setor Setor)
        {
            if (!id.Equals(Setor.Id))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    //await _setorService.Editar(id, Setor);
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao atualizar" + ex);
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(Setor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            //var setor = await _setorService.ListarPorId(id.Value);

            var setor = new Setor();

            if (setor == null)
                return NotFound();
            
            return View(setor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //var setor = await _setorService.Deletar(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possível excluir!");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SetorExiste(int id)
        {
            try
            {
                //var setor = await _setorService.ListarPorId(id);

                var setor = _setorService.ListarPorId(id);

                return (setor is not null);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
