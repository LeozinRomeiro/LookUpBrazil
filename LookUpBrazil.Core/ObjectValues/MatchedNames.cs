using LookUpBrazil.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class MatchedNames
    {
        public Game Game { get; set; } = null!;
        public List<Name> Names { get; set; } = new List<Name>();
    }
}
