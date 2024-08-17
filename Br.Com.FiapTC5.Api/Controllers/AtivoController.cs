using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("ativo")]
    public class AtivoController(IAtivoService ativoService) : ControllerBase
    {
        private readonly IAtivoService _ativoService = ativoService;

        [HttpGet("obter")]
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
    }
}
