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
        private List<Name> _secretNames = new List<Name>();
        public List<Name> SecretNames => _secretNames;
        public List<Name> MatchedNames { get; set; } = new List<Name>();
        public bool Finish => SecretNames.Count == 0;
        protected Game() { }
        public Game(List<Name> names)
        {
            _secretNames = names.Where(x=>x.Text.InitialLetter?.ToString() == Requirement.InitialLetter?.ToString()).ToList();
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter?.ToString() == name.Text.InitialLetter?.ToString() || SecretNames.Contains(name))
            {
                var matchedName = SecretNames.Find(x => x == name);
                if (matchedName != null)
                {
                    MatchedNames.Add(matchedName);
                    SecretNames.Remove(matchedName);
                    return true;
                }
            }
            return false;
        }
    }
}
