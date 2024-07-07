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
        public FakeCityRepository CityRepository = new();

        [TestMethod]
        public void DadoUmaTentativaCorretaDeveRetornarSucesso()
        {
            var names = CityRepository.GetNamesCities();

            var game = new Game(names);

            var request = new AttemptRequest
            {
                Name = names.First(x=>x.InitialLetter.Equals(game.Requirement.InitialLetter)).ToString(),
            };

            Response<bool> response;

            if (!game.Attempt(new Name(request.Name)))
            {
                response = new Response<bool>(false, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<bool>(game.Finish);
            }

            Assert.IsTrue(response.IsSuccess);
        }

        [TestMethod]
        public void DadoUmaTentativaIncorretaNaoDeveRetornarSucesso()
        {
            var names = CityRepository.GetNamesCities();

            var game = new Game(names);

            var request = new AttemptRequest
            {
                Name = names.First(x => x.InitialLetter != game.Requirement.InitialLetter),
            };

            Response<bool> response;

            if (!game.Attempt(request.Name))
            {
                response = new Response<bool>(false, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<bool>(game.Finish);
            }

            Assert.IsFalse(response.IsSuccess);
        }

        [TestMethod]
        public void AcertandoTodasAsCidadesGameDeveApontarFinish()
        {
            var names = CityRepository.GetNamesCities();

            var game = new Game(names);

            bool LastAttempt = false;

            foreach (var name in names.Where(x => x.InitialLetter?.ToString() == game.Requirement.InitialLetter?.ToString()))
            {
                var request = new AttemptRequest
                {
                    Name = name,
                };

                LastAttempt = !game.Attempt(request.Name);
            }

            Response<bool> response;

            if (!LastAttempt)
            {
                response = new Response<bool>(false, 300, "Cidade nao e valida");
            }
            else
            {
                response = new Response<bool>(game.Finish);
            }

            Assert.IsTrue(game.Finish);
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
