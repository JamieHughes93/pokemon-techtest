using Integrations.Pokemon.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.Pokemon.Interfaces
{
    public interface IPokemonService
    {
        /// <summary>
        /// Gets a Pokemon from the PokeApi by its name
        /// </summary>
        /// <param name="name">Name of the pokemon</param>
        /// <returns>A Pokemon Model</returns>
        Task<PokemonModel> GetByName(string name);
    }
}
