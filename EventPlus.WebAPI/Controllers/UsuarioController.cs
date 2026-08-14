using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")] //http://localhost:sua porta/api/sua controller(no caso Usuario)
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTO dto)
        {
            var usuario = new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _usuario.Cadastrar(usuario);

            return StatusCode(201, usuario);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioDTO dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _usuario.Atualizar(id, usuario);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _usuario.Listar();

                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var usuarioBuscado = await _usuario.BuscarPorId(id);

            if (usuarioBuscado == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuarioBuscado);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _usuario.Deletar(id);
            return NoContent();
        }

        [HttpGet("BuscarEmailSenha")]
        public async Task<IActionResult> BuscarPorEmailESenha([FromBody] LoginDTO dto)
        {
            var usuario = new Usuario
            {
                Email = dto.Email,
                Senha = dto.Senha
            };

            var usuarioBuscado = await _usuario.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuarioBuscado);
        }
    }
}
