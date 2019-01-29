using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : ConstructeurMagicien.cs
Role ........ : Crée une classe constructeur virtuelle permettant le rajout dans la fabrique virtuel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{


    public class ConstructeurMagicien : ConstructeurPersonnage
    {
        /// <summary>
        /// Constructeur virtuel de la classe Magicien permettant de l'ajouter dans la fabrique
        /// </summary>
        public ConstructeurMagicien()
        {
            FabriquePersonnage.Instance.Inscrit("Magicien", this);
        }

        /// <summary>
        /// Création de l'objet Magicien, héritier de Personnage
        /// </summary>
        /// <param name="nom">Permet de définir un nom pour le personnage</param>
        /// <param name="sexe">Permet de définir le sexe du personne</param>
        /// <returns> L'objet personnage (en particulier l'objet Magicien)</returns>
        public Personnage Construit(string nom, Genre genre)
        {
            return new Magicien(nom,genre);
        }
    }
}
