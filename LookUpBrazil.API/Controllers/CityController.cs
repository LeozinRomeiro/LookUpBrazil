using LookUpBrazil.Core.Handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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
            [FromServices] ICityHandler handler,
            [FromServices] IMemoryCache cache,
            [FromQuery] char letter)
        {

            var result = await cache.GetOrCreateAsync($"Names{char.ToUpper(letter)}Cache", async item =>
            {
                item.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                item.SlidingExpiration = TimeSpan.FromHours(12);
                return await handler.GetNamesCitiesAsync(letter);
            })??await handler.GetNamesCitiesAsync(letter);

            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
