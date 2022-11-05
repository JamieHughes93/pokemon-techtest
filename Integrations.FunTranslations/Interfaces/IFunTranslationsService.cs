using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.FunTranslations.Interfaces
{
    public interface IFunTranslationsService
    {
        /// <summary>
        /// Translates a given string in a fun way
        /// </summary>
        /// <param name="text">The string you want to translate</param>
        /// <param name="translationType">The way you want to translate the string</param>
        /// <returns>A fun translated string</returns>
        Task<string> GetFunTranslation(string text, string translationType);
    }
}
