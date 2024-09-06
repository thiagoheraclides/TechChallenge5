using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Tests
{
    public class AtivoTeste
    {
        [Fact]
        public void Codigo_NaoNulo()
        {
            //Arrange
            Ativo ativo;

            //Arrange            
            Action action = () => ativo = new(1, 1, new(2, "Criptomoeda"), "Bitcoin", null);

            //Assert
            Assert.Throws<ArgumentException>(action);

        }

        [Fact]
        public void Codigo_InvalidoCenario1()
        {
            //Arrange
            Ativo ativo;

            //Arrange            
            Action action = () => ativo = new(1, 1, new(2, "Criptomoeda"), "Bitcoin", "");

            //Assert
            Assert.Throws<ArgumentException>(action);

        }

        [Fact]
        public void Codigo_InvalidoCenario2()
        {
            //Arrange
            Ativo ativo;

            //Arrange            
            Action action = () => ativo = new(1, 1, new(2, "Criptomoeda"), "Bitcoin", string.Empty);

            //Assert
            Assert.Throws<ArgumentException>(action);

        }
    }
}
