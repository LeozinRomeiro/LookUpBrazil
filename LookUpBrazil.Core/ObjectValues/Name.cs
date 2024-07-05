using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Name
    {
        protected Name() { }
        [JsonConstructor]
        public Name(string textCompleted)
        {
            if (string.IsNullOrEmpty(textCompleted))
            {
                throw new ArgumentNullException(nameof(textCompleted), message: "Texto do nome está nulo ou vazio");
            }
            Text = new Text(textCompleted);
        }
        public Name(Text text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text), "Texto do nome está nulo ou vazio");
        }
        public Text Text { get; set; } = null!;

        public static implicit operator string(Name name) => name.ToString();
        public static implicit operator Name(string name) => new Name(name);

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
