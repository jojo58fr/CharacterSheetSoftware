using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : Nain.cs
Role ........ : Crée une classe Nain ayant caractéristiques différentes de la classe personnage
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Constructeur du personnage par défaut de la classe Nain.
    /// </summary>
    public class Nain : Personnage
    {
        int vol;
        int armes;

        public Nain(string nom, Genre sexe) : base(nom, sexe)
        {
            //Création aléatoire de statistiques
            Random rnd = new Random();
            vol = rnd.Next(30, 70);
            armes = rnd.Next(30, 70);
            this.combat = (int)(combat * 1.2);
        }

        public override string statsToString()
        {
            return (base.statsToString() + " Vol: " + vol + "\n" + " Armes: " + armes);
        }

    }
}
