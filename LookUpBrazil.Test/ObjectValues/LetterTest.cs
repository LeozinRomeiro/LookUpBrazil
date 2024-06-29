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
        [DataRow(null,false)]
        public void ValidacaoRegexDeLetras(char texto, bool isValid)
        {
            try
            {
                var letter = new Letter(texto);
                Assert.IsTrue(isValid);
            }
            catch
            {
                Assert.IsFalse(isValid);
            }
        }
    }
}
