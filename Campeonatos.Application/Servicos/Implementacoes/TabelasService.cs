using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Cadastros.Implementacoes.SubDominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Application.Servicos.Implementacoes
{
    public class TabelasService : ITabelasService
    {
        private readonly ICommomDAO<Amarelos> _AmarelosDAO;
        private readonly ICommomDAO<Vermelhos> _VermelhosDAO;
        private readonly ICommomDAO<Artilharia> _ArtilhariaDAO;
        private readonly ICommomDAO<Assistencias> _AssistenciasDAO;
        public TabelasService(ICommomDAO<Amarelos> amarelos, ICommomDAO<Vermelhos> vemrelhos,
            ICommomDAO<Artilharia> artilharia, ICommomDAO<Assistencias> assistencias)
        {
            _AmarelosDAO = amarelos;
            _VermelhosDAO = vemrelhos;
            _ArtilhariaDAO = artilharia;
            _AssistenciasDAO = assistencias;
        }
        public async Task<IEnumerable<Amarelos>> ListarAmarelos()
        {
            return await _AmarelosDAO.GetAll();
        }

        public async Task<IEnumerable<Artilharia>> ListarArtilharia()
        {
            return await _ArtilhariaDAO.GetAll();
        }

        public async Task<IEnumerable<Assistencias>> ListarAssistencias()
        {
            return await _AssistenciasDAO.GetAll();
        }

        public async Task<IEnumerable<Vermelhos>> ListarVermelhos()
        {
            return await _VermelhosDAO.GetAll();
        }

        public async Task<Amarelos> RetornarAmarelosPorId(int id)
        {
            return await _AmarelosDAO.GetById(id);
        }

        public async Task<Artilharia> RetornarArtilheiroPorId(int id)
        {
            return await _ArtilhariaDAO.GetById(id);
        }

        public async Task<Assistencias> RetornarAssistenciasPorId(int id)
        {
            return await _AssistenciasDAO.GetById(id);
        }

        public async Task<Vermelhos> RetornarVermelhosPorId(int id)
        {
            return await _VermelhosDAO.GetById(id);
        }
    }
}
