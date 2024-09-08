using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Tests
{
    public class TransacaoTeste
    {
        [Fact]
        public void Preco_NumeroPositivoSuperiorAZero()
        {
            //Arrange
            Transacao transacao = new(1, 1, 1, "C", 1, 1.5m, DateTime.Now);

            //Arrange            

            //Assert
            Assert.True(transacao.Quantidade > 0);
            
        }

        [Fact]
        public void Preco_ExcecaoNumeroNegativo()
        {
            //Arrange
            Transacao transacao = new();

            //Arrange            
            Action action = () => transacao.Preco = -1;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);

        }

        [Fact]
        public void Preco_ExcecaoNumeroZero()
        {
            //Arrange
            Transacao transacao = new();

            //Arrange            
            Action action = () => transacao.Preco = 0;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);

        }
    }
}
