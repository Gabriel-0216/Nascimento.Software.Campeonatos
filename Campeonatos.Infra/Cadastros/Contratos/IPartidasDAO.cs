using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Infra.Cadastros.Contratos
{
    public interface IPartidasDAO
    {
        Task<bool> RegistrarPartida(Partidas entidade);
        Task<bool> DeletarPartida(Partidas entidade);
        Task<bool> EditarPartida(Partidas entidade);
        Task<Partidas> ListarPartidaPorId(int id, bool incluirJogadores = false);
        Task<IEnumerable<Partidas>> ListarPartidas(bool incluirJogadores = false);
        Task<IEnumerable<Partidas>> ListarPartidasPorClube(int? id, 
            Clube? clube,
            bool incluirJogadores = false);

    }
}
