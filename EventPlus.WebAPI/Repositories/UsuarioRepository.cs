using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Guid id, Usuario usuario)
        {
           var usuarioBuscado  = await _context.Usuario.FindAsync(id);

            if(usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;

                _context.Usuario.Update(usuarioBuscado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario?> BuscarPorEmailESenha(string email, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task Cadastrar(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var usuarioBuscado = await _context.Usuario.FindAsync(id);

            if(usuarioBuscado != null)
            {
                _context.Usuario.Remove(usuarioBuscado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _context.Usuario.AsNoTracking().ToListAsync();
        }
    }
}
