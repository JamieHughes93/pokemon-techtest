using PokemonFinder.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.Pokemon.Config
{
    public class PokeApiConfig : IAPIConfig
    {
        public string Endpoint { get; set; }
    }
}
