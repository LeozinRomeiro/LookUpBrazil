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
        private FakeCityRepository CityRepository = new();
        private List<Name> names = [];
        [TestMethod]
        public void DadoUmaTentativaCorretaDeveRetornarSucesso()
        {
            names = CityRepository.GetNamesCities();

            var game = new Game(names);
            Assert.IsTrue(game.Attempt(names.First(x => x.InitialLetter.Equals(game.Requirement.InitialLetter))));
        }
        [TestMethod]
        public void DadoUmaTentativaIncorretaNaoDeveRetornarSucesso()
        {
            names = CityRepository.GetNamesCities();

            var game = new Game(names);
            Assert.IsFalse(game.Attempt(names.First(x => x.InitialLetter != game.Requirement.InitialLetter)));
        }
        [TestMethod]
        [DataRow(null, false)]
        public void DadoUmaListaNulaParaOhGameDeveRetornarException(List<Name> names, bool isValid)
        {
            try
            {
                new Game(names);
                Assert.IsTrue(isValid);
            }
            catch (ArgumentNullException)
            {
                Assert.IsFalse(isValid);
            }
        }
        [TestMethod]
        public void DadoUmaListaVaziaParaOhGameDeveRetornarException()
        {
            try
            {
                new Game(new List<Name>());
                Assert.IsTrue(false);
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
