using PokemonFinder.Core.Models.Requests;
using PokemonFinder.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Core.Clients.Interfaces
{
    public interface IRestClient
    {
        Task<ApiResponse<TResponse>> MakeRequest<TResponse>(IAPIRequest request);
    }
}
