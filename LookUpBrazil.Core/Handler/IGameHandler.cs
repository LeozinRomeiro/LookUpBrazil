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
        Task<Response<City?>> ValidAttemptAsync(AttemptRequest attempt);
    }
}
