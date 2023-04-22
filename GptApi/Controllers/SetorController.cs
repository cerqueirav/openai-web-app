using GptApi.DTO;
using GptApi.Models;
using GptApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepository _setorRepository;
        public SetorController(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var setores = _setorRepository.Listar();

                if (setores is not null)
                    return Ok(setores); 
            }
            catch (Exception ex)
            {
                return NotFound("Nenhum setor cadastrado!" + ex);
            }

            return BadRequest("Não foi possível realizar o processamento!");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ListarPorId(int id)
        {
            try
            {
                var setores = _setorRepository.ListarPorId(id);

                if (setores is not null)
                    return Ok(setores);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento!" + ex);
            }

            return NotFound("Não foi possível localizar o setor!");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] SetorDto setorDto)
        {
            try
            {
                var setor = _setorRepository.Cadastrar(new Setor(setorDto.Nome));

                if (setor is not null)
                    return Ok(setor);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar a criação do setor!" + ex);
            }

            return BadRequest("Não foi possível realizar o processamento!");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var setor = _setorRepository.ListarPorId(id);

                if (setor is not null)
                {
                    try
                    {
                        _setorRepository.Deletar(setor);
                        return NoContent();
                    }
                    catch(Exception ex)
                    {
                        return BadRequest("Não foi possível realizar o processamento!");
                    }
                }
                return NotFound("Não foi possível localizar o setor!");
            }
            catch(Exception ex)
            {
                return BadRequest("Não foi possível realizar o processamento!" + ex);
            }
        }
    }
}
