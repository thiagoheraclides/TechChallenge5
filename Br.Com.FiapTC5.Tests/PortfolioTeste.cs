using Br.Com.FiapTC5.Domain.Entidades;
using System;

namespace Br.Com.FiapTC5.Tests
{
    public class PortfolioTeste
    {
        [Fact]
        public void Portifolio_ExcecaoParaListaDeAtivoNula()
        {
            //Arrange
            Portifolio portifolio = new();            

            //Arrange            
            Action action = () => portifolio.Ativos = null!;

            //Assert
            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void Portifolio_ExcecaoParaListaDeAtivoZerada()
        {
            //Arrange
            Portifolio portifolio = new();
            IList<Ativo> ativos = [];

            //Arrange            
            Action action = () => portifolio.Ativos = ativos;

            //Assert
            Assert.Throws<Exception>(action);

        }


    }
}
