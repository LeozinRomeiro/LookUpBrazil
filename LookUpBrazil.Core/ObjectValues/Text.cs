using System;
using System.Collections.Generic;
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
            TextCompleted = textCompleted;
        }
        public Text()
        {
            TextCompleted = string.Empty;
        }
        public string TextCompleted
        {
            get => _textCompleted;
            set
            {
                _textCompleted = value;
                if (!string.IsNullOrEmpty(value))
                {
                    InitialLetter = new Letter(value[0]);
                }
                else
                {
                    InitialLetter = null;
                }
            }
        }
    }
}
