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
    public class MagicienTests
    {
        [TestMethod()]
        public void MagicienTest()
        {
            Magicien magicien = new Magicien("Magicien", Genre.Homme);
            Assert.IsNotNull(magicien);
        }
    }
}