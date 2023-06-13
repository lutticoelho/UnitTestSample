using Moq;

namespace UnitTestSample.Test.Aula_02_Mock
{
    public class PessoaDAOTest
    {
        public static readonly List<Pessoa> lista_vazia = new List<Pessoa>() { };
        public static readonly List<Pessoa> lista1 = new List<Pessoa>() { new Pessoa() { Nome = "Pedro" }, new Pessoa() { Nome = "João" } };

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { "joão", lista1, true }; // Testa case insensitive
            yield return new object[] { "João", lista1, true }; // Testa correspondencia exata
            yield return new object[] { "João", lista_vazia, false }; // Testa lista vazia
            yield return new object[] { "Epaminondas", lista1, false }; // Testa correspondencia não encontrada
        }

        [Theory(DisplayName = "Valida método encontrar pessoa, nos cenários descritos no método Data()")]
        [MemberData(nameof(Data))]
        public void ExistePessoa(string input, List<Pessoa> nomes, bool expectedResult)
        {
            // Arrange
            var mock = new Mock<IRHService>();
            mock.Setup(x => x.GetAllPessoas()).Returns(nomes);
            var sut = new PessoaDAO(mock.Object);

            // Act
            var result = sut.ExistePessoa(input);

            // Assert
            Assert.Equal(expectedResult, result);

        }

        [Fact(DisplayName = "Valida método encontrar pessoa quando a pessoa não existes")]
        public void ExistePessoa_When_Pessoa_Not_exists_Then_Return_False()
        {
            // Arrange
            var mock = new Mock<IRHService>();
            mock.Setup(x => x.GetAllPessoas()).Returns(lista1);
            var sut = new PessoaDAO(mock.Object);

            // Act
            var result = sut.ExistePessoa("Gepeto");

            // Assert
            Assert.False(result);

        }
    }
}
