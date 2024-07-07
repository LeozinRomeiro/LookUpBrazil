using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Handler
{
    public interface ICityHandler
    {
        Task GetIbgeCitiesAsync();
        Task<Response<List<Name>>> GetNamesCitiesAsync(char letter);
    }
}
