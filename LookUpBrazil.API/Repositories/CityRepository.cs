using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Repositories
{
    public class CityRepository(LookUpBrazilApiContext context) : ICityRepository
    {
        public async Task<List<City>?> GetCitiesByLetter(char letter)
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
    }
}
