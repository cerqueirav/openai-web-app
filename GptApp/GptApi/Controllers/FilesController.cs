using GptApi.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Files;

namespace GptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/files/user/")]
        public async Task<IActionResult> GetAllFilesCreatedByUser()
        {
            List<FileData> result = new List<FileData>();

            var token = _configuration.GetValue<string>("ChatGpt:Token");
            var openAIClient = new OpenAIClient(new OpenAIAuthentication(token));
            var filesResult = await openAIClient.FilesEndpoint.ListFilesAsync();

            try
            {
                if (filesResult is not null && !filesResult.Count.Equals(0))
                    foreach (var file in filesResult)
                        result.Add(file);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento" + ex);
            }

            return Ok(filesResult);
        }
    }
}
