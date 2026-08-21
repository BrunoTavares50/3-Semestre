using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresenca _presenca;

        public PresencaController(IPresenca presenca)
        {
            _presenca = presenca;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var presenca = await _presenca.Listar();
                return Ok(presenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inscrever([FromBody] PresencaDTO dto)
        {
            var presenca = new Presenca()
            {
                Situacao = dto.Situacao,
                IdUsuario = dto.IdUsuario,
                IdEvento = dto.IdEvento
            };

            await _presenca.Inscrever(presenca);
            return StatusCode(201, presenca);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> AtualizarSituacao(Guid id, [FromBody] PresencaDTO dto)
        {
            var presenca = new Presenca()
            {
                Situacao = dto.Situacao,
                IdEvento = dto.IdEvento,
                IdUsuario = dto.IdUsuario
            };

            await _presenca.AtualizarSituacao(id, presenca);
            return Ok(presenca);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _presenca.Deletar(id);
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var presencaBuscada = await _presenca.BuscarPorId(id);

            if (presencaBuscada == null)
                return NotFound("Presença não encontrada.");

            return Ok(presencaBuscada);
        }

        [HttpGet("ListarMinhasPresencas/{id:guid}")]
        public async Task<IActionResult> ListarMinhasPresencas(Guid id)
        {
            try
            {
                var presenca = await _presenca.ListarMinhasPresencas(id);
                return Ok(presenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
