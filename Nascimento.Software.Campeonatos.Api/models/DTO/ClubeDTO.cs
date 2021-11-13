using Campeonatos.Dominio.Clubes;

namespace Nascimento.Software.Campeonatos.Api.models.DTO
{
    public class ClubeDTO
    {
        public string? Nome { get; set; }
        public ICollection<JogadorDTO> Jogadores { get; set; }
    }
}
