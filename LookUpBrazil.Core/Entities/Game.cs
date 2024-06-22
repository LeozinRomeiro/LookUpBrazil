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
        private List<Name> SecretNames { get; set; } = new List<Name>();
        public List<Name> MatchedNames { get; set; } = new List<Name>();
        public bool Finish => SecretNames.Count() == 0;
        public Game(List<Name> names)
        {
            this.SecretNames = names.Where(x=>x.Text.InitialLetter.Text==Requirement.InitialLetter.Text).ToList();
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter.Text == name.Text.InitialLetter.Text || SecretNames.Contains(name))
            {
                MatchedNames.Add(SecretNames.Find(x=>x==name));
                SecretNames.Remove(name);
                return true;
            }
            return false;
        }
    }
}
