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
    public class NainTests
    {
        [TestMethod()]
        public void NainTest()
        {
            Nain nain = new Nain("nain", Genre.Homme);
            Assert.IsNotNull(nain);
        }
    }
}