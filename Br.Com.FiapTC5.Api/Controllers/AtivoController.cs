using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("ativo")]
    public class AtivoController(IAtivoService ativoService) : ControllerBase
    {
        private readonly IAtivoService _ativoService = ativoService;

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var ativos = await _ativoService.Obter();
                return Ok(ativos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("usuario/{codigoUsuario}")]
        public async Task<IActionResult> Obter(int codigoUsuario)
        {
            try
            {
                IEnumerable<Ativo> ativos = await _ativoService.ObterPorUsuario(codigoUsuario);
                return Ok(ativos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
