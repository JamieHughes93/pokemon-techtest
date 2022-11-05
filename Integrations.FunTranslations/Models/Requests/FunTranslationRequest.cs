using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Models.Requests
{
    public class FunTranslationRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
