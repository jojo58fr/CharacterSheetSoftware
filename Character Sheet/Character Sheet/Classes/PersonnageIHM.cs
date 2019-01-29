using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : PersonnageIHM.cs
Role ........ : Crée une classe Personnage s'occupant de la gestion de l'IHM sur le logiciel
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 13/12/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{

    public class PersonnageIHM : IPersonnage
    {
        private IPersonnage personnage;
        private string customImage;

        public PersonnageIHM(IPersonnage personnage)
        {
            this.personnage = personnage;

            //if(new Uri(""))
        }

        #region Image de profil

        /// <summary>
        /// Obtient l'image associée au personnage de jeu
        /// </summary>
        public string Image
        {
            get
            {
                string res;

                if(customImage != null || customImage == "")
                {
                    res = customImage;
                }
                else
                {
                    if (Sexe == Genre.Homme)
                        res = "male.jpg";
                    else if (Sexe == Genre.Femme)
                        res = "female.jpg";
                    else
                        res = null;
                }

                return res;
            }
            set
            {
                customImage = value;
            }
        }


        #endregion

        public Personnage Personnage
        {
            get
            {
                return personnage as Personnage;
            }
        }

        #region implémentation de l'interface  

        /// <summary>
        /// Affichage des principaux valeurs du projets sous forme de chaine de caractère.
        /// </summary>
        /// <returns>Chaine de caractère présentant le personnage sous forme de "profil"</returns>
        public override string ToString()
        {
            return Nom + " : " +  Classe;
        }

        public int Argent { get => personnage.Argent; set => personnage.Argent = value; }
        public string Classe { get => personnage.Classe; set => personnage.Classe = value; }

        public List<Equipement> Inventaire => personnage.Inventaire;

        public string Nom { get => personnage.Nom; set => personnage.Nom = value; }
        public Genre Sexe { get => personnage.Sexe; set => personnage.Sexe = value; }
        public int Vie { get => personnage.Vie; set => personnage.Vie = value; }

        public int Force { get => personnage.Force; set => personnage.Force = value; }
        public void AjoutEquipement(Equipement equipement)
        {
            personnage.AjoutEquipement(equipement);
        }

        public int CalculPoidsInventaire()
        {
            return personnage.CalculPoidsInventaire();
        }

        public string statsToString()
        {
            return personnage.statsToString();
        }

        #endregion
    }
}
