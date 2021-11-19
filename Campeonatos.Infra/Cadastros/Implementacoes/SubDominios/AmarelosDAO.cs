using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Campeonatos.Infra.Cadastros.Implementacoes.SubDominios
{
    public class AmarelosDAO : ICommomDAO<Amarelos>
    {
        private readonly ApplicationDbContext _context;

        public AmarelosDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Amarelos entity)
        {
            _context.Amarelos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Amarelos entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Amarelos>> GetAll()
        {
            return await _context.Amarelos.Include(p => p.Jogador).AsNoTracking().ToListAsync();
        }

        public Task<Amarelos> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Amarelos entity)
        {
            throw new NotImplementedException();
        }
    }
}
