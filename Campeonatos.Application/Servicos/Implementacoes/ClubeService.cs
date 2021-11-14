using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Infra.Cadastros.Contratos;

namespace Campeonatos.Application.Servicos.Implementacoes
{
    public class ClubeService : ICommomService<Clube>
    {
        private readonly ICommomDAO<Clube> _clubeDAO;
        private readonly ICommomDAO<Jogador> _jogadorDAO;
        public ClubeService(ICommomDAO<Clube> clubeDAO, 
            ICommomDAO<Jogador> jogadorDAO)
        {
            _jogadorDAO = jogadorDAO;
            _clubeDAO = clubeDAO;
        }
        public async Task<bool> Add(Clube entity)
        {
            try
            {
                if (await _clubeDAO.Add(entity)) return true;

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }

        public async Task<bool> Delete(Clube entity)
        {
            try
            {
                var jogadorClube = await _jogadorDAO.GetAll();
                jogadorClube = jogadorClube.Where(p => p.ClubeId == entity.Id);
                
                if(jogadorClube.Count() > 0)
                {
                    return false;
                }

                if (await _clubeDAO.Delete(entity)) return true;
                
               
                return false;
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro {e.Message}");
            }
        }

        public async Task<Clube> Get(int id)
        {
            var entity = await _clubeDAO.GetById(id);
            if (entity != null) return entity;

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<Clube>> GetAll()
        {
            return await _clubeDAO.GetAll();
        }

        public async Task<bool> Update(Clube entity)
        {
            try
            {
                var clubeExists = await Get(entity.Id);
                if (clubeExists == null) return false;


                if (await _clubeDAO.Update(entity)) return true;

                return false;
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro {e.Message}");
            }
        }
    }
}
