using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface IAtivoService
    {
        Task<Ativo> Obter(int id);

        Task<IEnumerable<Ativo>> Obter();

        Task<IEnumerable<Ativo>> ObterPorUsuario(int codigoUsuario);
    }
}
