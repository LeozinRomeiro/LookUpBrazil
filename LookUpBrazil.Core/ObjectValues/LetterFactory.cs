using LookUpBrazil.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public static class LetterFactory
    {
        public static Letter Create(char text)
        {
            return new Letter(text);
        }
    }
}
