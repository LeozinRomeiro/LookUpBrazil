using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Text
    {
        public Letter? InitialLetter { get; private set; }
        public string _textCompleted = string.Empty;

        public Text(string textCompleted)
        {
            if (textCompleted is null)
            {
                throw new ArgumentNullException(nameof(textCompleted), message: "Texto está nulo");
            }
            TextCompleted = textCompleted;
        }
        public string TextCompleted
        {
            get => _textCompleted;
            set
            {
                _textCompleted = value;
                if (!string.IsNullOrEmpty(value))
                {
                    var normalizedValue = RemoveDiacritics(value[0].ToString());
                    InitialLetter = new Letter(normalizedValue[0]);
                }
                else
                {
                    InitialLetter = null;
                }
            }
        }

        public static implicit operator string(Text text) => text.ToString();

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
