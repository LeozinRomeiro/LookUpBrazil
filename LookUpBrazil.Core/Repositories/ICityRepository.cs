using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>?> GetCitiesByLetter(char letter);
    }
}
