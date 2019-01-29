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
    public class GuerrierTests
    {
        [TestMethod()]
        public void GuerrierTest()
        {
            Guerrier guerrier = new Guerrier("Guerrier", Genre.Homme);
            Assert.IsNotNull(guerrier);
        }
    }
}