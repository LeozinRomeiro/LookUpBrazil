using LookUpBrazil.Core.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LookUpBrazil.Test.ObjectValues
{
    [TestClass]
    public class NameTest
    {
        [TestMethod]
        [DataRow("Name",true)]
        [DataRow("",false)]
        [DataRow(null,false)]
        public void ValidaçãoDeNome(string textCompleted, bool IsValid)
        {
            try { var name = new Name(textCompleted); Assert.IsTrue(IsValid); } catch (ArgumentNullException) { Assert.IsFalse(IsValid); }
        }
        [TestMethod]
        public void ConstrutorDeveRemoverOsAcentosDaLetraInicial()
        {
            var name = new Name("Ácido");
            Assert.AreEqual(name.InitialLetter.Character, 'A');
        }
    }
}
