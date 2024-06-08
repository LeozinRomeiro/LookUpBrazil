using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class City : Entity
    {
        public States States { get; set; }
        public Name Name { get; set; }
    }
}
