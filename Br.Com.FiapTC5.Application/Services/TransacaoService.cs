using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Application.Services
{
    public class TransacaoService(DatabaseContext data) : ITransacaoService
    {
        private readonly DatabaseContext _data = data;

        public async Task Inserir(Transacao transacao)
        {
            await _data.Transacoes.AddAsync(transacao);
            await _data.SaveChangesAsync();
        }

        public async Task<Transacao> Obter(int id)
            => await _data.Transacoes.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Transacao>> Obter()
            => await _data.Transacoes.ToListAsync();

        public async Task<IEnumerable<Transacao>> ObterPorUsuario(int codigoUsuario)
            => await _data.Transacoes.Where(transacao => transacao.CodigoUsuario == codigoUsuario).ToListAsync();
    }
}
