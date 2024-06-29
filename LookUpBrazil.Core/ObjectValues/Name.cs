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
            if (string.IsNullOrEmpty(textCompleted))
            {
                throw new ArgumentNullException(nameof(textCompleted), message: "Texto do nome está nulo ou vazio");
            }
            Text = new Text(textCompleted);
        }
        public Text Text { get; set; } = new Text();

        public static implicit operator string(Name name) => name.ToString();

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
