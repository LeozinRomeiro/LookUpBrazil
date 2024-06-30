using LookUpBrazil.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    }
}
