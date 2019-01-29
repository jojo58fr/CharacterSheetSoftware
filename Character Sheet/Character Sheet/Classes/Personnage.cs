using System;
using System.Collections.Generic;

/*******************************************************
Nom ......... : Personnage.cs
Role ........ : Crée une classe Personnage permettant la création de fiche avec caractéristiques pour le logiciel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{

    public class Personnage : IPersonnage
    {
        #region Variables Personnages

        private string nom; //Nom du personnage
        private int vie; //Point de vie du personnage
        private int argent; //Argent du personnage
        private string classe; //Classe du personnage
        private Genre sexe; //Sexe du personnage

        #region Statistiques Personnages

        //Différentes statistiques permettant de déterminer les faiblesses et les qualités du personnage

        protected int force;
        protected int combat;
        protected int intelligence;
        protected int intuition;

        #endregion

        //Equipement du personnage actuel (Agrégation)
        private List<Equipement> inventaire = new List<Equipement>();

        public List<Equipement> Inventaire { get => inventaire; }
        public string Nom { get => nom; set => nom = value; }
        public int Vie { get => vie; set => vie = value; }
        public int Argent { get => argent; set{ if(argent >= value) argent = value;} }
        public Genre Sexe { get => sexe; set => sexe = value; }
        public string Classe { get => classe; set => classe = value; }
        public int Force { get => force; set => force = value; }

        #endregion

        /// <summary>
        /// Constructeur du personnage par défaut de la classe Personnage. Les caractéristiques sont aléatoires.
        /// </summary>
        /// <param name="nom">Permet de définir un nom pour le personnage</param>
        /// <param name="sexe">Permet de définir le sexe du personne</param>
        public Personnage(string nom, Genre sexe)
        {
            this.nom = nom;
            this.sexe = sexe;
            this.classe = GetType().Name;
            vie = 100;
            argent = 30;

            //Création aléatoire de statistiques
            Random rnd = new Random();
            force = rnd.Next(30,70);
            combat = rnd.Next(30, 70);
            intelligence = rnd.Next(30, 70);
            intuition = rnd.Next(30, 70);


        }
        
        /// <summary>
        /// Permet de calculer le poids total de l'inventaire du personnage
        /// </summary>
        /// <returns> (int) Le poids de la liste Equipement</returns>
        public int CalculPoidsInventaire()
        {
            int calculpoids = 0;

            if (inventaire != null)
            {
                foreach (Equipement e in inventaire)
                {
                    calculpoids += e.Poids;
                }
            }

            return calculpoids;
        }


        /// <summary>
        /// Permet d'ajouter de l'équipement au personnage par le biais d'une Liste<Equipement>
        /// </summary>
        /// <param name="equipement">Permet de définir l'équipement à rajouter dans la liste</param>
        public void AjoutEquipement(Equipement equipement)
        {
            //Console.WriteLine(" Equipement actuel: " + equipement.Nom);

            if ((equipement.Poids + CalculPoidsInventaire() ) < (force / 3))
            {
                inventaire.Add(equipement);
            }
            else
            {
                throw new EquipementException("ERREUR : Le personnage est surchargé, ajout de l'équipement impossible.");
            }
        }

        public virtual string statsToString()
        {
            return "Force: " + force + "\n" + " Combat: " + combat + "\n" + " Intelligence: " + intelligence + "\n" + " Intuition: " + intuition  + "\n";
        }

    }
}
