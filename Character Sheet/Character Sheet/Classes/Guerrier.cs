using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : Guerrier.cs
Role ........ : Crée une classe Guerrier ayant caractéristiques différentes de la classe personnage
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Constructeur du personnage par défaut de la classe Guerrier.
    /// </summary>
    public class Guerrier : Personnage
    {
        int vol;
        int agilité;

        public Guerrier(string nom, Genre sexe) : base(nom, sexe)
        {
            //Création aléatoire de statistiques
            Random rnd = new Random();
            vol = rnd.Next(30, 70);
            agilité = rnd.Next(30, 70);

        }

        public override string statsToString()
        {
            return (base.statsToString() + " Vol: " + vol + "\n" + " Agilité: " + agilité);
        }
    }
}
