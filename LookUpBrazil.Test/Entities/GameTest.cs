using LookUpBrazil.Core.Entities;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.Entities
{
    [TestClass]
    public class GameTest
    {
        public FakeCityRepository CityRepository = new();
        [TestMethod]
        public void DadoUmaTentativaCorretaDeveRetornarSucesso()
        {
            var cities = CityRepository.GetCitiesByLetter();

            List<Name> names = [];
            foreach (var city in cities ?? [])
            {
                names.Add(city.Name);
            }

            var game = new Game(names);
            Assert.IsTrue(game.Attempt(names.First(x => x.Text.InitialLetter.Equals(game.Requirement.InitialLetter))));
        }
        [TestMethod]
        public void DadoUmaTentativaIncorretaNaoDeveRetornarSucesso()
        {
            var cities = CityRepository.GetCitiesByLetter();

            List<Name> names = [];
            foreach (var city in cities ?? [])
            {
                names.Add(city.Name);
            }

            var game = new Game(names);
            Assert.IsFalse(game.Attempt(names.First(x => x.Text.InitialLetter != game.Requirement.InitialLetter)));
        }
        [TestMethod]
        public void DadoUmaListaNulaParaOhGameDeveRetornarException()
        {
            try
            {
                new Game(null);
                Assert.IsTrue(false);
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
