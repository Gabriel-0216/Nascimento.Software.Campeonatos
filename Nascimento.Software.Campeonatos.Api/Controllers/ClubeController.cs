using AutoMapper;
using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Clubes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Campeonatos.Api.models.DTO;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubeController : ControllerBase
    {
        private readonly ICommomService<Clube> _clubeDAO;
        private readonly IMapper _mapper;
        public ClubeController(ICommomService<Clube> clube, IMapper mapper)
        {
            _mapper = mapper;
            _clubeDAO = clube;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult> Create(ClubeCadastroDTO clube)
        {
            try
            {
                if(await _clubeDAO.Add(_mapper.Map<Clube>(clube)))
                {
                    return Ok("cadastrado");
                }
                return BadRequest("Não foi possível cadastrar");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listarClubes")]
        public async Task<ActionResult> ListarClubes()
        {
            try
            {
                var entity = await _clubeDAO.GetAll();
                var entityDTO = _mapper.Map<IEnumerable<ClubeDTO>>(entity);
                return Ok(entityDTO);
                
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }

        [HttpGet]
        [Route("listarClubePorId")]
        public async Task<ActionResult> ListarClubePorId(int id)
        {
            try
            {
                var entidade = await _clubeDAO.Get(id);
                if (entidade == null) return BadRequest("Não existe um clube com esse id");

                var entidadeMapeada = _mapper.Map<ClubeDTO>(entidade);
                return Ok(entidadeMapeada);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
