using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Handler;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using LookUpBrazil.Core.Requests.Game;
using LookUpBrazil.Core.Responses;

namespace LookUpBrazil.Api.Handler
{
    public class GameHandler(IGameRepository gameRepository) : IGameHandler
    {
        public async Task<Response<Game>> CreateGameAsync(List<Name> names, Requirement requirement)
            {
                try
                {
                    if (names is not null)
                    {
                        var game = new Game(names, requirement);
                        await gameRepository.CreateGameAsync(game, names);
                        return new Response<Game>(game, message: "A letra inicial precisa ser " + game.Requirement.InitialLetter?.ToString());
                    }
                    return new Response<Game>(null, 500, "Falha no servidor de registros" );
                }
                catch (Exception e)
                {
                    return new Response<Game>(null, 500, "Falha no servidor: " + e.Message);
                }
        }

        public async Task<Response<Game>> GetGameAsync(GetGameRequest request)
        {
            try
            {
                var game = await gameRepository.GetGameByIdAsync(request.GameId);

                if (game is not null)
                {
                    return new Response<Game>(game, message: "A letra inicial precisa ser " + game.Requirement.InitialLetter?.ToString());
                }
                return new Response<Game>(null, 300, "Codigo de game está invalido");
            }
            catch (Exception e)
            {
                return new Response<Game>(null, 500, "Falha no servidor: " + e.Message);
            }
        }
        public async Task<Response<List<Game>>> GetGamesAsync()
        {
            try
            {
                var games = await gameRepository.GetGamesAsync();
                return new Response<List<Game>>(games);
            }
            catch (Exception e)
            {
                return new Response<List<Game>>(null, 500, "Falha no servidor: " + e.Message);
            }
        }
        public async Task<Response<Game?>> AttemptAsync(AttemptRequest attempt, Guid gameId)
        {
            try
            {
                var game = await gameRepository.GetGameByIdAsync(gameId);

                if (game is null)
                {
                    return new Response<Game?>(null, 300, "Game não encontrado");
                }

                if (game.Attempt(attempt.Name))
                {
                    return new Response<Game?>(game, message:$"Exatado! {attempt.Name} inicia com {game.Requirement.InitialLetter} e pertence ao Brasil");
                }
                
                return new Response<Game?>(game, message: $"Errado! {attempt.Name} não inicia com {game.Requirement.InitialLetter} ou pertence ao Brasil");
            }
            catch (Exception e)
            {
                return new Response<Game?>(null, 500, "Falha no servidor: " + e.Message);
            }
        }
    }
}
