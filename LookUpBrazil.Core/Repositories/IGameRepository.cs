using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Repositories
{
    public interface IGameRepository
    {
        Task<Game> GetGameByIdAsync(Guid id);
        Task CreateGameAsync(Game game, List<Name> names);
    }
}
