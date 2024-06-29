using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Exceptions
{
    public partial class InvalidLetterException : Exception
    {
        private const string DefaultErrorMessage = "Letra invalida";

        public InvalidLetterException(string message = DefaultErrorMessage)
            : base(message)
        {
        }

        public static void ThrowIfInvalid(
            char letter,
            string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(letter.ToString()))
                throw new InvalidLetterException(message);

            if (!LetterRegex().IsMatch(letter.ToString()))
                throw new InvalidLetterException("Letra incompativel com o formato definido");
        }

        [GeneratedRegex(
            "^[A-Z]+$")]
        private static partial Regex LetterRegex();
    }   
}
