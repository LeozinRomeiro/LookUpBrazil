using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.Repositories
{
    public class FakeCityRepository
    {
        public List<City> Cities = new List<City>();
        public City? CityExists(string TextCompleted)
        {
            City city = new City
            {
                Name = new Name("Maringa")
            };

            Cities.Add(city);

            return Cities.First(x=>x.Name.TextCompleted == TextCompleted);
        }
    }
}
