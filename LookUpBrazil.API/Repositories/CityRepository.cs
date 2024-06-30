using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Repositories
{
    public class CityRepository(LookUpBrazilApiContext context) : ICityRepository
    {
        public async Task<List<City>?> GetCitiesByLetterAsync(char letter)
        {
			try
			{
                return await context.Cities
                    .Where(x => EF.Functions.Like(x.Name.Text.TextCompleted, $"{letter}%"))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades por letra", ex);
            }
        }

        public async Task<List<City>?> GetCitiesAsync()
        {
            try
            {
                return await context.Cities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades", ex);
            }
        }

        public async Task<List<Name>?> GetNamesCitiesAsync()
        {
            try
            {
                var cities = await GetCitiesAsync();
                var names = new List<Name>();
                foreach (var city in cities??[])
                {
                    names.Add(city.Name);
                }
                return names;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar nomes de cidades", ex);
            }
        }

        public async Task CreateCitiesAsync(List<City> cities)
        {
            try
            {
                foreach (var city in cities)
                {
                   context.Cities.Add(city);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar cidades", ex);
            }
        }
    }
}
