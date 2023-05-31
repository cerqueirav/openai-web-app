using Microsoft.AspNetCore.Mvc;
using GptWeb.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace GptWeb.Controllers
{
    public class ImagesController : Controller
    {
        #region ATRIBUTOS E CONSTRUTORES
        private readonly string URLBASE = "https://localhost:7158/";
        
        private readonly ILogger<ImagesController> _logger;
        private readonly HttpClient client;

        public ImagesController(ILogger<ImagesController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            client.BaseAddress = new Uri(URLBASE);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsultarImagemViewModel model)
        {
            string uri = URLBASE + "images/new";
            var response = await client.PostAsJsonAsync(uri, model);

            if (response.IsSuccessStatusCode)
            {
                var retorno = response.Content.ReadAsStringAsync().Result;
                DetalharImagem contentResult = new DetalharImagem();
                
                var imagensJson = JsonConvert.DeserializeObject<DetalharImagem>(retorno);

                if (imagensJson is not null)
                    contentResult = imagensJson;

                contentResult.descricao = model.title;

                return View(contentResult);
            }
            else
            {
                await response.Content.ReadAsStringAsync();
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}