using LookUpBrazil.API.Data;
using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Handler
{
    public class CityHandler(LookUpBrazilAPIContext context) : ICityHandler
    {
        public async Task<Response<City?>> ValidAsync(ValidCityRequest request)
        {
            var city = await context.Cities.FirstAsync(x => x.Name.TextCompleted == request.Name.TextCompleted);
            if (city == null)
                return new Response<City?>(null, 300, "Cidade não é valida");
            return new Response<City?>(city);
        }
    }
}
