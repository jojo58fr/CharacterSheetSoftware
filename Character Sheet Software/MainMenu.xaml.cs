using Character_Sheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Character_Sheet_Software
{

    /// <summary>
    /// Logique d'interaction pour mainmenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Constructeur par d�faut de la fen�tre
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
            ConstructeurGuerrier guerrier = new ConstructeurGuerrier();
            ConstructeurElfe elfe = new ConstructeurElfe();
            ConstructeurMagicien magicien = new ConstructeurMagicien();
            ConstructeurNain nain = new ConstructeurNain();

            string loadPath = Environment.CurrentDirectory + "/save.dat";
            Console.WriteLine("Endroit de sauvegarde: " + Environment.CurrentDirectory + "/save.dat");

            if (File.Exists(loadPath))
                AnnuairePersonnages.Instance.ListePersonnages = DataWriteRead.ReadFromJsonFile<List<Personnage>>(loadPath);

            DataWriteRead.WriteToJsonFile<List<Personnage>>(loadPath, AnnuairePersonnages.Instance.ListePersonnages);
        }

        /// <summary>
        /// Affichage de cr�ation de personnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewCharaSheet_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterSheetMenu window = new NewCharacterSheetMenu();
            window.ShowDialog();
        }

        /// <summary>
        /// Affichage de la fen�tre de gestions des listes des personnages & affichage de leur stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewCharaSheet_Click(object sender, RoutedEventArgs e)
        {
            ViewCharacterSheetMenu window = new ViewCharacterSheetMenu();
            window.ShowDialog();
 
        }
    }
}
