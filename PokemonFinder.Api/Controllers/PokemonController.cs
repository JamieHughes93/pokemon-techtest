using Integrations.FunTranslations.Config;
using Integrations.FunTranslations.Interfaces;
using Integrations.Pokemon.Config;
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
        private readonly IFunTranslationsService _funTranslationsService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService, IFunTranslationsService funTranslationsService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
            _funTranslationsService = funTranslationsService;
        }

        [ProducesResponseType(typeof(PokemonModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
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

        [ProducesResponseType(typeof(PokemonModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> Translated(string name)
        {
            try
            {
                var pokemon = await _pokemonService.GetByName(name);

                if (pokemon != null)
                {
                    switch(pokemon.Habitat)
                    {
                        case PokemonHabitats.Cave:
                            pokemon.Description = await _funTranslationsService.GetFunTranslation(pokemon.Description, FunTranslationTypes.Yoda);
                            break;
                        default:
                            pokemon.Description = await _funTranslationsService.GetFunTranslation(pokemon.Description, FunTranslationTypes.Shakespeare);
                            break;
                    }

                    return new OkObjectResult(pokemon);
                }

                return new NotFoundObjectResult(new ErrorResponse()
                {
                    Error = "Unable to to find pokemon called " + name
                });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ErrorResponse()
                {
                    Error = ex.Message
                });
            }
        }
    }
}