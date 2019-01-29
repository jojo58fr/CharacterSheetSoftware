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
    public class EquipementTests
    {
        [TestMethod()]
        public void EquipementTest()
        {
            Equipement equipemennt = new Equipement("Excalibur", 50000, 5);
            Assert.IsNotNull(equipemennt);
        }
    }
}