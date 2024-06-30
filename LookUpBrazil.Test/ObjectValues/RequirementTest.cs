using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.ObjectValues
{
    [TestClass]
    public class RequirementTest
    {
        private const char ExpectedCharacter = 'M';
        [TestMethod]
        public void GerarUmRequisitoValido()
        {
            Requirement requirement = GerarRequisitoEspecifico(ExpectedCharacter);

            Assert.IsNotNull(requirement.InitialLetter);
            Assert.AreEqual(requirement.InitialLetter.Character, new Letter('M').Character);
        }
        public Requirement GerarRequisitoEspecifico(char character)
        {
            Requirement requirement;
            do
            {
                requirement = new Requirement();
            } while (requirement.InitialLetter == null || requirement.InitialLetter.Character != character);
            return requirement;
        }
    }
}
