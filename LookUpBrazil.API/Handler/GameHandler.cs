using LookUpBrazil.Api.Repositories;
using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.Game;
using LookUpBrazil.Core.Responses;

namespace LookUpBrazil.Api.Handler
{
    public class GameHandler(CityRepository repository, GameRepository gameRepository) : IGameHandler
    {
        public async Task<Response<Game>> GetGameAsync(GetGameRequest request)
        {
            try
            {
                var game = await gameRepository.GetGameById(request.GameId);
                return new Response<Game>(game ?? new Game(), message: "A letra inicial precisa ser " + game.Requirement.InitialLetter);
            }
            catch (Exception e)
            {
                return new Response<Game>(null, 500, "Falha no servidor: " + e.Message);
            }
        }
        public async Task<Response<City?>> ValidAttemptAsync(AttemptRequest attempt)
        {
            try
            {
                var game = await gameRepository.GetGameById(attempt.GameId);
                var cities = await repository.GetCitiesByLetter(game.Requirement.InitialLetter.Text);
                var city = cities.FirstOrDefault(x => x.Name.TextCompleted == attempt.Name.TextCompleted);
                if (city == null)
                    return new Response<City?>(null, 300, "Cidade não é valida");
                return new Response<City?>(city);
            }
            catch (Exception e)
            {
                return new Response<City?>(null, 500, "Falha no servidor: " + e.Message);
            }
        }
    }
}
