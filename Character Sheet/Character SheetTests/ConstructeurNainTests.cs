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
    public class ConstructeurNainTests
    {
        [TestMethod()]
        public void ConstructeurNainTest()
        {
            ConstructeurNain constructeurnain = new ConstructeurNain();
            Assert.IsNotNull(constructeurnain);
        }

        [TestMethod()]
        public void ConstruitTest()
        {
            ConstructeurNain constructeur = new ConstructeurNain();
            Assert.IsInstanceOfType(constructeur.Construit("Nain", Genre.Femme), typeof(Nain) );
        }
    }
}