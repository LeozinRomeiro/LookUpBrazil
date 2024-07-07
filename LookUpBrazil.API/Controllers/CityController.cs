using LookUpBrazil.Api.ViewModels.Locations;
using LookUpBrazil.Core.Handler;
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
            [FromServices] ICityHandler handler)
        {
            await handler.GetIbgeCitiesAsync();
            return TypedResults.Ok();
        }
        [HttpGet]
        public async Task<IResult> GetNamesAsync(
            [FromServices] ICityHandler handler)
        {
            var result = await handler.GetNamesCitiesAsync();
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
