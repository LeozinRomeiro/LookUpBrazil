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
        private SecretNames _secretNames = new SecretNames();
        public SecretNames SecretNames => _secretNames;
        public MatchedNames MatchedNames { get; set; } = new MatchedNames();
        public bool Finish => SecretNames.Names.Count == 0;
        protected Game() { }
        public Game(List<Name> names)
        {
            this.SecretNames.Names = names.Where(x=>x.Text.InitialLetter == Requirement.InitialLetter).ToList();
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter == name.Text.InitialLetter || SecretNames.Names.Contains(name))
            {
                var matchedName = SecretNames.Names.Find(x => x == name);
                if (matchedName != null)
                {
                    MatchedNames.Names.Add(matchedName);
                    SecretNames.Names.Remove(matchedName);
                    return true;
                }
            }
            return false;
        }
    }
}
