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
    public class ConstructeurMagicienTests
    {
        [TestMethod()]
        public void ConstructeurMagicienTest()
        {
            ConstructeurMagicien constructeurmagicien = new ConstructeurMagicien();
            Assert.IsNotNull(constructeurmagicien);
        }

        [TestMethod()]
        public void ConstruitTest()
        {
            ConstructeurMagicien constructeur = new ConstructeurMagicien();
            Assert.IsInstanceOfType(constructeur.Construit("Magicien", Genre.Femme), typeof(Magicien));
        }
    }
}