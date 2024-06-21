using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.Handler
{
    [TestClass]
    public class RequirementTest
    {
        [TestMethod]
        public void GerarUmRequisitoValido()
        {
            Requirement requirement;
            do
            {
                requirement = new Requirement();
            } while (requirement.InitialLetter.Text != new Letter('M').Text);

            Assert.AreEqual(requirement.InitialLetter.Text, new Letter('M').Text);
        }
    }
}
