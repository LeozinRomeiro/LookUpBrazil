using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Repositories
{
    public class GameRepository(LookUpBrazilApiContext context) : IGameRepository
    {
        public async Task CreateGameAsync(Game game)
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

        public async Task<Game?> GetGameByIdAsync(Guid? id)
        {
            return await context.Games.FirstOrDefaultAsync(x=>x.Id.Equals(id));
        }

    }
}
