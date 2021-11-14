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
    public class PartidaService : IPartidaService
    {
        private readonly IPartidasDAO _DAO;
        private readonly ICommomService<Clube> _clubeService;
        public PartidaService(IPartidasDAO dao,
            ICommomService<Clube> clubeService)
        {
            _DAO = dao;
            _clubeService = clubeService;
        }
        public async Task<bool> DeletarPartida(Partidas entidade)
        {
            try
            {
                //verificar se a partida já foi finalizada.

                var delete = await _DAO.DeletarPartida(entidade);
                return delete;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditarPartida(Partidas entidade)
        {
            try
            {
                var edit = await _DAO.EditarPartida(entidade);
                return edit;
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
                var partida = await _DAO.ListarPartidaPorId(id, incluirJogadores);
                if (partida != null) return partida;

                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception("Nâo existe partida registrada como esse id.");
            }
        }

        public async Task<IEnumerable<Partidas>> ListarPartidas(bool incluirJogadores = false)
        {
            try
            {
                return await _DAO.ListarPartidas(incluirJogadores);
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro. {e.Message}");
            }
        }

        public async Task<IEnumerable<Partidas>> ListarPartidasPorClube(int? id, Clube? clube, bool incluirJogadores = false)
        {
            try
            {
                return await _DAO.ListarPartidasPorClube(id, clube, incluirJogadores);
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro {e.Message}");
            }
        }

        public async Task<bool> RegistrarPartida(Partidas entidade)
        {
            try
            {
                //verificar se os times existem.
                var mandanteExists = await _clubeService.Get(entidade.MandanteId);
                if (mandanteExists == null)
                {
                    throw new Exception("Clube mandante não existe.");
                }

                var visitanteExists = await _clubeService.Get(entidade.VisitanteId);
                if(visitanteExists == null)
                {
                    throw new Exception("Clube visitante não existe");
                }

                return await _DAO.RegistrarPartida(entidade);

            }
            catch(Exception e)
            {
                throw new Exception($"Não foi possível registrar a partida, {e.Message}");
            }
        }
    }
}
