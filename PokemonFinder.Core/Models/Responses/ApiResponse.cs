using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Core.Models.Responses
{
    /// <summary>
    /// A generic representation of a response from an API
    /// </summary>
    /// <typeparam name="TResponse">The type of the underlying response that should be returned by the API</typeparam>
    public class ApiResponse<TResponse>
    {
        /// <summary>
        /// A flag to indicate if the API call and deserialisation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Any message that needs to be returned in addition to the success flag or the base response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The underlying response that should be returned by the API
        /// </summary>
        public TResponse Response { get; set; }
    }
}
