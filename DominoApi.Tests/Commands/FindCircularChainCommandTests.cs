using DominoApi.Commands;
using DominoApi.Commands.Dto;

namespace DominoApi.Tests.Commands
{
    public class FindCircularChainCommandTests
    {
        [Fact]
        public async Task Handle_ShouldReturnCircularChain_WhenExists()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            };
            var command = new FindCircularChainCommand(dominoes);
            var handler = new FindCircularChainCommandHandler();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result.First().Left);
            Assert.Equal(1, result.Last().Right);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenNoCircularChainExists()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(4, 5)
            };
            var command = new FindCircularChainCommand(dominoes);
            var handler = new FindCircularChainCommandHandler();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnCircularChain_WhenExistsWithFlips()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(3, 2),
                new Domino(3, 1)
            };
            var command = new FindCircularChainCommand(dominoes);
            var handler = new FindCircularChainCommandHandler();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result.First().Left);
            Assert.Equal(1, result.Last().Right);
        }
    }
}