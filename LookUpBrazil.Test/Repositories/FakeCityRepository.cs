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

            return Cities.First(x=>x.Name.Text.TextCompleted == TextCompleted);
        }

        public List<City>? GetCitiesByLetter()
        {
            var cities = new List<City>
            {
                new City { Name = new Name("Acrelândia") },
                new City { Name = new Name("Belo Horizonte") },
                new City { Name = new Name("Curitiba") },
                new City { Name = new Name("Dourados") },
                new City { Name = new Name("Erechim") },
                new City { Name = new Name("Fortaleza") },
                new City { Name = new Name("Goiânia") },
                new City { Name = new Name("Hortolândia") },
                new City { Name = new Name("Itu") },
                new City { Name = new Name("João Pessoa") },
                new City { Name = new Name("Karapicuíba") },
                new City { Name = new Name("Londrina") },
                new City { Name = new Name("Maringá") },
                new City { Name = new Name("Niterói") },
                new City { Name = new Name("Olinda") },
                new City { Name = new Name("Porto Alegre") },
                new City { Name = new Name("Quixadá") },
                new City { Name = new Name("Recife") },
                new City { Name = new Name("Salvador") },
                new City { Name = new Name("Teresina") },
                new City { Name = new Name("Uberlândia") },
                new City { Name = new Name("Vitória") },
                new City { Name = new Name("Wenceslau Braz") },
                new City { Name = new Name("Xanxerê") },
                new City { Name = new Name("Ypiranga do Sul") },
                new City { Name = new Name("Zacarias") }
            };

            return cities;
        }
    }
}
