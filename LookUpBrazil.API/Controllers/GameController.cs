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
        [HttpGet]
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

        [HttpPost("Attempt")]
        public async Task<IResult> PostAttempt(
            [FromServices] IGameHandler handler,
            [FromQuery] Guid gameId,
            [FromBody] AttemptRequest request)
        {
            var result = await handler.AttemptAsync(request, gameId);
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }

        [HttpPost]
        public async Task<IResult> CreateGame(
            [FromServices] IGameHandler handler)
        {
            var result = await handler.CreateGameAsync();
            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
