using Campeonatos.Dominio.Clubes;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Campeonatos.Infra.Cadastros.Implementacoes
{
    public class JogadorDAO : ICommomDAO<Jogador>
    {
        private readonly ApplicationDbContext _context;
        public JogadorDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Jogador entity)
        {
            try
            {
                _context.Jogadores.Add(entity);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Jogador entity)
        {
            try
            {
                _context.Jogadores.Remove(entity);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Jogador>> GetAll()
        {
            return await _context.Jogadores.AsNoTracking().Include(p => p.Clube).ToListAsync();
        }

        public async Task<Jogador> GetById(int id)
        {
            var retorno = await _context.Jogadores.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();
            if (retorno == null)
            {
                throw new Exception("Nenhum registro retornado");
            }
            return retorno;
        }

        public async Task<bool> Update(Jogador entity)
        {
            try
            {
                _context.Jogadores.Update(entity);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
