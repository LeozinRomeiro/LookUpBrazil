using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Requests.Game
{
    public class AttemptRequest : Request
    {
        public string Name { get; set; } = null!;
    }
}
