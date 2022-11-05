using Integrations.FunTranslations.Interfaces;
using Integrations.FunTranslations.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Tests.Services
{
    public class FunTranslationsServiceFake : IFunTranslationsService
    {
        public FunTranslationsServiceFake()
        {
            
        }

        public async Task<string> GetFunTranslation(string text, string translationType)
        {
            var translationResponses = new List<FunTranslationResponse>
            {
                new FunTranslationResponse
                {
                    Success = new SuccessResponse
                    {
                        Total = 1
                    },
                    Contents = new TranslationResponse
                    {
                        Translated = MakeYoda(text),
                        Translation = "yoda",
                        Text = text
                    }
                },
                new FunTranslationResponse
                {
                    Success = new SuccessResponse
                    {
                        Total = 1
                    },
                    Contents = new TranslationResponse
                    {
                        Translated = MakeShakespeare(text),
                        Translation = "shakespeare",
                        Text = text
                    }
                },
            };

            var translation = translationResponses.FirstOrDefault(x => x.Contents.Translation == translationType);

            return translation?.Contents?.Translated ?? text;
        }

        private string MakeYoda(string text)
        {
            return text + " - said by Yoda";
        }

        private string MakeShakespeare(string text)
        {
            return text + " - said by Shakespeare";
        }
    }
}
