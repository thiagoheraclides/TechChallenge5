using Br.Com.FiapTC5.Api.DTO.Usuario;
using Br.Com.FiapTC5.Application.Services;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController(IUsuarioService usuarioService, IPerfilService perfilService) : ControllerBase 
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IPerfilService _perfilService = perfilService;

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

        [HttpPost("perfil")]
        public async Task<IActionResult> AssociarPerfil(UsuarioPerfilDTO usuarioPerfilDTO)
        {
            try
            {
                await _usuarioService.AssociarPerfil(usuarioPerfilDTO.CodigoUsuario, usuarioPerfilDTO.CodigoPerfil);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
