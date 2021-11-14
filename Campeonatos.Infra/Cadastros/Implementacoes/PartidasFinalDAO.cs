using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Infra.Cadastros.Implementacoes
{
    public class PartidasFinalDAO : IFinalizacaoPartidaDAO
    {
        private readonly ApplicationDbContext _context;
        public PartidasFinalDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegistrarFinalizacao(PartidaFinalizacao partida, 
            List<Artilharia> gols, List<Assistencias> assistencias, 
            List<Amarelos> cartoesAmarelos, List<Vermelhos> cartoesVermelhos)
        {
            try
            {
                if (partida == null) return false;

                _context.PartidaFinalizacao.Add(partida);

                if (gols != null)
                {
                    foreach(var item in gols)
                    {
                        _context.Artilharia.Add(item);
                    }
                }
                if(assistencias != null)
                {
                    foreach(var item in assistencias)
                    {
                        _context.Assistencias.Add(item);
                    }
                }
                if(cartoesAmarelos != null)
                {
                    foreach(var item in cartoesAmarelos)
                    {
                        _context.Amarelos.Add(item);
                    }
                }
                if(cartoesVermelhos != null)
                {
                    foreach(var item in cartoesVermelhos)
                    {
                        _context.Vermelhos.Add(item);
                    }
                }

                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro {e.Message}");
            }
        }

        public async Task<PartidaFinalizacao> RetornarPartidaPorId(int id)
        {
            try
            {
                var entidade = await _context.PartidaFinalizacao.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (entidade != null) return entidade;
                throw new Exception("Essa partida não existe");
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro, {e.Message}");
            }
        }

        public async Task<IEnumerable<PartidaFinalizacao>> RetornarPartidasPorClube(int? clubeId, Clube clube)
        {
            throw new NotImplementedException();
        }
    }
}
