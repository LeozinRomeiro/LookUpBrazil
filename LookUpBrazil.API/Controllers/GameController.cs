using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.Game;
using LookUpBrazil.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.Metrics;

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

        [HttpGet("Games")]
        public async Task<IResult> GetGames(
            [FromServices] IGameHandler handler)
        {
            var result = await handler.GetGamesAsync();
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
            [FromServices] IGameHandler handler,
            [FromServices] ICityHandler cityHandler,
            [FromServices] IMemoryCache cache)
        {
            var requirement = new Requirement();

            var namesResponse = await cache.GetOrCreateAsync($"Names{char.ToUpper(requirement.InitialLetter.Character)}Cache", async item =>
            {
                item.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                item.SlidingExpiration = TimeSpan.FromHours(12);
                return await cityHandler.GetNamesCitiesAsync(requirement.InitialLetter.Character);
            }) ?? await cityHandler.GetNamesCitiesAsync(requirement.InitialLetter.Character);

            var result = await handler.CreateGameAsync(namesResponse.Data, requirement);

            return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
        }
    }
}
