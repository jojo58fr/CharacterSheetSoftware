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
    public class ElfeTests
    {
        [TestMethod()]
        public void ElfeTest()
        {
            Elfe elfe = new Elfe("Elfe", Genre.Homme);
            Assert.IsNotNull(elfe);
        }
    }
}