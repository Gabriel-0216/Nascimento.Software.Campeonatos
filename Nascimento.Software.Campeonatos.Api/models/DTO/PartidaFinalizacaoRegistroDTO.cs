using Nascimento.Software.Campeonatos.Api.models.DTO.Subdominios;

namespace Nascimento.Software.Campeonatos.Api.models.DTO
{
    public class PartidaFinalizacaoRegistroDTO
    {
        public int PartidasId { get; set; }
        public bool TeveVencedor { get; set; }
        public int VencedorId { get; set; }
        public int GolsMandante { get; set; }
        public int GolsVisitante { get; set; }
        public ICollection<GolsCadastroDTO>? Gols { get; set; }
        public ICollection<AssistenciasCadastroDTO>? Assistencias { get; set; }
        public ICollection<AmarelosCadastroDTO> Amarelos { get; set; }
        public ICollection<VermelhoCadastroDTO> Vermelhos { get; set; }

    }
}
