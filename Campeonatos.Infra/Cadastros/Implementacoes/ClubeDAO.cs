using Campeonatos.Dominio.Clubes;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Infra.Cadastros.Implementacoes
{
    public class ClubeDAO : ICommomDAO<Clube>
    {
        private readonly ApplicationDbContext _context;
        public ClubeDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Clube entity)
        {
            try
            {
                _context.Clubes.Add(entity);
                if(await _context.SaveChangesAsync() > 0){
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro, {e.Message}");
            }
        }

        public async Task<bool> Delete(Clube entity)
        {
            try
            {
                _context.Clubes.Remove(entity);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro, {e.Message}");
            }
        }

        public async Task<IEnumerable<Clube>> GetAll()
        {
            return await _context.Clubes
                .AsNoTracking()
                .Include(p => p.Jogadores)
                .ToListAsync();

        }

        public async Task<Clube> GetById(int id)
        {
            var entity = await _context.Clubes.FirstOrDefaultAsync(p => p.Id == id);
            if(entity != null)
            {
                return entity;
            }
            throw new Exception("Não existe nenhum clube com esse id");
        }

        public async Task<bool> Update(Clube entity)
        {
            try
            {
                _context.Clubes.Update(entity);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro, {e.Message}");
            }
        }
    }
}
