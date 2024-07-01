using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Handler
{
    public class CityHandler(IHttpClientFactory httpClientFactory, ICityRepository cityRepository) : ICityHandler
    {
        public async Task GetIbgeCitiesAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient(Configuration.UrlIbgeMunicipios);
                var result = await client.GetFromJsonAsync<List<CityFromJson.Municipio>>("Municipio");
                var cities = new List<City>();
                foreach (var city in result ?? [])
                {
                    cities.Add(new City() { Name = new Name(city.Nome), States = new States() { Acronym = city.Microrregiao.Mesorregiao.UF.Sigla } });
                }
                await cityRepository.CreateCitiesAsync(cities);
            }
            catch
            {

                throw;
            }
        }
    }
}
