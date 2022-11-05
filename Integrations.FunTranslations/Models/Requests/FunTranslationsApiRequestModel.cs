﻿using PokemonFinder.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Models.Requests
{
    public class FunTranslationsApiRequestModel : IAPIRequest
    {
        public object RequestObject { get; set; }
        public string EndPoint { get; set; }
        public RequestMethod Method { get; set; }
    }
}
