using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Name
    {
        public Name(string textCompleted)
        {
            TextCompleted = textCompleted;
        }
        public Name()
        {
        }

        public string TextCompleted { get; set; } = string.Empty;
    }
}
