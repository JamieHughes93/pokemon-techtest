using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.Pokemon.Models.Responses
{
    public class PokeApiPokemonResponseModel
    {
        public string Name { get; set; }

        [JsonProperty("flavor_text_entries")]
        public IEnumerable<FlavourTextEntry> FlavourTextEntries { get; set; }
        public GenericNameObject? Habitat { get; set; }

        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }
    }

    public class FlavourTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavourText { get; set; }

        public GenericNameObject Language { get; set; }
    }

    public class GenericNameObject
    {
        public string Name { get; set; }
    }
}
