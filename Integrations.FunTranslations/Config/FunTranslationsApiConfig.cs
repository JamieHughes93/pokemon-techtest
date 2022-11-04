using PokemonFinder.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Config
{
    public class FunTranslationsApiConfig : IAPIConfig
    {
        public string Endpoint { get; set; }
    }
}
