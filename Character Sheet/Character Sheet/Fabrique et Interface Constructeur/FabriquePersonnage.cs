using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
Nom ......... : FabriquePersonnage.cs
Role ........ : Crée une classe fabrique virtuelle permettant le rajout de n'importe quel classe tant qu'elle dispose d'un parent commun
Auteur ...... : MIENS Joachim
Version ..... : V0.1 du 16/11/2017
Licence ..... : 
********************************************************/

namespace Character_Sheet
{
    /// <summary>
    /// Fabrique abstraite permettant la création du personnage
    /// </summary>
    public class FabriquePersonnage
    {
        #region gestion du singleton
        /// <summary>
        /// Instance de la fabrique virtuel
        /// </summary>
        private static FabriquePersonnage instance = null;

        /// <summary>
        /// Constructeur de la fabrique mit en privé pour forcer l'utilisation de l'instance
        /// </summary>
        private FabriquePersonnage() {
        }

        /// <summary>
        /// Getter de l'instance de la fabrique virtuel permettant de la récupéreration
        /// </summary>
        public static FabriquePersonnage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FabriquePersonnage();
                    
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Dictionnaire répertoriant tous les personnages crée virtuellement par le ou les constructeurs virtuels
        /// </summary>
        private Dictionary<String, ConstructeurPersonnage> constructeurs = new Dictionary<string, ConstructeurPersonnage>();

        /// <summary>
        /// Getter de la liste de constructeur
        /// </summary>
        public Dictionary<string, ConstructeurPersonnage> Constructeurs { get => constructeurs; }

        /// <summary>
        /// Inscrit un nouveau constructeur virtuel
        /// </summary>
        /// <param name="type">le nom du type</param>
        /// <param name="cons">le constructeur virtuel</param>
        public void Inscrit(String type, ConstructeurPersonnage cons)
        {
            constructeurs[type] = cons;
        }

        /// <summary>
        /// Obtient la liste des types que la fabrique sait construire
        /// </summary>
        public String[] Types
        {
            get { return constructeurs.Keys.ToArray(); }
        }

        /// <summary>
        /// Crée un un personnage selon les paramètres
        /// </summary>
        /// <param name="type">le type voulu</param>
        /// <param name="nom">le nom du personnage</param>
        /// <param name="genre">Le genre du personnage</param>
        /// <returns>un personnage créé, du type demandé</returns>
        /// <exception cref="Exception">Le type est inconnu de la fabrique</exception>
        public Personnage Cree(String type, String nom, Genre genre)
        {
            if (!constructeurs.ContainsKey(type))
            {
                throw new ClasseException("Type " + type + " inconnu");
            }

            return constructeurs[type].Construit(nom, genre);
        }

        public override string ToString()
        {
            string res = "";
            foreach (KeyValuePair<String, ConstructeurPersonnage> kvp in Constructeurs)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                res = kvp.Key + " " +  kvp.Value;
            }
            return res;
        }


    }

}
