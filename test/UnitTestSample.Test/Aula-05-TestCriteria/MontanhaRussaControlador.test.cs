using Moq;
using UnitTestSample.Aula_05_TestCriteria;

namespace UnitTestSample.Test.Aula_05_TestCriteria
{
    public class MontanhaRussaControladorTest
    {
        [Theory(DisplayName = "Happy path")]
        [InlineData("João Batista", 18, true, "autorizado")]
        [InlineData("João Batista", 17, true, "acompanhado dos pais")]
        [InlineData("João Batista", 91, true, "acompanhado do responsavel legal")]
        public void Autorizar_When_AllParametersAreValid_Then_ReturnCorrectMessage(string nome, int idade, bool isClient, string expectedResult)
        {
            // Arrange
            var mock = new Mock<IClienteDao>();
            mock.Setup(_ => _.ehCliente(It.IsAny<string>())).Returns(isClient);

            var sut = new MontanhaRussaControlador(mock.Object);

            // Act
            var result = sut.Autorizar(nome, idade);

            // Assert
            Assert.Equal(expectedResult, result);
            mock.Verify(_ => _.ehCliente(It.IsAny<String>()), Times.Exactly(1));
        }

        [Theory(DisplayName = "Should trhow exception")]
        [InlineData("João", 18, true, "Argumento inválido (Parameter 'nome')")]
        [InlineData("1234 de oliveira 4", 18, true, "Argumento inválido (Parameter 'nome')")]
        [InlineData("João Batista", 18, false, "Não é um cliente (Parameter 'nome')")]
        [InlineData("João Batista", 0, true, "Argumento inválido (Parameter 'idade')")]
        [InlineData("João Batista", 121, true, "Argumento inválido (Parameter 'idade')")]
        public void Autorizar_When_OneParameterIsNotValid_Then_ThrowsException(string nome, int idade, bool isClient, string expectedResult)
        {
            // Arrange
            var mock = new Mock<IClienteDao>();
            mock.Setup(_ => _.ehCliente(It.IsAny<string>())).Returns(isClient);

            var sut = new MontanhaRussaControlador(mock.Object);

            // Act
            var exception = Assert.ThrowsAny<Exception>(() => sut.Autorizar(nome, idade));

            // Assert
            Assert.Equal(expectedResult, exception.Message);
        }
    }
}
