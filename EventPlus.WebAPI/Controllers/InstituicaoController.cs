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
        public async Task<IActionResult> Cadastrar(Guid id, Instituicao instituicao)
        {
            try
            {
                await _instituicao.Cadastrar(instituicao);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
