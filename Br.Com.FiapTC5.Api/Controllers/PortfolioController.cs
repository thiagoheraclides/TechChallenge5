using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("portifolio")]
    public class PortfolioController(IPortifolioService portifolioService) : ControllerBase
    {
        private readonly IPortifolioService _portifolioService = portifolioService;

        [HttpGet("obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var portfolios = await _portifolioService.Obter();
                return Ok(portfolios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("usuario/{codigoUsuario}")]
        public async Task<IActionResult> ObterPorUsuario(int codigoUsuario)
        {
            try
            {
                var portfolio = await _portifolioService.ObterPorUsuario(codigoUsuario);
                return Ok(portfolio);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
