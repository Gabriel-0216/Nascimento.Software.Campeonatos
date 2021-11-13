using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Dominio.Clubes
{
    public class Clube
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }

    }
}
