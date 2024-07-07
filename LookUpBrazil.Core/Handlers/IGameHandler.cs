using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.Game;
using LookUpBrazil.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Handler
{
    public interface IGameHandler
    {
        Task<Response<Game?>> AttemptAsync(AttemptRequest attempt, Guid gameId);
        Task<Response<Game>> GetGameAsync(GetGameRequest request);
        Task<Response<Game>> CreateGameAsync(List<Name> names, Requirement requirement);
    }
}
