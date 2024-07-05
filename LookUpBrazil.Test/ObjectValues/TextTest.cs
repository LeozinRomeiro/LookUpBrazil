using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Test.ObjectValues
{
    [TestClass]
    public class TextTest
    {
        [TestMethod]
        public void ConstrutorDeveRemoverOsAcentosDaLetraInicial()
        {
            var text = new Text("Ácido");
            Assert.AreEqual(text.InitialLetter.Character, 'A');
        }
    }
}
