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
        public Letter InitialLetter { get; private set; } = null!;
        public string _textCompleted = string.Empty;
        public string TextCompleted
        {
            get => _textCompleted;
            set
            {
                _textCompleted = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), message: "Texto do nome está nulo ou vazio");
                }
                var normalizedValue = RemoveDiacritics(value[0].ToString());
                InitialLetter = new Letter(normalizedValue[0]);
            }
        }

        public static implicit operator string(Name name) => name.ToString();
        public static implicit operator Name(string name) => new(name);

        public override string ToString()
        {
            return _textCompleted.ToString();
        }

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
