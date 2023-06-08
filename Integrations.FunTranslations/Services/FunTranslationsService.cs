using Integrations.FunTranslations.Config;
using Integrations.FunTranslations.Interfaces;
using Integrations.FunTranslations.Models.Requests;
using Integrations.FunTranslations.Models.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PokemonFinder.Core.Clients.Interfaces;
using PokemonFinder.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Services
{
    public class FunTranslationsService : IFunTranslationsService
    {
        private readonly FunTranslationsApiConfig _config;
        private readonly IRestClient _client;
        private readonly ILogger _logger;

        public FunTranslationsService(IOptions<FunTranslationsApiConfig> config, IRestClient client, ILogger<FunTranslationsService> logger)
        {
            _config = config.Value;
            _client = client;
            _logger = logger;
        }

        ///<inheritdoc />
        public async Task<string> GetFunTranslation(string text, string translationType)
        {
            try
            {
                var request = new FunTranslationsApiRequestModel()
                {
                    RequestObject = new FunTranslationRequest()
                    {
                        Text = text
                    },
                    EndPoint = string.Format(_config.Endpoint, translationType),
                    Method = RequestMethod.Post
                };

                var result = await _client.MakeRequest<FunTranslationResponse>(request);

                if (result.Success && !string.IsNullOrEmpty(result.Response?.Contents?.Translated))
                {
                    return result.Response.Contents.Translated;
                }

                return text;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Rate limit reached");

                return text;
            }
        }
    }
}
