using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Character_Sheet;

namespace Character_Sheet.Tests
{
    [TestClass()]
    public class PersonnageTests
    {
        [TestMethod()]
        public void PersonnageTest()
        {
            Personnage personnnage = new Personnage("Saber",Genre.Femme);
            Assert.IsNotNull(personnnage);
        }

        [TestMethod()]
        public void AjoutEquipementTest()
        {
            Personnage personnage = new Personnage("Saber", Genre.Femme);

            personnage.AjoutEquipement(new Equipement("Excalibur", 50000, 5));
           
            if(personnage.Inventaire.Count <= 0)
            {
                Assert.Fail();
            }

            Assert.ThrowsException<EquipementException>( () => { personnage.AjoutEquipement(new Equipement("Excalibur", 50000, 500)); } ); //Test Surcharge


        }

        [TestMethod()]
        public void ToStringTest()
        {
            Personnage personnage = new Personnage("Saber", Genre.Femme);
            personnage.ToString();
            personnage.AjoutEquipement(new Equipement("Excalibur", 50000, 5));
            personnage.ToString();
        }
    }
}