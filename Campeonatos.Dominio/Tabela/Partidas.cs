using Campeonatos.Dominio.Clubes;

namespace Campeonatos.Dominio.Tabela
{
    public class Partidas
    {
        public int Id { get; set; }
        public int MandanteId { get; set; }
        public Clube Mandante { get; set; }
        public int VisitanteId { get; set; }
        public Clube Visitante { get; set; }

    }
}
