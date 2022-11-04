using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Integrations.Pokemon.Models.Responses
{
    public class PokemonModel
    {
        public PokemonModel(PokeApiPokemonResponseModel response)
        {
            Name = response.Name;

            var firstEnglishDescription = response.FlavourTextEntries.FirstOrDefault(x => x.Language?.Name == "en");

            Description = Regex.Replace(firstEnglishDescription?.FlavourText, @"\r\n?|\n|\f", " ");

            Habitat = response.Habitat?.Name;
            IsLegendary = response.IsLegendary;
        }

        public PokemonModel()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool IsLegendary { get; set; }
    }
}
