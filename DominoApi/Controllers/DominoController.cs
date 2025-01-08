using DominoApi.Commands;
using DominoApi.Commands.Dto;
using DominoApi.Queries;
using DominoApi.SeedData;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace DominoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominoController : ControllerBase
    {
        private readonly IMediator _mediator; 
        private IValidator<DominoesSeeder> _validator;

        public DominoController(IMediator mediator, IValidator<DominoesSeeder> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("numberOfDominoes/{numberOfDominoes:int}/maxNumber/{maxNumber:int}")]
        public async Task<IActionResult> GetRandomDomino(int numberOfDominoes, int maxNumber)
        {
            var seeder = new DominoesSeeder(numberOfDominoes, maxNumber);
            var validationResult =await _validator.ValidateAsync(seeder);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(w=>w.ErrorMessage));
            }
            var result = await _mediator.Send(new GetRandomDominoQuery(seeder));
            return Ok(result);
        }

        [HttpPost("find-chain")]
        [SwaggerRequestExample(typeof(List<Domino>), typeof(DominoExample))]
        public async Task<IActionResult> FindCircularChain([FromBody] List<Domino> dominoes)
        {
            var result = await _mediator.Send(new FindCircularChainCommand(dominoes));
            if (!result.Any())
            {
                return BadRequest("Circular chain is not possible.");
            }
            return Ok(result);
        }
    }
}