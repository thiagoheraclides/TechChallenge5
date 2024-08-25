using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface IPerfilService
    {
        Task<IEnumerable<Perfil>> Obter();

        Task<Perfil> ObterPorId(int id);
    }
}
