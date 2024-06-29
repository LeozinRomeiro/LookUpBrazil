using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Requests.City
{
    public class ValidCityRequest : Request
    {
        public Name Name { get; set; } = null!;
    }
}
