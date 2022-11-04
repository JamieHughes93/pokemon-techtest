using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Core.Models.Requests
{
    public interface IAPIRequest
    {
        object RequestObject { get; set; }
        string EndPoint { get; set; }
        AuthorizationType AuthorizationType { get; set; }
        RequestMethod Method { get; set; }
    }

    public enum AuthorizationType
    {
        Anonymous,
        Basic,
        Bearer
    }

    public enum RequestMethod
    {
        Get,
        GetWithParams,
        Post,
        Patch
    }
}
