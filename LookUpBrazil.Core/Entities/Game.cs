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
        public Requirement Requirement { get; private set; } = new Requirement();
        private List<Name> Names { get; set; } = new List<Name>();
        public Game(List<Name> names)
        {
            this.Names = names.Where(x=>x.Text.InitialLetter.Text==Requirement.InitialLetter.Text).ToList();
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter.Text == name.Text.InitialLetter.Text)
            {
                return Names.Contains(name);
            }
            return false;
        }
    }
}
