using AutoMapper;
using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Clubes;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Campeonatos.Api.models.DTO;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly ICommomService<Jogador> _jogadorService;
        private readonly IMapper _mapper;
        public JogadorController(ICommomService<Jogador> service,
            IMapper mapper)
        {
            _mapper = mapper;
            _jogadorService = service;
        }

        /// <summary>
        /// Retornar todos os jogadores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var jogadoresDTO = _mapper
                    .Map<IEnumerable<JogadorDTO>>(await _jogadorService.GetAll());
                return Ok(jogadoresDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registrar um jogador no sistemas
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(JogadorDTO post)
        {
            try
            {
                var entity = _mapper.Map<Jogador>(post);
                if (await _jogadorService.Add(entity)) return Ok("Cadastrado");

                return BadRequest("Não foi possível cadastrar");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entidade = await _jogadorService.Get(id);
                if(entidade != null)
                { 
                   var sucesso = await _jogadorService.Delete(entidade);
                    if(sucesso == true)
                    {
                        return Ok("deletado");
                    }
                }

                return BadRequest("Não foi possível efetuar o delete.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("edit/{id:int}")]
        public async Task<ActionResult> Edit(JogadorDTO edit, int id)
        {
            try
            {
                var entidadeMapeada = _mapper.Map<Jogador>(edit);
                entidadeMapeada.Id = id;
                var sucesso = await _jogadorService.Update(entidadeMapeada);
                if (sucesso == true) return Ok("Operação realizada com sucesso");

                return BadRequest("Não foi possível editar o registro.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("listarJogadoresPorClube")]
        public async Task<ActionResult> ListarJogadoresPorClube(int id)
        {
            try
            {
                var jogadores = await _jogadorService.GetAll();
                jogadores = jogadores.Where(p => p.ClubeId == id);
                if (jogadores.Count() > 0) return Ok(_mapper
                    .Map<IEnumerable<JogadorDTO>>(jogadores));

                return BadRequest("Esse clube não existe ou não tem jogadores cadastrados");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
