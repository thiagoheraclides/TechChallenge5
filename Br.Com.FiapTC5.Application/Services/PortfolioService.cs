using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Application.Services
{
    public class PortfolioService(DatabaseContext data) : IPortifolioService
    {
        private readonly DatabaseContext _data = data;

        public async Task<Portifolio> Obter(int id)
            => await _data.Portifolios.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Portifolio>> Obter()
            => await _data.Portifolios.ToListAsync();
    }
}
