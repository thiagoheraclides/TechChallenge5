using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface ITransacaoService
    {
        Task<Transacao> Obter(int id);

        Task<IEnumerable<Transacao>> Obter();

        Task<IEnumerable<Transacao>> ObterPorUsuario(int codigoUsuario);

        Task Inserir(Transacao transacao);
    }
}
