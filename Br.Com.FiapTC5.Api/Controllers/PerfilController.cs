using Br.Com.FiapTC5.Application.Services;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("perfil")]
    public class PerfilController(IPerfilService perfilService) : ControllerBase
    {
        private readonly IPerfilService _perfilService = perfilService;

        [HttpGet("obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var perfis= await _perfilService.Obter();
                return Ok(perfis);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("obter/{codigo}")]
        public async Task<IActionResult> Obter(int codigo)
        {
            try
            {
                var pefil = await _perfilService.ObterPorId(codigo);
                return Ok(pefil);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
