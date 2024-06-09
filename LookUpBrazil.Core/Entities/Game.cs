using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Entities
{
    public class Game : Entity
    {
        public Game()
        {
            Requirement = new Requirement();
        }

        public Requirement Requirement { get; private set; }
    }
}
