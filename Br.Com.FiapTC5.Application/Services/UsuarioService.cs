using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Br.Com.FiapTC5.Application.Services
{
    public class UsuarioService(DatabaseContext data) : IUsuarioService
    {
        private readonly DatabaseContext _data = data;

        public async Task<Usuario> Acessar(string email, string senha)
        {
            if (!await _data.Usuarios.Where(u => u.Email == email).AnyAsync())
                throw new Exception("Usuário não encontrado.");

            var usuario = await _data.Usuarios.Where(u => u.Email == email).SingleAsync();
            var hashedSenha = Usuario.GerarHash256(senha);

            if (hashedSenha != usuario.Senha)
                throw new Exception("Credenciais de acesso inválidas.");

            return usuario;
        }

        public async Task Aprovar(int id)
        {

            if (!await _data.Usuarios.Where(u => u.Id == id).AnyAsync())
                throw new Exception("Usuário não encontrado.");

            var usuario = await _data.Usuarios.Where(u => u.Id == id).SingleAsync();
            usuario.Aprovar();
            await _data.SaveChangesAsync();

        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {

            if (await _data.Usuarios.Where(u => u.Email == usuario.Email).AnyAsync())
                throw new Exception("Usuário já cadastrado.");

            var hashedSenha = Usuario.GerarHash256(usuario.Senha!);
            usuario.Senha = hashedSenha;

            await _data.Usuarios.AddAsync(usuario);
            await _data.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Obter(int id)
            => await _data.Usuarios.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Usuario>> Obter()
            => await _data.Usuarios.ToListAsync();

        public async Task<IEnumerable<Usuario>> ObterCadastrosPendentes()
            => await _data.Usuarios.Where(u => u.Situacao == "I").ToListAsync();

        public async Task AssociarPerfil(int codigoUsuario, int codigoPerfil)
        {
            Usuario usuario = await _data.Usuarios
                .Where(u => u.Id == codigoUsuario).SingleOrDefaultAsync()
                ?? throw new Exception("Usuário não encontrado.");

            Perfil perfil = await _data.Perfis
                .Where(p => p.Codigo == codigoPerfil).SingleOrDefaultAsync()
                ?? throw new Exception("Perfil não encontrado.");

            usuario.CodigoPerfil = codigoPerfil;

            await _data.SaveChangesAsync();
        }
    }
}
