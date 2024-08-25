using Br.Com.FiapTC5.Api.DTO.Transacao;
using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FiapTC5.Api.Controllers
{
    [ApiController]
    [Route("transacao")]
    public class TransacaoController(ITransacaoService transacaoService) : ControllerBase
    {
        private readonly ITransacaoService _transacaoService = transacaoService;

        [HttpPost]
        public async Task<IActionResult> Inserir(InserirTransacaoDTO inserirTransacaoDTO)
        {
            try
            {
                Transacao transacao = new(inserirTransacaoDTO.CodigoPortfolio, inserirTransacaoDTO.CodigoUsuario, inserirTransacaoDTO.CodigoAtivo,
                    inserirTransacaoDTO.CodigoTipoTransacao, inserirTransacaoDTO.Quantidade, inserirTransacaoDTO.Valor, DateTime.Now);
                await _transacaoService.Inserir(transacao);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

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
