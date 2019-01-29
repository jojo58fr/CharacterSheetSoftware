﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : ConstructeurGuerrier.cs
Role ........ : Crée une classe constructeur virtuelle permettant le rajout dans la fabrique virtuel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{

    public class ConstructeurGuerrier : ConstructeurPersonnage
    {
        /// <summary>
        /// Constructeur virtuel de la classe Guerrier permettant de l'ajouter dans la fabrique
        /// </summary>
        public ConstructeurGuerrier()
        {
            FabriquePersonnage.Instance.Inscrit("Guerrier", this);
        }

        /// <summary>
        /// Création de l'objet Guerrier, héritier de Personnage
        /// </summary>
        /// <param name="nom">Permet de définir un nom pour le personnage</param>
        /// <param name="sexe">Permet de définir le sexe du personne</param>
        /// <returns> L'objet personnage (en particulier l'objet Guerrier)</returns>
        public Personnage Construit(string nom, Genre genre)
        {
            return new Guerrier(nom,genre);
        }
    }
}
