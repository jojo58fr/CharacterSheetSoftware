using Microsoft.VisualStudio.TestTools.UnitTesting;
using Character_Sheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet.Tests
{
    [TestClass()]
    public class ConstructeurGuerrierTests
    {
        [TestMethod()]
        public void ConstructeurGuerrierTest()
        {
            ConstructeurGuerrier constructeurguerrier = new ConstructeurGuerrier();
            Assert.IsNotNull(constructeurguerrier);
        }

        [TestMethod()]
        public void ConstruitTest()
        {
            ConstructeurGuerrier constructeur = new ConstructeurGuerrier();
            Assert.IsInstanceOfType(constructeur.Construit("Guerrier", Genre.Femme), typeof(Guerrier));
        }
    }
}