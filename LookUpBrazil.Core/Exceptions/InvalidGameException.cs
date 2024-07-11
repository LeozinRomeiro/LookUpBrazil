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
            
        }

    }
}
