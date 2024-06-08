using LookUpBrazil.Api.ViewModels.Locations;
using LookUpBrazil.Api.Handler;
using Microsoft.AspNetCore.Mvc;
using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.Responses;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.City;

namespace LookUpBrazil.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CityController
    {
        [HttpPost]
        public async Task<IResult> PostValidCity(
            [FromBody] ValidCityRequest request,
            [FromServices] CityHandler handler,
            [FromServices] LookUpBrazilApiContext context)
        {
            var result = await handler.ValidAsync(request);
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
