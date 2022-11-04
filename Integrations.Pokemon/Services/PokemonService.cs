using Integrations.Pokemon.Config;
using Integrations.Pokemon.Interfaces;
using Integrations.Pokemon.Models.Requests;
using Integrations.Pokemon.Models.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PokemonFinder.Core.Clients.Interfaces;
using PokemonFinder.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.Pokemon.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly PokeApiConfig _config;
        private readonly IRestClient _client;
        private readonly ILogger _logger;

        public PokemonService(IOptions<PokeApiConfig> config, IRestClient client, ILogger<PokemonService> logger)
        {
            _config = config.Value;
            _client = client;
            _logger = logger;
        }

        public async Task<PokemonModel> GetByName(string name)
        {
            try
            {
                var request = new PokeApiRequestModel()
                {
                    Method = RequestMethod.Get,
                    AuthorizationType = AuthorizationType.Anonymous,
                    EndPoint = _config.Endpoint + name
                };

                var result = await _client.MakeRequest<PokeApiPokemonResponseModel>(request);

                if (result.Success)
                {
                    _logger.LogInformation($"Successfully retrieved pokemon {name}");

                    var model = new PokemonModel(result.Response);

                    return model;
                }

                _logger.LogInformation($"Unable to retrieve pokemon {name} - {result.Message}");

                return null;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error when retrieving pokemon {name}");
                return null;
            }
        }
    }
}
