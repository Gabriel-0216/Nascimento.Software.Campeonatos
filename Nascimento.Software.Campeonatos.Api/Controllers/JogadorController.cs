using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Campeonatos.Api.models.DTO;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {

        /// <summary>
        /// Retornar todos os jogadores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
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
            return BadRequest();
        }
    }
}
