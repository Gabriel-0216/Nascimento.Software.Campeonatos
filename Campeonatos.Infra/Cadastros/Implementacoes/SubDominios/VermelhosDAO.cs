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
    public class VermelhosDAO : ICommomDAO<Vermelhos>
    {
        private readonly ApplicationDbContext _context;

        public VermelhosDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Vermelhos entity)
        {
            _context.Vermelhos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Vermelhos entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vermelhos>> GetAll()
        {
            return await _context.Vermelhos.Include(p => p.Jogador).AsNoTracking().ToListAsync();
        }

        public Task<Vermelhos> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Vermelhos entity)
        {
            throw new NotImplementedException();
        }
    }
}
