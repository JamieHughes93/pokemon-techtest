using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Models.Response
{
    public class FunTranslationResponse
    {
        public SuccessResponse Success { get; set; }

        public TranslationResponse Contents { get; set; }
    }

    public class SuccessResponse
    {
        public int Total { get; set; }
    }

    public class TranslationResponse
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }
}
