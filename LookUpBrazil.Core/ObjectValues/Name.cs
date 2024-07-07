using System;
using System.Collections.Generic;
using System.Globalization;
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
            TextCompleted = textCompleted;
        }
        public Letter InitialLetter => new Letter(TextCompleted[0]);
        public string _textCompleted = string.Empty;
        public string TextCompleted
        {
            get => _textCompleted;
            set
            {
                SetTextCompleted(value);
            }
        }
        public void SetTextCompleted(string textCompleted)
        {
            if (string.IsNullOrEmpty(textCompleted))
            {
                throw new ArgumentNullException(nameof(textCompleted), message: "Texto do nome está nulo ou vazio");
            }
            _textCompleted = textCompleted;
        }

        public static implicit operator string(Name name) => name.ToString();
        public static implicit operator Name(string name) => new(name);

        public override string ToString()
        {
            return _textCompleted.ToString();
        }

    }
}
