using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface IPortifolioService
    {
        Task Inserir(Portifolio portifolio);

        Task<Portifolio> Obter(int id);

        Task<IEnumerable<Portifolio>> Obter();

        Task<Portifolio> ObterPorUsuario(int codigoUsuario);

    }
}
