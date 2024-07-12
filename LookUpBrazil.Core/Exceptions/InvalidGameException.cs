using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Exceptions
{
    public partial class InvalidGameException(string message = InvalidGameException.DefaultErrorMessage) : Exception(message)
    {
        private const string DefaultErrorMessage = "Game invalida";

        public static void ThrowIfInvalid(
            List<Name> names, Requirement requirement,
            string message = DefaultErrorMessage)
        {
            if (names is null || names.Count == 0)
                throw new ArgumentNullException(nameof(names), message: "As cidades validas não foram reconhecidas");

            foreach (var name in names)
            {
                if (!name.InitialLetter.Equals(requirement.InitialLetter))
                    throw new InvalidGameException("As cidades validas não estão coerentes com o requirimento");
            }
        }

    }
}
