using Microsoft.CSharp.RuntimeBinder;
using UnitTestSample.Aula_06_TBM;

namespace UnitTestSample.Test.Aula_06_TBM
{
    public class ClimatizadorTest
    {
        [Fact()]
        public void AoLigar_Deve_Umidificar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            var umidificando = climatizador.umidificando();

            // Assert
            Assert.True(umidificando);
        }

        [Fact()]
        public void AoLigarEClicarEmUmidificar_Deve_PararDeUmidificar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            var umidificando1 = climatizador.umidificando();
            climatizador.umidificar();
            var umidificando2 = climatizador.umidificando();

            // Assert
            Assert.True(umidificando1);
            Assert.False(umidificando2);
        }

        [Fact()]
        public void AoLigarEAumentarVelocidade_Deve_Umidificar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            climatizador.aumentarV();
            var umidificando = climatizador.umidificando();

            // Assert
            Assert.True(umidificando);
        }

        [Fact()]
        public void AoLigarEAumentarVelocidadeEClicarEmUmidificar_Deve_PararDeUmidificar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            var umidificando1 = climatizador.umidificando();
            climatizador.aumentarV();
            var umidificando2 = climatizador.umidificando();
            climatizador.umidificar();
            var umidificando3 = climatizador.umidificando();

            // Assert
            Assert.True(umidificando1);
            Assert.True(umidificando2);
            Assert.False(umidificando3);
        }

        [Fact()]
        public void Desligado_NaoDeve_Umidificar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            var umidificando = climatizador.umidificando();

            // Assert
            Assert.False(umidificando);
        }

        [Fact()]
        public void Desligado_DaErro_QuandoDesliga()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            var error = Assert.Throws<RuntimeBinderException>(() => climatizador.desligar());

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(error.Message));
        }

        [Fact()]
        public void Ligado_Pode_desligar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            climatizador.desligar();

            // Assert
            Assert.Equal(0, climatizador.velocidade());
        }

        [Fact()]
        public void LigadoSemUmidificar_Pode_desligar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            climatizador.umidificar();
            climatizador.desligar();

            // Assert
            Assert.Equal(0, climatizador.velocidade());
        }

        [Fact()]
        public void LigadoUmidificandoNaVelocidade2_Pode_desligar()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            climatizador.aumentarV();
            climatizador.desligar();

            // Assert
            Assert.Equal(0, climatizador.velocidade());
        }

        [Fact()]
        public void Ligar_DaErro_QuandoJaLigado()
        {
            // Arrange
            var climatizador = new Climatizador();

            // Act
            climatizador.ligar();
            var error = Assert.Throws<RuntimeBinderException>(() => climatizador.ligar());

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(error.Message));
        }
    }
}
