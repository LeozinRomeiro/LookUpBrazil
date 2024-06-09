using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class City
    {
        public int Id { get; set; }
        public States States { get; set; } = null!;
        public Name Name { get; set; } = null!;
    }
}
