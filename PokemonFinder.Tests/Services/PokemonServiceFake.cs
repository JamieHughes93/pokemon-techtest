using Integrations.Pokemon.Interfaces;
using Integrations.Pokemon.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Tests.Services
{
    public class PokemonServiceFake : IPokemonService
    {
        private readonly List<PokeApiPokemonResponseModel> _pokemonResults;

        public PokemonServiceFake()
        {
            _pokemonResults = new List<PokeApiPokemonResponseModel>()
            {
                new PokeApiPokemonResponseModel
                {
                    Name = "mewtwo",
                    Habitat = new GenericNameObject
                    {
                        Name = "rare"
                    },
                    FlavourTextEntries = new List<FlavourTextEntry>
                    {
                        new FlavourTextEntry
                        {
                            FlavourText = "It was created by a scientist after years of horrific gene splicing and DNA engineering experiments",
                            Language = new GenericNameObject
                            {
                                Name = "en"
                            }
                        }
                    }
                },
                new PokeApiPokemonResponseModel
                {
                    Name = "geodude",
                    Habitat = new GenericNameObject
                    {
                        Name = "mountain"
                    },
                    FlavourTextEntries = new List<FlavourTextEntry>
                    {
                        new FlavourTextEntry
                        {
                            FlavourText = "Found in fields and mountains. Mistaking them for boulders, people often step or trip on them.",
                            Language = new GenericNameObject
                            {
                                Name = "en"
                            }
                        }
                    }
                },
                new PokeApiPokemonResponseModel
                {
                    Name = "oddish",
                    Habitat = new GenericNameObject
                    {
                        Name = "grassland"
                    },
                    FlavourTextEntries = new List<FlavourTextEntry>
                    {
                        new FlavourTextEntry
                        {
                            FlavourText = "During the day,\nit keeps its face\nburied in the\fground. At night,\nit wanders around\nsowing its seeds.",
                            Language = new GenericNameObject
                            {
                                Name = "en"
                            }
                        }
                    }
                },
                new PokeApiPokemonResponseModel
                {
                    Name = "diglett",
                    Habitat = new GenericNameObject
                    {
                        Name = "cave"
                    },
                    FlavourTextEntries = new List<FlavourTextEntry>
                    {
                        new FlavourTextEntry
                        {
                            FlavourText = "Lives about one yard underground where it feeds on plant roots. It sometimes appears above ground.",
                            Language = new GenericNameObject
                            {
                                Name = "en"
                            }
                        }
                    }
                },
                new PokeApiPokemonResponseModel
                {
                    Name = "clefairy",
                    Habitat = new GenericNameObject
                    {
                        Name = "mountain"
                    },
                    FlavourTextEntries = new List<FlavourTextEntry>
                    {
                        new FlavourTextEntry
                        {
                            FlavourText = "Its magical and cute appeal has many admirers. It is rare and found only in certain areas.",
                            Language = new GenericNameObject
                            {
                                Name = "en"
                            }
                        }
                    }
                }
            };
        }

        public async Task<PokemonModel> GetByName(string name)
        {
            var result = _pokemonResults.FirstOrDefault(x => x.Name == name);

            if (result != null)
            {
                var model = new PokemonModel(result);
                return model;
            }

            return null;
        }
    }
}
