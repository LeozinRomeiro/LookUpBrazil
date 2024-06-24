using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Entities
{
    public static class GameFactory
    {
        public static Game Create(List<Name> names)
        {
            return new Game(names);
        }
    }
}
