using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;

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
