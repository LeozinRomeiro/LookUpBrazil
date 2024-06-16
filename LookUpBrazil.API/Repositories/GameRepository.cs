using LookUpBrazil.Api.Data;
using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookUpBrazil.Api.Repositories
{
    public class GameRepository(LookUpBrazilApiContext context) : IGameRepository
    {
        public async Task<Game?> GetGameById(Guid? id)
        {
            return await context.Games.FirstOrDefaultAsync(x=>x.Equals(id));
        }
    }
}
