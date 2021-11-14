using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Application.Servicos.Implementacoes
{
    public class FinalizacaoPartidaService : IFinalizacaoPartidaService
    {
        private readonly IFinalizacaoPartidaDAO _DAO;
        private readonly IPartidasDAO _partidaDAO;
        private readonly ICommomDAO<Jogador> _jogadorDAO;
        public FinalizacaoPartidaService(IFinalizacaoPartidaDAO DAO, 
            ICommomDAO<Jogador> jogadorDAO, IPartidasDAO partidaDAO )
        {
            _DAO = DAO;
            _partidaDAO = partidaDAO;
            _jogadorDAO = jogadorDAO;
        }
        public async Task<bool> RegistrarFinalizacao(PartidaFinalizacao partida, 
            List<Artilharia> gols, List<Assistencias> assistencias, 
            List<Amarelos> cartoesAmarelos, List<Vermelhos> cartoesVermelhos)
        {
            try
            {
                var partidaExists = _partidaDAO.ListarPartidaPorId(partida.PartidasId);
                if (partidaExists == null)
                {
                    throw new Exception("Partida não existe");
                }

                if(partida.TeveVencedor == false && (partida.GolsMandante - partida.GolsVisitante) != 0)
                {
                    throw new Exception(@"Erro, você informou que a partida terminou empatada, 
                        mas a diferença entre gols dos times é maior que zero");
                }

                var lista = new List<int>();
                foreach(var item in gols)
                {
                    lista.Add(item.JogadorId);
                }
                foreach(var item in assistencias)
                {
                    lista.Add(item.JogadorId);
                }
                foreach(var item in cartoesAmarelos)
                {
                    lista.Add(item.JogadorId);
                }
                foreach(var item in cartoesVermelhos)
                {
                    lista.Add(item.JogadorId);
                }
                var listaFormatada = lista.Distinct().ToList();
                foreach(var item in listaFormatada)
                {
                    var exists = _jogadorDAO.GetById(item);
                    if(exists == null) { throw new Exception("Jogador não existe"); }
                }

                var operacao = await _DAO.RegistrarFinalizacao(partida, gols, assistencias, cartoesAmarelos, cartoesVermelhos);

                return operacao;


            }catch(Exception ex)
            {
                throw new Exception($"ocorreu um erro {ex.Message}");
            }
        }

        public async Task<PartidaFinalizacao> RetornarPartidaPorId(int id)
        {
            try
            {
                return await _DAO.RetornarPartidaPorId(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro, {ex.Message}");
            }
        }

        public async Task<IEnumerable<PartidaFinalizacao>> RetornarPartidasPorClube(int? clubeId, Clube? clube)
        {
            throw new NotImplementedException();
        }
    }
}
