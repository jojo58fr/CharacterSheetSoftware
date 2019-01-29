using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : Equipement.cs
Role ........ : Crée un objet equipement dont le personnage peux interargir avec.
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    public class Equipement
    {
        #region Variables Equipement

        private string nom;
        private int prix;
        private int poids;

        #endregion

        /// <summary>
        /// Constructeur par défaut de la classe Equipement. Permet de définir son nom, son prix et son poids
        /// </summary>
        /// <param name="nom">Le nom de l'équipement</param>
        /// <param name="prix">Le prix de l'équipement</param>
        /// <param name="poids">Le poids de l'équipement</param>
        public Equipement(string nom, int prix, int poids)
        {
            this.nom = nom;
            this.prix = prix;
            this.poids = poids;
        }

        /// <summary>
        /// Getter de la variable poids
        /// </summary>
        public int Poids { get => poids; set => poids = value; }
        /// <summary>
        /// Getter de la variable prix
        /// </summary>
        public int Prix { get => prix; set => prix = value; }
        /// <summary>
        /// Getter de la variable Nom
        /// </summary>
        public string Nom { get => nom; set => nom = value; }

        public override string ToString()
        {
            return "Nom: " + Nom + " Prix: " + prix + " Poids: " + poids + " kg";
        }

    }
}
