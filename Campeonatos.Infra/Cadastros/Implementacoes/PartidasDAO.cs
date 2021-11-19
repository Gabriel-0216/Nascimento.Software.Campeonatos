using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Campeonatos.Infra.Cadastros.Implementacoes
{
    public class PartidasDAO : IPartidasDAO
    {
        private readonly ApplicationDbContext _context;

        public PartidasDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeletarPartida(Partidas entidade)
        {
            try
            {
                _context.Remove(entidade);
                if (await _context.SaveChangesAsync() > 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditarPartida(Partidas entidade)
        {
            try
            {
                _context.Partidas.Update(entidade);
                if (await _context.SaveChangesAsync() > 0) return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Partidas> ListarPartidaPorId(int id, bool incluirJogadores = false)
        {
            try
            {
                IQueryable<Partidas> query = _context.Partidas
                    .AsNoTracking()
                    .Where(p => p.Id == id);

                if (incluirJogadores)
                {
                    query = query.Include(p => p.Mandante).ThenInclude(d => d.Jogadores)
                        .Include(v => v.Visitante).ThenInclude(e => e.Jogadores);
                }

                var entidade = await query.FirstOrDefaultAsync();
                if (entidade != null)
                {
                    return entidade;
                }
                throw new Exception("ocorreu um erro");
            }
            catch (Exception)
            {
                throw new Exception("ocorreu um erro, essa partida não existe");
            }
        }

        public async Task<IEnumerable<Partidas>> ListarPartidas(bool incluirJogadores = false)
        {
            try
            {
                IQueryable<Partidas> query = _context.Partidas.AsNoTracking();

                if (incluirJogadores)
                {
                    query = query.Include(p => p.Mandante).ThenInclude(j => j.Jogadores)
                        .Include(v => v.Visitante).ThenInclude(d => d.Jogadores);
                }
                var lista = await query.ToListAsync();
                if (lista != null)
                {
                    return lista;
                }
                throw new Exception("ocorreu um erro");
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro {e.Message}");
            }
        }

        public async Task<IEnumerable<Partidas>> ListarPartidasPorClube(int? id,
            Clube? clube,
            bool incluirJogadores = false)
        {
            IQueryable<Partidas> query = _context.Partidas.AsNoTracking();
            if (id != null)
            {
                query = query.Where(p => p.MandanteId == id || p.VisitanteId == id);
            }

            if (clube != null)
            {
                query = query.Where(p => p.Mandante == clube || p.Visitante == clube);
            }

            if (incluirJogadores)
            {
                query = query.Include(p => p.Mandante).ThenInclude(j => j.Jogadores).
                    Include(v => v.Visitante).ThenInclude(vi => vi.Jogadores);
            }
            var lista = await query.ToListAsync();
            return lista;
        }

        public async Task<bool> RegistrarPartida(Partidas entidade)
        {
            try
            {
                _context.Partidas.Add(entidade);
                if (await _context.SaveChangesAsync() > 0) return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
