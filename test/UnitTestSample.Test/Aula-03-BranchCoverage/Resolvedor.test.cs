using Moq;
using System.Collections;
using UnitTestSample.Aula_03_BranchCoverage;

namespace UnitTestSample.Test.Aula_03_BranchCoverage
{
    public class ResolvedorTest
    {
        //#1 - #2 - #4 - #5 - #7 - #8 - #10 - #6 - #5 - #7 - #8 - #10 - #6 - #11 - #12 - #16 - #17 - #18 - #19
        [Fact()]
        public void Resolverdor_Retorna_DoisClientes_Quando_ApenasDoisClientesSaoSelecionados()
        {
            // Arrange
            var mock = new Mock<IClienteRepo>();
            mock.Setup(x => x.GetCliente(It.Is<int>(x => x == 1))).Returns(new Cliente(1, "Nome1"));
            mock.Setup(x => x.GetCliente(It.Is<int>(x => x == 2))).Returns(new Cliente(2, "Nome2"));
            var sut = new Resolvedor(mock.Object);

            // Act
            var result = sut.DefinirPromocao(new[] { 1, 2 });

            // Assert
            Assert.True(result.Count() == 2);
            Assert.Equal(15, result[0].getDesconto());
            Assert.Equal(10, result[1].getDesconto());
        }

        //#1 - #3
        [Fact()]
        public void Resolverdor_Retorna_Exception_Quando_Input_Eh_Null()
        {
            // Arrange
            var mock = new Mock<IClienteRepo>();
            var sut = new Resolvedor(mock.Object);

            // Act
            var result = Assert.Throws<ArgumentException>(() => sut.DefinirPromocao(null));

            // Assert
            Assert.Equal("sem codigo algum", result.Message);
        }

        //#1 - #2 - #3
        [Fact()]
        public void Resolverdor_Retorna_Exception_Quando_Input_Eh_Vazio()
        {
            // Arrange
            var mock = new Mock<IClienteRepo>();
            var sut = new Resolvedor(mock.Object);

            // Act
            var result = Assert.Throws<ArgumentException>(() => sut.DefinirPromocao(new int[] { }));

            // Assert
            Assert.Equal("sem codigo algum", result.Message);
        }

        //#1 - #2 - #4 - #5 - #7 - #8 - #9
        [Fact()]
        public void Resolverdor_Retorna_Exception_Quando_Repo_Retorna_Null()
        {
            // Arrange
            var mock = new Mock<IClienteRepo>();
            var sut = new Resolvedor(mock.Object);

            // Act
            var result = Assert.Throws<Exception>(() => sut.DefinirPromocao(new[] { 1, 2 }));

            // Assert
            Assert.Equal("Codigo do cliente nao valido", result.Message);
        }

        //#1 - #2 - #4 - #5 - #7 - #8 - #10 - #6 - #5 - #7 - #8 - #10 - #6 - #5 - #7 - #8 - #10 - #6 - #11 - #12 - #13 - #15 - #14- #13 - #15 - #14- #13 - #15 - #14 - #19
        [Fact()]
        public void Resolverdor_Retorna_TresClientesCom25pDeDesconto_Quando_TresClientesSaoSelecionados()
        {
            // Arrange
            var mock = new Mock<IClienteRepo>();
            mock.Setup(x => x.GetCliente(It.Is<int>(x => x == 1))).Returns(new Cliente(1, "Nome1"));
            mock.Setup(x => x.GetCliente(It.Is<int>(x => x == 2))).Returns(new Cliente(2, "Nome2"));
            mock.Setup(x => x.GetCliente(It.Is<int>(x => x == 3))).Returns(new Cliente(3, "Nome3"));
            var sut = new Resolvedor(mock.Object);

            // Act
            var result = sut.DefinirPromocao(new[] { 1, 2, 3 });

            // Assert
            Assert.True(result.Count() == 3);
            Assert.Equal(25, result[0].getDesconto());
            Assert.Equal(25, result[1].getDesconto());
            Assert.Equal(25, result[2].getDesconto());
        }
    }
}
