using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _tipoEvento;

        public TipoEventoController(ITipoEvento tipoEvento)
        {
            _tipoEvento = tipoEvento;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _tipoEvento.Listar();

                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoEventoDTO dto)
        {
            var tipoEvento = new TipoEvento()
            {
                Titulo = dto.Titulo
            };

            await _tipoEvento.Cadastrar(tipoEvento);

            return StatusCode(201, tipoEvento);
        }

        /// <summary>
        /// Remove uma categoria de evento
        /// </summary>
        /// <param name="id">Id do objeto a ser excluído</param>
        /// <returns>Status Code NoContent se der certo e 400 caso haja exceção</returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                await _tipoEvento.Deletar(id);
                return Ok(id);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var tipoEventoBuscado = await _tipoEvento.BuscarPorId(id);

            if (tipoEventoBuscado == null)
            {
                return NotFound("Tipo de evento não foi encontrado.");
            }

            return Ok(tipoEventoBuscado);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TipoEventoDTO dto)
        {
            var tipoEvento = new TipoEvento
            {
                Titulo = dto.Titulo
            };

            await _tipoEvento.Atualizar(id, tipoEvento);
            return Ok(tipoEvento);
        }
    }
}
