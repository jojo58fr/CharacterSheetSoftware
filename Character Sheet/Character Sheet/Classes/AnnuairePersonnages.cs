using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : AnnuairePersonnages.cs
Role ........ : Crée un annuaire listant les personnages du logiciel de gestion de fiche de personnages
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Annuaire des personnages. Listes les personnages 
    /// </summary>
    /// <see cref="Personne"/>
    public class AnnuairePersonnages
    {
        private List<Personnage> listePersonnages = new List<Personnage>();

        #region gestion du singleton
        /// <summary>
        /// Instance de la fabrique virtuel
        /// </summary>
        private static AnnuairePersonnages instance = null;

        /// <summary>
        /// Constructeur de la fabrique mit en privé pour forcer l'utilisation de l'instance
        /// </summary>
        private AnnuairePersonnages()
        {
        }

        /// <summary>
        /// Getter de l'instance de la fabrique virtuel permettant de la récupéreration
        /// </summary>
        public static AnnuairePersonnages Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnnuairePersonnages();

                }
                return instance;
            }
        }

        public List<Personnage> ListePersonnages { get => listePersonnages; set => listePersonnages = value; }
        #endregion

        /// <summary>
        /// Ajoute une personne à l'annuaire
        /// </summary>
        /// <param name="p"></param>
        /// <pre>p!=null</pre>
        public void NouveauPersonnage(Personnage p)
        {
            Debug.Assert(p != null); // Mise en place d'une assertion permettant de tester si le contact est correct
            ListePersonnages.Add(p);
        }

        /// <summary>
        /// Retire une personne de l'annuaire
        /// </summary>
        /// <param name="p"></param>
        public void SupprimerPersonnage(Personnage p)
        {
            ListePersonnages.Remove(p);
        }

        /// <summary>
        /// Cherche dans l'annuaire une personne avec l'identité indiquée
        /// </summary>
        /// <param name="id">l'identité de la personne, son nom</param>
        /// <returns>la personne trouvée, ou null si aucune n'existe</returns>
        public Personnage ChercherPersonnage(string id)
        {
            Personnage p = null;

            foreach (Personnage personnage in ListePersonnages)
            {
                if (personnage.Nom == id)
                {
                    p = personnage;
                    break; // nous verrons + tard une méthode plus propre pour faire la recherche en utilisant la programmation fonctionnelle
                }
            }

            return p;
        }

        /// <summary>
        /// Cherche dans l'annuaire toutes les personnes ayant la même identité
        /// </summary>
        /// <param name="id">l'identité de la personne, son nom</param>
        /// <returns>un tableau contenant les contacts</returns>
        public Personnage[] ChercherPersonnages(string id)
        {
            List<Personnage> liste = new List<Personnage>();

            foreach (Personnage personnage in ListePersonnages)
            {
                if (personnage.Nom == id)
                {
                    liste.Add(personnage);
                }
            }

            return liste.ToArray();
        }

        /// <summary>
        /// Liste l'ensemble des contacts
        /// </summary>
        /// <returns>un tableau avec l'ensemble des contacts</returns>
        public Personnage[] ListerPersonnages()
        {
            return ListePersonnages.ToArray();
        }

        /// <summary>
        /// Liste les contacts dont le nom commence par l'initiale indiquée
        /// </summary>
        /// <param name="initiale"></param>
        /// <returns>un tableau contenant les contacts</returns>
        public Personnage[] ListerPersonnages(char initiale)
        {
            List<Personnage> liste = new List<Personnage>();
            foreach (Personnage p in ListePersonnages)
            {
                if (p.Nom[0] == initiale)
                {
                    liste.Add(p);
                }
            }
            return liste.ToArray();
        }

        /// <summary>
        /// Retourne une liste de personnes dont le nom commence par le paramètre
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Personnage[] ChercherPersonnagePartiel(string s)
        {
            List<Personnage> liste = new List<Personnage>();
            int taille = s.Length;
            foreach (Personnage p in ListePersonnages)
            {
                if (p.Nom.Substring(0, taille).Equals(s, StringComparison.InvariantCultureIgnoreCase))
                {
                    liste.Add(p);
                }
            }
            return liste.ToArray();
        }

    }
}
