using GptApi.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Images;

namespace GptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ImagesController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpPost("/images/new")]
        public async Task<IActionResult> Create([FromBody]ImageViewModel model)
        {
            ResultImageViewModel result = new ResultImageViewModel();

            try
            {
                var token = _configuration.GetValue<string>("ChatGpt:Token");
                var openAIClient = new OpenAIClient(new OpenAIAuthentication(token));

                ImageGenerationRequest imageGenerationRequest = 
                    new ImageGenerationRequest(model.title, model.qty, ImageSize.Small, model.save ? openAIClient.OpenAIAuthentication.OrganizationId : null);

                var imageResult = await openAIClient.ImagesEndPoint.GenerateImageAsync(imageGenerationRequest);

                if (imageResult is not null && !imageResult.Count.Equals(0))
                    result.imagens = (List<string>)imageResult;
            }

            catch(Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento" + ex);
            }

            return Ok(result);
        }

        [HttpPost("/images/edit")]
        public async Task<IActionResult> CreateEdit([FromBody] ImageEditViewModel model)
        {
            ResultImageViewModel result = new ResultImageViewModel();

            try
            {
                var token = _configuration.GetValue<string>("ChatGpt:Token");
                var openAIClient = new OpenAIClient(new OpenAIAuthentication(token));

               ImageEditRequest imageEditRequest = 
                    new ImageEditRequest(model.image, model.title, model.qty, ImageSize.Medium, model.save ? openAIClient.OpenAIAuthentication.OrganizationId: null);   
                       
                var imageResult = await openAIClient.ImagesEndPoint.CreateImageEditAsync(imageEditRequest);

                if (imageResult is not null && !imageResult.Count.Equals(0))
                    result.imagens = (List<string>)imageResult;
            }

            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento" + ex);
            }

            return Ok(result);
        }
    }
}
