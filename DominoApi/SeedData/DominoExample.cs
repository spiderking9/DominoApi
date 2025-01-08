using DominoApi.Commands.Dto;
using DominoApi.Services;
using Swashbuckle.AspNetCore.Filters;

namespace DominoApi.SeedData
{
    public class DominoExample : IExamplesProvider<List<Domino>>
    {
        private readonly IConfiguration _configuration;

        public DominoExample(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Domino> GetExamples()
        {
            DominoesSeeder seedData=new(4,4);
            _configuration.Bind("RandomDominoes", seedData);
            return DominoService.GenerateRandomDominoes(seedData.NumberOfDominoes, seedData.MaxNumber);
        }
    }
}