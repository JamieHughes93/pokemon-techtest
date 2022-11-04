using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Core.Config
{
    public interface IAPIConfig
    {
        string Endpoint { get; set; }
    }
}
