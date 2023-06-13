using Moq;
using UnitTestSample.Aula_02_Mock;

namespace UnitTestSample.Test.Aula_02_Mock
{
    public class SomatoriaTest
    {
        [Theory(DisplayName = "Soma de fatoriais")]
        [InlineData(new[] { 3,4 }, 30)]
        [InlineData(new[] { 0, 1, 2, 3, 4 }, 34)]
        public void SomaDeFatoriais_InlineData(int[] input, int expectedResult)
        {
            // Arrange
            var mock = new Mock<IMathOps>();
            mock.Setup(_ => _.Fatorial(0)).Returns(1);
            mock.Setup(_ => _.Fatorial(1)).Returns(1);
            mock.Setup(_ => _.Fatorial(2)).Returns(2);
            mock.Setup(_ => _.Fatorial(3)).Returns(6);
            mock.Setup(_ => _.Fatorial(4)).Returns(24);

            // Outra opção para mockar a função fatorial. Mas eu prefiro deixar os testes sem lógica.
            //mock.Setup(_ => _.Fatorial(It.IsAny<int>())).Returns((int number) =>
            //{
            //    var fat = 1;
            //    for (int i = number; i >= 1; i--)
            //        fat *= i;

            //    return fat;
            //});

            var sut = new Somatoria(mock.Object);

            // Act
            var result = sut.SomaDeFatoriais(input);

            // Assert
            Assert.Equal(expectedResult, result);
            mock.Verify(_ => _.Fatorial(It.IsAny<int>()), Times.Exactly(input.Length));
        }
    }
}
