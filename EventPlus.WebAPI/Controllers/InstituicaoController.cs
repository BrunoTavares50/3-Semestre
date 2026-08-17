using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicao;

        public InstituicaoController(IInstituicao instituicao)
        {
            _instituicao = instituicao;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var instituicao = await _instituicao.Listar();
                return Ok(instituicao);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                var instituicao = await _instituicao.BuscarPorId(id);
                return Ok(instituicao);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] InstituicaoDTO dto)
        {
            var instituicao = new Instituicao
            {
                Cnpj = dto.CNPJ,
                NomeFantasia = dto.NomeFantasia,
                Endereco = dto.Endereco
            };

            await _instituicao.Cadastrar(instituicao);

            return StatusCode(201, instituicao);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] InstituicaoDTO dto)
        {
            var instituicao = new Instituicao
            {
                Cnpj = dto.CNPJ,
                NomeFantasia = dto.NomeFantasia,
                Endereco = dto.Endereco
            };

            await _instituicao.Atualizar(id, instituicao);
            return Ok(instituicao);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _instituicao.Deletar(id);
            return NoContent();
        }
    }
}
