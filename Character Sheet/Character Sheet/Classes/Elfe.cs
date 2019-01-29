using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : Elfe.cs
Role ........ : Crée une classe Elfe ayant caractéristiques différentes de la classe personnage
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Constructeur du personnage par défaut de la classe Elfe.
    /// </summary>
    public class Elfe : Personnage
    {
        int magie;
        int divination;

        public Elfe(string nom, Genre sexe) : base(nom, sexe)
        {
            //Création aléatoire de statistiques
            Random rnd = new Random();
            magie = rnd.Next(30, 70);
            divination = rnd.Next(30, 70);
            intuition = (int) (intuition * 1.2f);
        }

        public override string statsToString()
        {
            return (base.statsToString() + " Magie: " + magie + "\n" + " Divination: " + divination);
        }
    }
}
