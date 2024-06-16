using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Requests.Game;
using Microsoft.AspNetCore.Mvc;

namespace LookUpBrazil.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class GameController
    {
        [HttpPost]
        public async Task<IResult> GetGame(
            [FromServices] IGameHandler handler,
            [FromQuery] Guid gameId)
        {
            var request = new GetGameRequest { GameId = gameId };

            var result = await handler.GetGameAsync(request);
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
