using Aula04 = UnitTestSample.Aula_04_MutationTests;

namespace UnitTestSample.Test.Aula_04_MutationTests
{
    public class PessoaTest
    {
        [Fact(DisplayName = "Throws exception when invalid range")]
        public void DefinirFaixaEtaria_WhenInvalidInterval_ThenThrowsException()
        {
            // Arrange
            var pessoa = new Aula04.Pessoa("joao", -1);
            var sut = new Aula04.Original();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => sut.definirFaixaEtaria(pessoa));

            // Assert
            Assert.Equal("idade invalida", ex.Message);
        }

        [Fact(DisplayName = "Returns correct age range name")]
        public void DefinirFaixaEtaria_HappyPath()
        {
            // Arrange
            var pessoa = new Aula04.Pessoa("joao", 109);
            var sut = new Aula04.Original();

            // Act
            var result = sut.definirFaixaEtaria(pessoa);

            // Assert
            Assert.Equal("joao eh idoso", result);
        }
    }
}
