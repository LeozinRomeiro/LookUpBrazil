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

            var game = new Game(names, new Requirement());
            Assert.IsTrue(game.Attempt(names.First(x => x.InitialLetter.Equals(game.Requirement.InitialLetter))));
        }
        [TestMethod]
        public void DadoUmaTentativaIncorretaNaoDeveRetornarSucesso()
        {
            names = CityRepository.GetNamesCities();

            var game = new Game(names, new Requirement());
            Assert.IsFalse(game.Attempt("Teste"));
        }
        [TestMethod]
        [DataRow(null, false)]
        public void DadoUmaListaNulaParaOhGameDeveRetornarException(List<Name> names, bool isValid)
        {
            try
            {
                new Game(names, new Requirement());
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
                new Game(new List<Name>(), new Requirement());
                Assert.IsTrue(false);
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void AcertandoTodasAsCidadesGameDeveApontarFinish()
        {
            var requirement = new Requirement();

            var names = CityRepository.GetNamesCitiesByLetter(requirement.InitialLetter.Character);

            var game = new Game(names, requirement);

            foreach (var name in CityRepository.GetNamesCitiesByLetter(requirement.InitialLetter.Character))
            {
                game.Attempt(name);
            }

            Assert.IsTrue(game.Finish);
        }
    }
}
