using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonatos.Dominio.Clubes
{
    public class Jogador : Pessoa
    {
        public int Id { get; set; }
        public int NumCamisa { get; set; }
        public int ClubeId { get; set; }
        [ForeignKey("ClubeId")]
        public Clube Clube { get; set; }
        public int Gols { get; set; } = 0;
        public int Assistencias { get; set; } = 0;
        public int Amarelos { get; set; } = 0;
        public int Vermelhos { get; set; } = 0;
    }
}
