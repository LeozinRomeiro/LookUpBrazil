using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.Handler;
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
    [TestClass]
    public class GameHandlerTest
    {
        public FakeCityRepository CityRepository = new FakeCityRepository();
        //public FakeGameRepository GameRepository = new FakeGameRepository();

        [TestMethod]
        public void DadoUmaTentativaCorretaDeveRetornarSucesso()
        {
            var cities = CityRepository.GetCitiesByLetter();

            List<Name> names = new();
            foreach (var city in cities)
            {
                names.Add(city.Name);
            }

            var game = new Game(names);

            var request = new AttemptRequest
            {
                GameId = game.Id,
                Name = names.First(x=>x.Text.InitialLetter.Text==game.Requirement.InitialLetter.Text),
            };

            Response<Name> response;

            if (!game.Attempt(request.Name))
            {
                response = new Response<Name>(null, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<Name>(request.Name);
            }

            Assert.IsTrue(response.IsSuccess);
        }

        [TestMethod]
        public void DadoUmaTentativaIncorretaDeveRetornarSucesso()
        {
            var cities = CityRepository.GetCitiesByLetter();

            List<Name> names = new();
            foreach (var city in cities)
            {
                names.Add(city.Name);
            }

            var game = new Game(names);

            var request = new AttemptRequest
            {
                GameId = game.Id,
                Name = names.First(x => x.Text.InitialLetter.Text != game.Requirement.InitialLetter.Text),
            };

            Response<Name> response;

            if (!game.Attempt(request.Name))
            {
                response = new Response<Name>(null, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<Name>(request.Name);
            }

            Assert.IsFalse(response.IsSuccess);
        }
        //[TestMethod]
        //public async void DadoUmaTentativaCorretaDeveRetornarSucesso()
        //{
        //    var game = await GameRepository.GetGameByIdAsync(Guid.NewGuid());
        //    var request = new AttemptRequest
        //    {
        //        GameId = game.Id,
        //        Name = new Name("Maringa")
        //    };

        //    var cities = CityRepository.GetCitiesByLetter(game.Requirement.InitialLetter.Text);

        //    var city = CityRepository.CityExists(request.Name.TextCompleted);

        //    Response<City?> response;

        //    if (city is null)
        //    {
        //        response = new Response<City?>(null, 300, "Cidade nao e valida");
        //    }
        //    else
        //    {
        //        response = new Response<City?>(city);
        //    }

        //    Assert.IsTrue(response.IsSuccess);
        //}
        //[TestMethod]
        //public void DadoUmCityValidoDeveRetornarSucesso()
        //{
        //    var request = new ValidCityRequest
        //    {
        //        Name = new Name("Maringa")
        //    };

        //    var city = CityRepository.CityExists(request.Name.TextCompleted);

        //    Response<City?> response;

        //    if (city is null)
        //    {
        //        response = new Response<City?>(null, 300, "Cidade nao e valida");
        //    }
        //    else
        //    {
        //        response = new Response<City?>(city);
        //    }

        //    Assert.IsTrue(response.IsSuccess);
        //}
    }
}
