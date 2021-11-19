using Campeonatos.Dominio.Clubes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonatos.Dominio.Tabela
{
    public class Amarelos
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        [ForeignKey("JogadorId")]
        public Jogador Jogador { get; set; }
        public int QtdeAmarelos { get; set; }
    }
}
