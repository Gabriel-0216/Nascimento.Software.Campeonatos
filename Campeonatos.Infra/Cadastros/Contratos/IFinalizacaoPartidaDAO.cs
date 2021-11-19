using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;

namespace Campeonatos.Infra.Cadastros.Contratos
{
    public interface IFinalizacaoPartidaDAO
    {
        Task<bool> RegistrarFinalizacao(PartidaFinalizacao partida,
            List<Artilharia> gols, List<Assistencias> assistencias,
            List<Amarelos> cartoesAmarelos, List<Vermelhos> cartoesVermelhos);
        Task<PartidaFinalizacao> RetornarPartidaPorId(int id);
        Task<IEnumerable<PartidaFinalizacao>> RetornarPartidasPorClube(int? clubeId, Clube clube);

    }
}
