using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Requests.Game;
using LookUpBrazil.Core.Responses;
using LookUpBrazil.Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.Handler
{
    public class GameTest
    {
        public FakeCityRepository CityRepository = new FakeCityRepository();
        public FakeGameRepository GameRepository = new FakeGameRepository();
        [TestMethod]
        public async void DadoUmaTentativaCorretaDeveRetornarSucesso()
        {
            var game = await GameRepository.GetGameById(Guid.NewGuid());
            var request = new AttemptRequest
            {
                GameId = game.Id,
                Name = new Name("Maringa")
            };

            var cities = CityRepository.GetCitiesByLetter(game.Requirement.InitialLetter.Text);

            var city = CityRepository.CityExists(request.Name.TextCompleted);

            Response<City?> response;

            if (city is null)
            {
                response = new Response<City?>(null, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<City?>(city);
            }

            Assert.IsTrue(response.IsSuccess);
        }
        [TestMethod]
        public void DadoUmCityValidoDeveRetornarSucesso()
        {
            var request = new ValidCityRequest
            {
                Name = new Name("Maringa")
            };

            var city = CityRepository.CityExists(request.Name.TextCompleted);

            Response<City?> response;

            if (city is null)
            {
                response = new Response<City?>(null, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<City?>(city);
            }

            Assert.IsTrue(response.IsSuccess);
        }
    }
}
