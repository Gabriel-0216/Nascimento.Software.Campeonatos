using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Campeonatos.Infra.Cadastros.Implementacoes.SubDominios
{
    public class ArtilhariaDAO : ICommomDAO<Artilharia>
    {
        private readonly ApplicationDbContext _context;
        public ArtilhariaDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Artilharia entity)
        {
            _context.Artilharia.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Artilharia entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artilharia>> GetAll()
        {
            return await _context.Artilharia.Include(p => p.Jogador).AsNoTracking().ToListAsync();
        }

        public async Task<Artilharia> GetById(int id)
        {
            var entidade = await _context.Artilharia.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entidade != null)
            {
                return entidade;
            }
            throw new Exception("Não existe registro de artilharia com esse id");
        }

        public Task<bool> Update(Artilharia entity)
        {
            throw new NotImplementedException();
        }
    }
}
