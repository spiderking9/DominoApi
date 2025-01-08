using DominoApi.Commands.Dto;
using DominoApi.Services;
using MediatR;

namespace DominoApi.Queries
{
    public class GetRandomDominoQuery : IRequest<List<Domino>>
    {
        public DominoesSeeder Seeder { get; set; }

        public GetRandomDominoQuery(DominoesSeeder seeder)
        {
            Seeder = seeder;
        }
    }

    public class GetRandomDominoQueryHandler : IRequestHandler<GetRandomDominoQuery, List<Domino>>
    {
        public Task<List<Domino>> Handle(GetRandomDominoQuery query, CancellationToken cancellationToken)
        {
            var dominoes = DominoService.GenerateRandomDominoes(query.Seeder.NumberOfDominoes, query.Seeder.MaxNumber);
            return Task.FromResult(dominoes);
        }
    }
}
