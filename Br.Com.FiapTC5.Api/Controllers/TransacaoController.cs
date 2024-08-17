using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("transacao")]
    public class TransacaoController(ITransacaoService transacaoService) : ControllerBase
    {
        private readonly ITransacaoService _transacaoService = transacaoService;

        [HttpGet("obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var transacoes = await _transacaoService.Obter();
                return Ok(transacoes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
