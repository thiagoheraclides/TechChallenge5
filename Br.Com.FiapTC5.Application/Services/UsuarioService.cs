using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Application.Services
{
    public class UsuarioService(DatabaseContext data) : IUsuarioService
    {
        private readonly DatabaseContext _data = data;

        public async Task<Usuario> Obter(int id)
            => await _data.Usuarios.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Usuario>> Obter()
            => await _data.Usuarios.ToListAsync();
    }
}
