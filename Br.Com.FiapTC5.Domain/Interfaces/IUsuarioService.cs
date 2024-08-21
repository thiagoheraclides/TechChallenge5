using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Acessar(string email, string senha);

        Task Aprovar(int id);

        Task Cadastrar(Usuario usuario);        

        Task<Usuario> Obter(int id);

        Task<IEnumerable<Usuario>> Obter();

        Task<IEnumerable<Usuario>> ObterCadastrosPendentes();
    }
}
