using Campeonatos.Dominio.Tabela;

namespace Campeonatos.Application.Servicos.Contratos
{
    public interface ITabelasService
    {
        Task<IEnumerable<Artilharia>> ListarArtilharia();
        Task<Artilharia> RetornarArtilheiroPorId(int id);
        Task<IEnumerable<Assistencias>> ListarAssistencias();
        Task<Assistencias> RetornarAssistenciasPorId(int id);
        Task<IEnumerable<Amarelos>> ListarAmarelos();
        Task<Amarelos> RetornarAmarelosPorId(int id);
        Task<IEnumerable<Vermelhos>> ListarVermelhos();
        Task<Vermelhos> RetornarVermelhosPorId(int id);

    }
}
