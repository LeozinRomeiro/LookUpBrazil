using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Repositories
{
    public class GameRepository(LookUpBrazilApiContext context) : IGameRepository
    {
        public async Task CreateGameAsync(Game game, List<Name> names)
        {
            try
            {
                context.Games.Add(game);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            try
            {
                return await context.Games.FirstAsync(x=>x.Id.Equals(id));
            }
            catch
            {

                throw;
            }
        }

    }
}
