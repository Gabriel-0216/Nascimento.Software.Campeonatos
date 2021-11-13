using Campeonatos.Dominio.Clubes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
