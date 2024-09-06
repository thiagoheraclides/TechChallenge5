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

            int?[]? ativosCodigo = await _data.Transacoes.Where(transacao => transacao.CodigoUsuario == codigoUsuario)
                                                         .Select(transacao => transacao.CodigoAtivo)
                                                         .ToArrayAsync();


            IList<Ativo> ativos = await _data.Ativos.Where(ativo => ativosCodigo.Contains(ativo.Id))
                                                    .ToListAsync();

            portifolio!.Ativos = ativos;

            return portifolio!;
        }
          
    }
}
