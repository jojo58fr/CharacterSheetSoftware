using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : ConstructeurNain.cs
Role ........ : Crée une classe constructeur virtuelle permettant le rajout dans la fabrique virtuel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    public class ConstructeurNain : ConstructeurPersonnage
    {
        /// <summary>
        /// Constructeur virtuel de la classe Nain permettant de l'ajouter dans la fabrique
        /// </summary>
        public ConstructeurNain()
        {
            FabriquePersonnage.Instance.Inscrit("Nain", this);
        }

        /// <summary>
        /// Création de l'objet Nain, héritier de Personnage
        /// </summary>
        /// <param name="nom">Permet de définir un nom pour le personnage</param>
        /// <param name="sexe">Permet de définir le sexe du personne</param>
        /// <returns> L'objet personnage (en particulier l'objet Nain)</returns>
        public Personnage Construit(string nom, Genre genre)
        {
            return new Nain(nom, genre);
        }
    }
}
