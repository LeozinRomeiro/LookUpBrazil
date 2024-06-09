using LookUpBrazil.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Letter
    {
        public Letter(char text)
        {
            InvalidLetterException.ThrowIfInvalid(text);
            Text = text;
        }

        public char Text { get; set; }
    }
}
