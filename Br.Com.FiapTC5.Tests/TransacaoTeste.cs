using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Tests
{
    public class TransacaoTeste
    {
        [Fact]
        public void Quantidade_NumeroPositivoSuperiorAZero()
        {
            //Arrange
            Transacao transacao = new(1, 1, 1, "C", 1, 1.5m, DateTime.Now);

            //Arrange            

            //Assert
            Assert.True(transacao.Quantidade > 0);
            
        }

        [Fact]
        public void Quantidade_ExcecaoNumeroNegativo()
        {
            //Arrange
            Transacao transacao = new();

            //Arrange            
            Action action = () => transacao.Quantidade = -1;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);

        }

        [Fact]
        public void Quantidade_ExcecaoNumeroZero()
        {
            //Arrange
            Transacao transacao = new();

            //Arrange            
            Action action = () => transacao.Quantidade = 0;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);

        }
    }
}
