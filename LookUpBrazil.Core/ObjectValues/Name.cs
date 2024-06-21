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
            TextCompleted = new Text(textCompleted);
        }
        public Name()
        {
        }

        public Text TextCompleted { get; set; } = new Text();
    }
}
