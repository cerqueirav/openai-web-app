using GptApi.Models;
using GptApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IOpenAiService _openAiService;

        public ImagesController(IOpenAiService openAiService)
        {
            _openAiService = openAiService; 
        }

        [HttpPost("/images/new")]
        public async Task<IActionResult> Create([FromBody]ImageViewModel model)
        {
            try
            {
                var imageResult = await _openAiService.CreateImage(model);

                if (imageResult is not null && !imageResult.Count.Equals(0))
                    return Ok(new ResultImageViewModel((List<string>)imageResult));
            }

            catch(Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento" + ex);
            }

            return NotFound("Não foi encontrado nenhum resultado para a pesquisa!");
        }

        [HttpPost("/images/edit")]
        public async Task<IActionResult> CreateEdit([FromBody] ImageEditViewModel model)
        {
            try
            {
                var imageResult = await _openAiService.CreateImageEdit(model);

                if (imageResult is not null && !imageResult.Count.Equals(0))
                    return Ok(imageResult.ToList<String>());
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento" + ex);
            }

            return NotFound("Não foi encontrado nenhum resultado para a pesquisa!");
        }
    }
}
