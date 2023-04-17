using GptApi.Services.Implementation;
using GptApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IOpenAiService _openAiService;
        public FilesController(IOpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpGet("/files/user/")]
        public async Task<IActionResult> GetAllFilesCreatedByUser()
        {
            try
            {
                var filesResult = await _openAiService.GetAllFiles();

                if (filesResult is not null && !filesResult.Count.Equals(0))
                    return Ok(filesResult); 
            }
            catch (Exception ex)
            {
                return NotFound("Nenhum arquivo encontrado!" + ex);
            }

            return BadRequest("Não foi possível realizar o processamento");
        }
    }
}
