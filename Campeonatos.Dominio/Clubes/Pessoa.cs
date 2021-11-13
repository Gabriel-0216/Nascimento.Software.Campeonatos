using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Dominio.Clubes
{
    public class Pessoa
    {
        public Pessoa()
        {
            if (!Validacoes(DataNascimento))
            {
                throw new Exception("Não é possível cadastrar");
            }
        }

        private bool Validacoes(DateTime dataNascimento)
        {
            if(dataNascimento > DateTime.Now)
            {
                return false;
            }


            return true;
        }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
