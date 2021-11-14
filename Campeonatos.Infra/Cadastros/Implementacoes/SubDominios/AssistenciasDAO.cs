using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Infra.Cadastros.Implementacoes.SubDominios
{
    public class AssistenciasDAO : ICommomDAO<Assistencias>
    {
        private readonly ApplicationDbContext _context;

        public AssistenciasDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Assistencias entity)
        {
            _context.Assistencias.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Assistencias entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Assistencias>> GetAll()
        {
            return await _context.Assistencias.Include(p => p.Jogador).AsNoTracking().ToListAsync();
        }

        public Task<Assistencias> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Assistencias entity)
        {
            throw new NotImplementedException();
        }
    }
}
