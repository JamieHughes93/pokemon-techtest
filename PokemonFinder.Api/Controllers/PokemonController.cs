using Integrations.Pokemon.Interfaces;
using Integrations.Pokemon.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using PokemonFinder.Api.Models;
using System.Net;

namespace PokemonFinder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [ProducesResponseType(typeof(PokemonModel), (int)HttpStatusCode.OK)]
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var pokemon = await _pokemonService.GetByName(name);

                if (pokemon != null)
                {
                    return new OkObjectResult(pokemon);
                }

                return new NotFoundObjectResult(new ErrorResponse()
                {
                    Error = "Unable to to find pokemon called " + name
                });
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(new ErrorResponse()
                {
                    Error = ex.Message
                });
            }
        }
    }
}