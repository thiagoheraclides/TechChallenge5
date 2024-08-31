using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Tests
{
    public class UsuarioTeste
    {
        [Fact]
        public void Usuario_AprovadoComSucesso()
        {
            //Arrange
            Usuario usuario = new("Nome Do Usuário", "email@email.com", "senha-secreta", "I", DateTime.Now);

            //Arrange
            usuario.Aprovar();

            Assert.Equal("A", usuario.Situacao);
            Assert.NotNull(usuario.AprovadoEm);
            Assert.NotNull(usuario.UltimaAlteracaoEm);
        }

        [Fact]
        public void Usuario_CriptografarSenhaComSucesso()
        {
            //Arrange
            Usuario usuario = new("Nome Do Usuário", "email@email.com", "senha-secreta", "I", DateTime.Now);

            //Arrange
            string senhaCriptografada = Usuario.GerarHash256(usuario.Senha!);

            //Assert
            Assert.NotEqual(senhaCriptografada, usuario.Senha);
            Assert.NotNull(senhaCriptografada);
            Assert.NotEmpty(senhaCriptografada);
        }

        [Fact]
        public void Usuario_CompararSenhaComSucesso()
        {
            //Arrange
            Usuario usuario = new("Nome Do Usuário", "email@email.com", "senha-secreta", "I", DateTime.Now);

            //Arrange
            string senhaCriptografada = Usuario.GerarHash256(usuario.Senha!);

            //Assert
            Assert.Equal(senhaCriptografada, Usuario.GerarHash256(usuario.Senha!));
        }
    }
}