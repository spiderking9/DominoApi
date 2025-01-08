using DominoApi.Commands.Dto;
using DominoApi.Services;
using MediatR;

namespace DominoApi.Commands
{
    public class FindCircularChainCommand(List<Domino> dominoes) : IRequest<List<Domino>>
    {
        public List<Domino> Dominoes { get; set; } = dominoes;
    }

    public class FindCircularChainCommandHandler : IRequestHandler<FindCircularChainCommand, List<Domino>>
    {

        public Task<List<Domino>> Handle(FindCircularChainCommand request, CancellationToken cancellationToken)
        {
            var dominoes = DominoService.FindCircularChain(request.Dominoes) ?? [];
            return Task.FromResult(dominoes);
        }
    }
}