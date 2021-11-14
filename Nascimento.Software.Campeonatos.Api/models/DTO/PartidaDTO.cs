namespace Nascimento.Software.Campeonatos.Api.models.DTO
{
    public class PartidaDTO
    {
        public int MandanteId { get; set; }
        public ClubeDTO Mandante { get; set; }
        public int VisitanteId { get; set; }
        public ClubeDTO Visitante { get; set; }
    }
}
