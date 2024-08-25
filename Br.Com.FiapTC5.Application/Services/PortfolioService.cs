using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

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
            => await _data.Portifolios.Where(portfolio => portfolio.UsuarioId == codigoUsuario).SingleOrDefaultAsync();
    }
}
