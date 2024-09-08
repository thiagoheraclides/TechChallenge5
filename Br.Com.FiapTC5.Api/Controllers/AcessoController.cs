using Br.Com.FiapTC5.Api.DTO.Acesso;
using Br.Com.FiapTC5.Application.Services;
using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("acesso")]
    public class AcessoController(IUsuarioService usuarioService, IPortifolioService portifolioService) : Controller
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IPortifolioService _portifolioService = portifolioService;


        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastrarDTO cadastroDTO)
        {
            using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {

                Usuario usuario = 
                    await _usuarioService.Cadastrar(new(cadastroDTO.Nome, cadastroDTO.Email, cadastroDTO.Senha, "I", DateTime.Now));
                Portifolio portifolio = new("Meu portfólio", "Portfólio de investimentos padrão", usuario);
                await _portifolioService.Inserir(portifolio);
                transactionScope.Complete();

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(new { Erro = new { Mensagem = e.ToString() } });
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

                if (usuario.Situacao != "A")
                    throw new Exception("Cadastro pendente de aprovação. Aguarde a aprovação ou entre em contato com o SAC.");

                return Ok(new UsuarioDTO(usuario.Nome, usuario.Email, usuario.Situacao, usuario.CadastroEm, usuario.AprovadoEm, usuario.UltimaAlteracaoEm));
            }
            catch (Exception e)
            {

                return BadRequest(new { Erro = new { Mensagem = e.Message } });
            }
        }
    }
}
