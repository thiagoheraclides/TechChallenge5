using Br.Com.FiapTC5.Application.Services;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase 
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpGet("obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var usuarios = await _usuarioService.Obter();
                return Ok(usuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
