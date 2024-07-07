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
                    .Where(x => EF.Functions.Like(x.Name.TextCompleted, $"{letter}%"))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades por letra", ex);
            }
        }

        public async Task<List<City>?> GetCitiesAsync(Letter letter)
        {
            try
            {
                var cities = await context.Cities
                          .AsNoTracking()
                          .ToListAsync();

                return cities.Where(x => x.Name.InitialLetter.Character == letter.Character).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades", ex);
            }
        }

        public async Task<List<City>?> GetCitiesAsync(States states)
        {
            try
            {
                return await context.Cities.AsNoTracking().Where(x => x.States.Acronym == states.Acronym).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades", ex);
            }
        }

        public async Task<List<City>?> GetCitiesAsync()
        {
            try
            {
                return await context.Cities.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cidades", ex);
            }
        }

        public async Task<List<Name>?> GetNamesCitiesAsync(Letter letter)
        {
            try
            {
                var cities = await GetCitiesAsync(letter);
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
