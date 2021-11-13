using Campeonatos.Dominio.Clubes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
