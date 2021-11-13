﻿using Campeonatos.Dominio.Clubes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Dominio.Tabela
{
    public class Vermelhos
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }

        [ForeignKey("JogadorId")]
        public Jogador Jogador { get; set; }
        public int QtdeVermelhos { get; set; }
    }
}