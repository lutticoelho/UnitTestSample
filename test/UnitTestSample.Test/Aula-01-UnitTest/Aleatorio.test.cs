using System.ComponentModel;

namespace UnitTestSample.Test
{
    public class AleatorioTest
    {
        [Theory(DisplayName = "Should return -1 ")]
        [InlineData(-3, 9, -1)] // Quando inicio � negativo ent�o retorna -1
        [InlineData(3, -9, -1)] // Quando fim � negativo ent�o retorna -1
        [InlineData(5, 5, -1)] // Quando inicio e fim s�o iguais ent�o retorna -1
        [InlineData(6, 5, -1)] // Quando inicio � maior que fim ent�o retorna -1
        public void GerarNumeroAleatorio_TestCases_When_Should_Return_NegativeOne(int inicio, int fim, int resultadoEsperado)
        {
            // Arrange
            var sut = new Aleatorio();

            // Act
            var result = sut.GerarNumeroAleatorio(inicio, fim);

            // Assert
            Assert.Equal(resultadoEsperado, result);
        }

        [Fact(DisplayName = "Intervalo v�lido retorna um n�mero aleat�rio dentro do intervalo")]
        public void GerarNumeroAleatorio_WhenValidInterval_ThenReturnARandonNumberRespectingGivenInterval()
        {
            // Arrange
            var sut = new Aleatorio();
            var inicio = 200;
            var fim = 3000;

            // Act
            var result = sut.GerarNumeroAleatorio(inicio, fim);

            // Assert
            Assert.True(result >= inicio);
            Assert.True(result <= fim);
        }
    }
}