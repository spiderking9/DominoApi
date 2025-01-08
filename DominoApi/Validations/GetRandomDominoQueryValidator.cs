using DominoApi.Commands.Dto;
using DominoApi.Queries;
using FluentValidation;

namespace DominoApi.Validations
{
    public class GetRandomDominoQueryValidator : AbstractValidator<DominoesSeeder>
    {
        public GetRandomDominoQueryValidator()
        {
            RuleFor(x => x.MaxNumber)
                .GreaterThan(0).WithMessage("MaxNumber must be greater than 0.");

            RuleFor(x => x.NumberOfDominoes)
                .GreaterThan(1).WithMessage("NumberOfDominoes must be greater than 1.");
        }
    }
}
