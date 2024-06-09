using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class Requirement
    {
        public Requirement()
        {
            Generate();
        }
        public Letter? InitialLetter { get; private set; }

        public void Generate() {
            InitialLetter = new Letter((Char)('A'+ new Random().Next(0, 26)));
        }
    }
}
