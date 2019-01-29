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
    public class FabriquePersonnageTests
    {
        [TestMethod()]
        public void InscritTest()
        {
            FabriquePersonnage.Instance.Inscrit("Guerrier", new ConstructeurGuerrier());
        }

        [TestMethod()]
        public void CreeTest()
        {
            FabriquePersonnage.Instance.Cree("Guerrier", "Saber", Genre.Femme);
            Assert.ThrowsException<ClasseException>( () => { FabriquePersonnage.Instance.Cree("Je suis un type", "je suis un nom", Genre.Femme); } );

        }


    }
}