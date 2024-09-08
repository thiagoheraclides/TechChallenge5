using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Br.Com.FiapTC5.Application.Services
{
    public class PortfolioService(DatabaseContext data) : IPortifolioService
    {
        private readonly DatabaseContext _data = data;

        public async Task Inserir(Portifolio portifolio)
        {
            await _data.Portifolios.AddAsync(portifolio);
            await _data.SaveChangesAsync();
        }

        public async Task<Portifolio> Obter(int id)
            => await _data.Portifolios.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Portifolio>> Obter()
            => await _data.Portifolios.ToListAsync();

        public async Task<Portifolio> ObterPorUsuario(int codigoUsuario)
        {
            Portifolio portifolio = await _data.Portifolios.Where(portfolio => portfolio.UsuarioId == codigoUsuario!)
                                                           .SingleOrDefaultAsync()!;

            IList<Ativo> ativos  = [];

            IList<Transacao> compras = await _data.Transacoes
                                                      .Where(transacao => transacao.CodigoUsuario == codigoUsuario && transacao.TipoTransacao == "C")                                                        
                                                      .ToListAsync();

            IList<Transacao> vendas = await _data.Transacoes
                                                      .Where(transacao => transacao.CodigoUsuario == codigoUsuario && transacao.TipoTransacao == "C")
                                                      .ToListAsync();

            

            foreach (var compra in compras) 
            {
                decimal quantidadeAtualAtivo = 0;

                foreach (var venda in vendas)
                {
                    if (compra.CodigoAtivo == venda.CodigoAtivo)
                    {
                        quantidadeAtualAtivo = compra.Quantidade - venda.Quantidade;
                    }
                        
                }

                if (quantidadeAtualAtivo > 0)
                {
                    ativos.Add(await _data.Ativos.Where(ativo => ativo.Id == compra.CodigoAtivo).FirstOrDefaultAsync());
                }                    
            }


            if (ativos.Count > 0)
                portifolio!.Ativos = ativos;


            return portifolio!;
        }
          
    }
}
