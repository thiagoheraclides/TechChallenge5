using Br.Com.FiapTC5.Api.DTO.Acesso;
using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("acesso")]
    public class AcessoController(IUsuarioService usuarioService) : Controller
    {
        private readonly IUsuarioService _usuarioService = usuarioService;


        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastrarDTO cadastroDTO)
        {
            try
            {
                Usuario usuario = new(cadastroDTO.Nome, cadastroDTO.Email, cadastroDTO.Senha, "I", DateTime.Now);
                await _usuarioService.Cadastrar(usuario);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(new { Erro = new { Mensagem = e.ToString()} });
            }
        }

        [HttpGet("pendente")]
        public async Task<IActionResult> ObterSolicitacoesCadastroPendentes()
        {
            try
            {               
                return Ok(await _usuarioService.ObterCadastrosPendentes());
            }
            catch (Exception e)
            {
                return BadRequest(new { Erro = new { Mensagem = e.ToString() } });
            }
        }


        [HttpPost("aprovar/{id}")]
        public async Task<IActionResult> AprovarSolicitacaoCadastro(int id)
        {
            try
            {
                await _usuarioService.Aprovar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Erro = new { Mensagem = e.ToString() } });
            }
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar(AcessoDTO acessoDTO)
        {
            try
            {
                Usuario usuario = await _usuarioService.Acessar(acessoDTO.Email, acessoDTO.Senha);

                return Ok(new UsuarioDTO(usuario.Nome, usuario.Email, usuario.Situacao, usuario.CadastroEm, usuario.AprovadoEm, usuario.UltimaAlteracaoEm));
            }
            catch (Exception e)
            {

                return BadRequest(new { Erro = new { Mensagem = e.ToString() } });
            }
        }
    }
}
