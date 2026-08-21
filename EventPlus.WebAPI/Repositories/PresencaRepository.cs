using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class PresencaRepository : IPresenca
    {
        private readonly EventContext _context;

        public PresencaRepository(EventContext context)
        {
            _context = context;
        }

        public async Task AtualizarSituacao(Guid id, Presenca situacao)
        {
            var presencaBuscada = await _context.Presenca.FindAsync(id);

            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = situacao.Situacao;
                presencaBuscada.IdEvento = situacao.IdEvento == null ? presencaBuscada.IdEvento : situacao.IdEvento;
                presencaBuscada.IdUsuario = situacao.IdUsuario == null ? presencaBuscada.IdUsuario : situacao.IdUsuario;

                _context.Presenca.Update(presencaBuscada);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Presenca?> BuscarPorId(Guid id)
        {
            return await _context.Presenca.FirstOrDefaultAsync(p => p.IdPresenca == id);
        }

        public async Task Deletar(Guid id)
        {
            var presencaBuscada = await _context.Presenca.FindAsync(id);

            if (presencaBuscada != null)
            {
                _context.Presenca.Remove(presencaBuscada);

                await _context.SaveChangesAsync();
            }
        }

        public async Task Inscrever(Presenca presenca)
        {
            await _context.Presenca.AddAsync(presenca);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Presenca>> Listar()
        {
            return await _context.Presenca.AsNoTracking().ToListAsync();
        }

        public async Task<List<Presenca>> ListarMinhasPresencas(Guid id)
        {
            return await _context.Presenca.Where(p => p.IdPresenca == id).AsNoTracking().ToListAsync();
        }
    }
}
