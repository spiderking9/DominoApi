using DominoApi.Commands.Dto;
using DominoApi.Services;

namespace DominoApi.Tests.Services
{
    public class DominoServiceTests
    {
        [Fact]
        public void GenerateRandomDominoes_ShouldReturnCorrectNumberOfDominoes()
        {
            // Arrange
            int numberOfDominoes = 10;
            int maxNumber = 6;

            // Act
            var result = DominoService.GenerateRandomDominoes(numberOfDominoes, maxNumber);

            // Assert
            Assert.Equal(numberOfDominoes, result.Count);
        }

        [Fact]
        public void GenerateRandomDominoes_ShouldReturnDominoesWithinRange()
        {
            // Arrange
            int numberOfDominoes = 10;
            int maxNumber = 6;

            // Act
            var result = DominoService.GenerateRandomDominoes(numberOfDominoes, maxNumber);

            // Assert
            Assert.All(result, domino =>
            {
                Assert.InRange(domino.Left, 1, maxNumber);
                Assert.InRange(domino.Right, 1, maxNumber);
            });
        }

        [Fact]
        public void FindCircularChain_ShouldReturnNull_WhenNoCircularChainExists()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(4, 5)
            };

            // Act
            var result = DominoService.FindCircularChain(dominoes);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FindCircularChain_ShouldReturnCircularChain_WhenExists()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            };

            // Act
            var result = DominoService.FindCircularChain(dominoes);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result.First().Left);
            Assert.Equal(1, result.Last().Right);
        }

        [Fact]
        public void FindCircularChain_ShouldReturnCircularChain_WhenExistsWithFlips()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(3, 2),
                new Domino(3, 1)
            };

            // Act
            var result = DominoService.FindCircularChain(dominoes);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result.First().Left);
            Assert.Equal(1, result.Last().Right);
        }
    }
}