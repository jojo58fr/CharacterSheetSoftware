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
    public class ConstructeurElfeTests
    {
        [TestMethod()]
        public void ConstructeurElfeTest()
        {
            ConstructeurElfe constructeurelfe = new ConstructeurElfe();
            Assert.IsNotNull(constructeurelfe);
        }

        [TestMethod()]
        public void ConstruitTest()
        {
            ConstructeurElfe constructeur = new ConstructeurElfe();
            Assert.IsInstanceOfType(constructeur.Construit("Elfe", Genre.Femme), typeof(Elfe));
        }
    }
}