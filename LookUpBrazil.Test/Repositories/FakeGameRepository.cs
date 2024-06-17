using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.Repositories
{
    public class FakeGameRepository : IGameRepository
    {
        public async Task<Game?> GetGameByIdAsync(Guid? id)
        {
            Game game;
            do
            {
                game = new Game();
            } while (game.Requirement.InitialLetter == new Letter('M'));

            return game;
        }
    }
}
