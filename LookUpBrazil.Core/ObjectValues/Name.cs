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
            Text = new Text(textCompleted);
        }
        public Name()
        {
            Text = new Text(string.Empty);
        }
        public Text Text { get; set; } = new Text();
    }
}
