using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Infra.Cadastros.Contratos;

namespace Campeonatos.Application.Servicos.Implementacoes
{
    public class JogadorService : ICommomService<Jogador>
    {
        private readonly ICommomDAO<Jogador> _JogadorDAO;
        private readonly ICommomDAO<Clube> _ClubeDAO;

        public JogadorService(ICommomDAO<Jogador> dao, ICommomDAO<Clube> clubeDAO)
        {
            _JogadorDAO = dao;
            _ClubeDAO = clubeDAO;
        }
        public async Task<bool> Add(Jogador entity)
        {
            try
            {
                var clubeExists = await _ClubeDAO.GetById(entity.ClubeId);
                if(clubeExists != null)
                {
                    if(await _JogadorDAO.Add(entity))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro: {e.Message}");
            }
        }

        public async Task<bool> Delete(Jogador entity)
        {
            try
            {
                if (await _JogadorDAO.Delete(entity))
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro: {e.Message}");
            }
        }

        public async Task<Jogador> Get(int id)
        {
            try
            {
                var entity = await _JogadorDAO.GetById(id);
                if(entity != null)
                {
                    return entity;
                }
                throw new NullReferenceException();
            }
            catch(Exception e)
            {
                throw new Exception($"Ocorreu um erro: {e.Message}");
            }
        }

        public async Task<IEnumerable<Jogador>> GetAll()
        {
            return await _JogadorDAO.GetAll();
        }

        public async Task<bool> Update(Jogador entity)
        {
            try
            {
                var clubeExists = await _ClubeDAO.GetById(entity.ClubeId);
                if (clubeExists == null) return false;

                var jogadorExists = await Get(entity.Id);
                if(jogadorExists == null) return false;

                if(await _JogadorDAO.Update(entity))
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
    }
}
