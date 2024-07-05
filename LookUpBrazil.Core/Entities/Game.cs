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
        public List<Name> SecretNames { get; } = null!;
        public List<Name> MatchedNames { get; set; } = [];
        public bool Finish => SecretNames.Count == 0;
        protected Game() { }
        public Game(List<Name> names)
        {
            if (names is null || names.Count == 0)
            {
                throw new ArgumentNullException(nameof(names), message: "As cidades validas não foram reconhecidas");
            }
            SecretNames = names.Where(x=>x.Text.InitialLetter.Equals(Requirement.InitialLetter)).ToList();
        }
        public bool Attempt(Name name)
        {
            if(Requirement.InitialLetter?.ToString() == name.Text.InitialLetter?.ToString() || SecretNames.Contains(name))
            {
                var matchedName = SecretNames.Find(x => x.Text.TextCompleted == name);
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
