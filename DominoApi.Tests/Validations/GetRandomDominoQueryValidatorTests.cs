using DominoApi.Commands.Dto;
using DominoApi.Validations;
using FluentValidation.TestHelper;

namespace DominoApi.Tests.Validations
{
    public class GetRandomDominoQueryValidatorTests
    {
        private readonly GetRandomDominoQueryValidator _validator;

        public GetRandomDominoQueryValidatorTests()
        {
            _validator = new GetRandomDominoQueryValidator();
        }

        [Fact]
        public void Validate_ShouldHaveError_WhenMaxNumberIsZero()
        {
            // Arrange
            var model = new DominoesSeeder(10, 0);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.MaxNumber)
                  .WithErrorMessage("MaxNumber must be greater than 0.");
        }

        [Fact]
        public void Validate_ShouldHaveError_WhenMaxNumberIsNegative()
        {
            // Arrange
            var model = new DominoesSeeder(10, -1);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.MaxNumber)
                  .WithErrorMessage("MaxNumber must be greater than 0.");
        }

        [Fact]
        public void Validate_ShouldNotHaveError_WhenMaxNumberIsPositive()
        {
            // Arrange
            var model = new DominoesSeeder(10, 5);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.MaxNumber);
        }

        [Fact]
        public void Validate_ShouldHaveError_WhenNumberOfDominoesIsOne()
        {
            // Arrange
            var model = new DominoesSeeder(1, 5);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.NumberOfDominoes)
                  .WithErrorMessage("NumberOfDominoes must be greater than 1.");
        }

        [Fact]
        public void Validate_ShouldHaveError_WhenNumberOfDominoesIsZero()
        {
            // Arrange
            var model = new DominoesSeeder(0, 5);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.NumberOfDominoes)
                  .WithErrorMessage("NumberOfDominoes must be greater than 1.");
        }

        [Fact]
        public void Validate_ShouldNotHaveError_WhenNumberOfDominoesIsGreaterThanOne()
        {
            // Arrange
            var model = new DominoesSeeder(2, 5);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.NumberOfDominoes);
        }
    }
}