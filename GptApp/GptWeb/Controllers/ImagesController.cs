﻿using Microsoft.AspNetCore.Mvc;
using GptWeb.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GptWeb.Models.JsonDeserialized;

namespace GptWeb.Controllers
{
    public class ImagesController : Controller
    {
        #region ATRIBUTOS E CONSTRUTORES
        private readonly string URLBASE = "https://localhost:44391/";
        private readonly ILogger<ImagesController> _logger;
        private readonly HttpClient client;
        private HttpResponseMessage response;

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
            response = await client.PostAsJsonAsync(uri, model);

            if (response.IsSuccessStatusCode)
            {
                var retorno = response.Content.ReadAsStringAsync().Result;
                DetalharImagem contentResult = new DetalharImagem();

                var imagensJson = JsonConvert.DeserializeObject<DetalharImagem>(retorno);

                if (imagensJson is not null)
                    contentResult = imagensJson;

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