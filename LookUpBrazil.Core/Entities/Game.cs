using LookUpBrazil.Core.Exceptions;
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
        public Requirement Requirement { get; private set; } = null!;
        public List<Name> SecretNames { get; } = null!;
        public List<Name> MatchedNames { get; set; } = [];
        public bool Finish => SecretNames.Count == 0;
        protected Game() { }
        public Game(List<Name> names, Requirement requirement)
        {
            InvalidGameException.ThrowIfInvalid(names, requirement);
            Requirement = requirement;
            SecretNames = names;
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter?.ToString() == name.InitialLetter?.ToString() || SecretNames.Contains(name))
            {
                var matchedName = SecretNames.Find(x => x.TextCompleted == name);
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
