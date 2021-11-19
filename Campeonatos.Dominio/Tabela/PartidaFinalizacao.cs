using Campeonatos.Dominio.Clubes;

namespace Campeonatos.Dominio.Tabela
{
    public class PartidaFinalizacao
    {
        public int Id { get; set; }
        public int PartidasId { get; set; }
        public Partidas Partida { get; set; }
        public bool TeveVencedor { get; set; }
        public int VencedorId { get; set; }
        public Clube Vencedor { get; set; }
        public int GolsMandante { get; set; }
        public int GolsVisitante { get; set; }

    }
}
