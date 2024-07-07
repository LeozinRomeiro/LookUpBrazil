using LookUpBrazil.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Letter
    {
        protected Letter() { }
        public Letter(char text)
        {
            text = char.ToUpper(RemoveDiacritics(text.ToString()));
            InvalidLetterException.ThrowIfInvalid(text);
            Character = text;
        }

        public char Character { get; set; }

        public static implicit operator Char(Letter letter) => letter.Character;
        public static implicit operator String(Letter letter)
        {
            return letter.Character.ToString();
        }
        public override string ToString()
        {
            return Character.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Letter other)
            {
                return Character == other.Character;
            }
            return false;
        }
        public override int GetHashCode() => Character.GetHashCode();
        public static bool operator ==(Letter left, Letter right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Character == right.Character;
        }

        public static bool operator !=(Letter left, Letter right) => !(left == right);

        private static char RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text[0];

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

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC)[0];
        }
    }
}
