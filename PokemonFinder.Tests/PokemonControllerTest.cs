using Integrations.FunTranslations.Interfaces;
using Integrations.Pokemon.Interfaces;
using Integrations.Pokemon.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using PokemonFinder.Api.Controllers;
using PokemonFinder.Tests.Helpers;
using PokemonFinder.Tests.Services;

namespace PokemonFinder.Tests
{
    public class PokemonControllerTest
    {
        private readonly PokemonController _controller;
        private readonly IPokemonService _pokemonService;
        private readonly IFunTranslationsService _funTranslationsService;

        public PokemonControllerTest()
        {
            _pokemonService = new PokemonServiceFake();
            _funTranslationsService = new FunTranslationsServiceFake();
            _controller = new PokemonController(_pokemonService, _funTranslationsService);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var actionResult = await _controller.Get("mewtwo");

            //Assert
            Assert.IsType<OkObjectResult>(actionResult as OkObjectResult);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsNotFound()
        {
            //Act
            var actionResult = await _controller.Get("fakepokemon");

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult as NotFoundObjectResult);
        }

        [Fact]
        public async Task GetTranslated_WhenCalled_ReturnsYoda()
        {
            //Act
            var actionResult = await _controller.Translated("diglett");

            var result = actionResult as OkObjectResult;
            var pokemon = result?.Value as PokemonModel;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult as OkObjectResult);
            Assert.Contains("Yoda", pokemon?.Description);
        }

        [Fact]
        public async Task GetTranslated_WhenCalled_ReturnsShakespeare()
        {
            //Act
            var actionResult = await _controller.Translated("clefairy");

            var result = actionResult as OkObjectResult;
            var pokemon = result?.Value as PokemonModel;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Contains("Shakespeare", pokemon?.Description);
        }

        [Fact]
        public async Task GetTranslated_WhenCalled_ReturnsNotFound()
        {
            //Act
            var actionResult = await _controller.Translated("fakepokemon");

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult as NotFoundObjectResult);
        }
    }
}