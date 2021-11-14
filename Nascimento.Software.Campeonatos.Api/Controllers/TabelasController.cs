using Campeonatos.Application.Servicos.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelasController : ControllerBase
    {
        private readonly ITabelasService _tabela;

        public TabelasController(ITabelasService tabela)
        {
            _tabela = tabela;
        }

        [HttpGet]
        [Route("listarArtilharia")]
        public async Task<ActionResult> ListarArtilharia()
        {
            return Ok(await _tabela.ListarArtilharia());
        }
        [HttpGet]
        [Route("listarAssistencias")]
        public async Task<ActionResult> ListarAssistencias()
        {
            return Ok(await _tabela.ListarAssistencias());
        }
        [HttpGet]
        [Route("listarAmarelos")]
        public async Task<ActionResult> ListarAmarelos()
        {
            return Ok(await _tabela.ListarAmarelos());
        }
        [HttpGet]
        [Route("listarVermelhos")]
        public async Task<ActionResult> ListarVermelhos()
        {
            return Ok(await _tabela.ListarVermelhos());
        }
    }
}
