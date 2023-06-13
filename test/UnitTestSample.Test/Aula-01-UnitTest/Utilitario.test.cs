namespace UnitTestSample.Test
{
    public class UtilitarioTest
    {
        

        [Theory(DisplayName = "Should throw Exception with message ")]
        [InlineData(null, "vetor nao pode ser nulo")] // Quando vetor é nulo
        [InlineData(new int[0], "vetor com zero elementos")] // Quando vetor é vazio
        public void AcharExtremos_InvalidVector(int[] vector, string exceptionMessage)
        {
            // Arrange
            var sut = new Utilitario();

            // Act
            var exception = Record.Exception(() => sut.AcharExtremos(vector)); ;

            // Assert
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Theory(DisplayName = "Should throw Exception with message ")]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 1, 5, 0)] 
        [InlineData(new int[] { 1, 99, 3, -5, 8 }, 99, -5, 1, 3)]
        public void AcharExtremos_ValidVector(int[] vector, int maior, int menor, int indiceMaior, int indiceMenor)
        {
            // Arrange
            var sut = new Utilitario();

            // Act
            var result = sut.AcharExtremos(vector);

            // Assert
            Assert.Equal(maior, result.getMaior());
            Assert.Equal(indiceMaior, result.getIndiceMaior());
            Assert.Equal(menor, result.getMenor());
            Assert.Equal(indiceMenor, result.getIndiceMenor());
        }
    }
}
