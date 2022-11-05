using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonFinder.Core.Clients.Interfaces;
using PokemonFinder.Core.Models.Requests;
using PokemonFinder.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Core.Clients.Implementations
{
    public class RestClient : IRestClient
    {
        private readonly ILogger<RestClient> _logger;

        public RestClient(ILogger<RestClient> logger)
        {
            _logger = logger;
        }

        public async Task<ApiResponse<TResponse>> MakeRequest<TResponse>(IAPIRequest request)
        {
            var response = new ApiResponse<TResponse>();
            string responseContent;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage webResponse = null;

                    switch (request.Method)
                    {
                        case RequestMethod.Get:
                            webResponse = await httpClient.GetAsync(request.EndPoint);
                            break;
                        case RequestMethod.Post:
                            var requestJson = new StringContent(JsonConvert.SerializeObject(request.RequestObject), Encoding.UTF8, "application/json");
                            webResponse = await httpClient.PostAsync(request.EndPoint, requestJson);
                            break;
                        default:
                            break;
                    }

                    var streamResponse = await webResponse.Content.ReadAsStreamAsync();

                    using (var sr = new StreamReader(streamResponse))
                    {
                        responseContent = await sr.ReadToEndAsync();
                    }
                }

                try
                {
                    var deserializedResponse = JsonConvert.DeserializeObject<TResponse>(responseContent);

                    response = new ApiResponse<TResponse>()
                    {
                        Success = deserializedResponse != null,
                        Response = deserializedResponse
                    };

                    return response;
                }
                catch (Exception ex)   
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to call API", ex);
            }

            return response;
        }
    }
}
