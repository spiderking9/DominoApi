using DominoApi.Commands.Dto;
using DominoApi.Queries;

namespace DominoApi.Tests.Queries
{
    public class GetRandomDominoQueryTests
    {
        [Fact]
        public async Task Handle_ShouldReturnListOfDominoes()
        {
            // Arrange
            var seeder = new DominoesSeeder(10, 6);
            var query = new GetRandomDominoQuery(seeder);
            var handler = new GetRandomDominoQueryHandler();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(seeder.NumberOfDominoes, result.Count);
        }

        [Fact]
        public async Task Handle_ShouldReturnDominoesWithinRange()
        {
            // Arrange
            var seeder = new DominoesSeeder(10, 6);
            var query = new GetRandomDominoQuery(seeder);
            var handler = new GetRandomDominoQueryHandler();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.All(result, domino =>
            {
                Assert.InRange(domino.Left, 1, seeder.MaxNumber);
                Assert.InRange(domino.Right, 1, seeder.MaxNumber);
            });
        }
    }
}