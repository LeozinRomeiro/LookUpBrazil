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
        protected Letter()
        {
            
        }
        public Letter(char text)
        {
            InvalidLetterException.ThrowIfInvalid(text);
            Character = text;
        }

        public char Character { get; set; }

        public static implicit operator Char(Letter letter) => letter.Character;
    }
}
