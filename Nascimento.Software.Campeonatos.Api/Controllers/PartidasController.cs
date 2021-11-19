using AutoMapper;
using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Dominio.Tabela;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Campeonatos.Api.models.DTO;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PartidasController : ControllerBase
    {

        private readonly IPartidaService _service;
        private readonly IFinalizacaoPartidaService _finalizacaoService;
        private readonly IMapper _mapper;
        public PartidasController(IPartidaService service,
            IFinalizacaoPartidaService finalizcaoService,
            IMapper mapper)
        {
            _service = service;
            _finalizacaoService = finalizcaoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listarTodasPartidas")]
        public async Task<ActionResult> Get(bool incluirJogadores = false)
        {
            try
            {
                var entidade = await _service.ListarPartidas(incluirJogadores);
                if (entidade == null)
                {
                    throw new Exception("Nenhum registro retornado.");
                }
                var entidadeMapeada = _mapper.Map<IEnumerable<PartidaDTO>>(entidade);
                return Ok(entidadeMapeada);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("listarPorId/{id}")]
        public async Task<ActionResult> ListarPorId(int id, bool incluirJogadores = false)
        {
            try
            {
                var entidade = await _service.ListarPartidaPorId(id, incluirJogadores);
                if (entidade == null)
                {
                    throw new Exception("Nenhum registro retornado.");
                }

                var entidadeMapeada = _mapper.Map<PartidaDTO>(entidade);
                return Ok(entidadeMapeada);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("registrarPartida")]
        public async Task<ActionResult> RegistrarPartida(PartidaCadastroDTO model)
        {
            try
            {
                return Ok(await _service.RegistrarPartida(_mapper.Map<Partidas>(model)));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("finalizarPartida")]
        public async Task<ActionResult> FinalizarPartida(PartidaFinalizacaoRegistroDTO model)
        {
            //Mapeando na mão
            var partida = new PartidaFinalizacao()
            {
                GolsMandante = model.GolsMandante,
                GolsVisitante = model.GolsVisitante,
                PartidasId = model.PartidasId,
                TeveVencedor = model.TeveVencedor,
                VencedorId = model.VencedorId,
            };
            int qtdeGolsRegistro = 0;
            if (model.Gols != null)
            {
                foreach (var item in model.Gols)
                {
                    qtdeGolsRegistro += item.Gols;
                }
                if (qtdeGolsRegistro > model.GolsMandante + model.GolsVisitante)
                {
                    return BadRequest(@"Ocorreu um erro, a quantidade de gols assinalada para os jogadores é maior do que o total de gols da partida");
                }
            }
            int qtdeAssistencias = 0;
            if (model.Assistencias != null)
            {
                foreach (var item in model.Assistencias)
                {
                    qtdeAssistencias += item.QtdeAssistencias;
                }
                if (qtdeAssistencias > model.GolsMandante + model.GolsVisitante)
                {
                    return BadRequest("Ocorreu um erro, a quantidade de assistências para os jogadores é maior do que o total de gols da partida");
                }
            }

            var golsMapeado = _mapper.Map<List<Artilharia>>(model.Gols);
            var assistencias = _mapper.Map<List<Assistencias>>(model.Assistencias);
            var amarelos = _mapper.Map<List<Amarelos>>(model.Amarelos);
            var vermelhos = _mapper.Map<List<Vermelhos>>(model.Vermelhos);

            var operacao = await _finalizacaoService.RegistrarFinalizacao(partida,
                golsMapeado, assistencias,
                amarelos, vermelhos);

            if (operacao)
            {
                return Ok("Sucesso");
            }
            return BadRequest("Não foi possível cadastrar");

        }

    }
}
