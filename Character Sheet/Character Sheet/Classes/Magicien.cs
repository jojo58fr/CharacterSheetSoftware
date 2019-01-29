using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : Magicien.cs
Role ........ : Crée une classe Magicien ayant caractéristiques différentes de la classe personnage
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Constructeur du personnage par défaut de la classe Magicien.
    /// </summary>
    public class Magicien : Personnage
    {
        int magie;
        int soin;

        public Magicien(string nom, Genre sexe) : base(nom, sexe)
        {
            //Création aléatoire de statistiques
            Random rnd = new Random();
            magie = rnd.Next(30, 70);
            soin = rnd.Next(30, 70);
        }

        public override string statsToString()
        {
            return (base.statsToString() + " Magie: " + magie + "\n" + " Soin: " + soin);
        }

    }
}
