using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.ObjectValues
{
    [TestClass]
    public class LetterTest
    {
        [TestMethod]
        [DataRow('A',true)]
        [DataRow('Z',true)]
        [DataRow('1',false)]
        [DataRow('-',false)]
        [DataRow('$',false)]
        public void TestarAValidacaoDeLetras(char texto, bool isValid)
        {
            try
            {
                new Letter(texto);
                Assert.IsTrue(isValid);
            }
            catch
            {
                Assert.IsFalse(isValid);
            }
        }
    }
}
