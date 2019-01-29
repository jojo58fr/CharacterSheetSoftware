using Character_Sheet;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Character_Sheet_Software
{
    /// <summary>
    /// Logique d'interaction pour ViewCharacterSheetMenu.xaml
    /// </summary>
    public partial class ViewCharacterSheetMenu : Window
    {

        PersonnageIHM instanceP; //Instance du personage sélectionné
        Equipement instanceE; //Instance de l'équipement sélectionné

        /// <summary>
        /// Constructeur par défaut de la fenêtre
        /// </summary>
        public ViewCharacterSheetMenu()
        {
            InitializeComponent();

            RefreshAllList(); //Rafraichie la liste

            /**
             * Ajouts  � la combobox
             * */

            ComboBoxClasse.ItemsSource = FabriquePersonnage.Instance.Types;
            //Prévient si null
            if (ComboBoxClasse.Items.GetItemAt(0) != null)
            {
                ComboBoxClasse.SelectedItem = ComboBoxClasse.Items.GetItemAt(0); //Sélection du premier item
            }

            ResetScreen();
        }

        /// <summary>
        /// Recharge de la liste équipement de la fenêtre
        /// </summary>
        public void RefreshEquipementList()
        {
            if (instanceP != null)
            {
                InventaireListBox.Items.Clear();

                foreach (Equipement equip in instanceP.Inventaire)
                {
                    InventaireListBox.Items.Add(equip);
                }

                DeleteEquipementButton.IsEnabled = true;

                LabelMoney.Content = "Argent: " + instanceP.Argent;

            }

            DataWriteRead.WriteToJsonFile<List<Personnage>>(Environment.CurrentDirectory + "/save.dat", AnnuairePersonnages.Instance.ListePersonnages);

        }

        /// <summary>
        /// Recharge des listes équipement & personnage des fenêtres
        /// </summary>
        public void RefreshAllList()
        {
            if (instanceP != null)
            {
                InventaireListBox.Items.Clear();

                foreach (Equipement equip in instanceP.Inventaire)
                {
                    InventaireListBox.Items.Add(equip);
                }

                DeleteEquipementButton.IsEnabled = true;

                LabelMoney.Content = "Argent: " + instanceP.Argent;

            }

            Personnage[] liste = AnnuairePersonnages.Instance.ListerPersonnages();
            CharacterListBox.Items.Clear(); //Nettoyer la liste d'items

            if (liste == null)
            {
                ResetScreen(); //Si liste null, affichage par défaut
                DeleteButton.IsEnabled = false;
            }
            else
            {

                foreach (Personnage p in liste)
                {
                    CharacterListBox.Items.Add(new PersonnageIHM(p)); //Ajout de tous les personnages présent dans la liste
                }


                DeleteButton.IsEnabled = true;
            }

            ComboBoxClasse.ItemsSource = FabriquePersonnage.Instance.Types;
            ComboBoxClasse.SelectedItem = ComboBoxClasse.Items.GetItemAt(0);

            DataWriteRead.WriteToJsonFile<List<Personnage>>(Environment.CurrentDirectory + "/save.dat", AnnuairePersonnages.Instance.ListePersonnages);

        }

        /// <summary>
        /// Remise par défaut les valeurs de tous les objets sur la fenêtre
        /// </summary>
        private void ResetScreen()
        {
            TextBoxName.Text = "";
            LabelTitle.Content = "Fiche de personnage : Veuillez sélectionner un personnage";
            StatsTextBlock.Text = "";
            RadioButtonGenderFemale.IsChecked = false;
            RadioButtonGenderMale.IsChecked = false;
            InventaireListBox.Items.Clear();
            Panel1.Visibility = Visibility.Visible;
            Panel2.Visibility = Visibility.Collapsed;
            DeleteButton.IsEnabled = false;
            InfosButtons.IsEnabled = false;
            InventaireButton.IsEnabled = false;
            DeleteEquipementButton.IsEnabled = false;
            AddEquipementButton.IsEnabled = false;
            LabelMoney.Content = "Argent: ";
            ComboBoxClasse.SelectedItem = null;

            if (instanceP != null)
            {
                CharacterImage.Source = new BitmapImage(new Uri("Images/" + instanceP.Image, UriKind.Relative));
            }

            else
            {
                CharacterImage.Source = null;
            }

        }

        /// <summary>
        /// Fermeture de la fenêtre via boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Fermeture de la fenêtre via boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event lors d'un changement dans la liste de personnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CharacterListBox.SelectedItem != null)
            {
                
                instanceP = (PersonnageIHM)CharacterListBox.SelectedItem;

                // new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/male.jpg", UriKind.Relative));
                LabelTitle.Content = "Fiche de personnage : " + instanceP.Nom; 
                TextBoxName.Text = instanceP.Nom;
                ComboBoxClasse.SelectedItem = ComboBoxClasse.Items.IndexOf(instanceP.Classe);
                ComboBoxClasse.Text = instanceP.Classe;

                if (instanceP.Sexe == Genre.Homme)
                {
                    RadioButtonGenderMale.IsChecked = true;
                }
                else
                {
                    RadioButtonGenderFemale.IsChecked = true;
                }


                CharacterImage.Source = new BitmapImage(new Uri("Images/" + instanceP.Image, UriKind.Relative));

                StatsTextBlock.Text = instanceP.statsToString();

                InventaireListBox.Items.Clear();

                foreach (Equipement equip in instanceP.Inventaire)
                {
                    InventaireListBox.Items.Add(equip);
                }

                InfosButtons.IsEnabled = true;
                InventaireButton.IsEnabled = true;
                DeleteEquipementButton.IsEnabled = false;
                DeleteButton.IsEnabled = true;
                AddEquipementButton.IsEnabled = true;
                LabelMoney.Content = "Argent: " + instanceP.Argent;
            }
            else
            {
                instanceP = null;
                DeleteButton.IsEnabled = false;
            }


        }

        /// <summary>
        /// Bouton de suppression de personnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (instanceP != null)
            {
                if (MessageBox.Show("Voulez-vous supprimer ce personnage ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AnnuairePersonnages.Instance.ListePersonnages.Remove(instanceP.Personnage);
                    RefreshAllList();
                    ResetScreen();
                }
            }
        }

        /// <summary>
        /// Gestion des panneaux équipement et personnages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelStats_Click(object sender, RoutedEventArgs e)
        {
            Panel1.Visibility = Visibility.Visible;
            Panel2.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Gestion des panneaux équipement et personnages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelInventaire_Click(object sender, RoutedEventArgs e)
        {
            Panel1.Visibility = Visibility.Collapsed;
            Panel2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Gestion du changement de l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Bouton pour l'ajout d'équipement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEquipementButton_Click(object sender, RoutedEventArgs e)
        {
            AddEquipement addEquipement = new AddEquipement(instanceP.Personnage, this);
            addEquipement.ShowDialog();
        }

        /// <summary>
        /// Bouton pour la suppresion d'équipement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEquipementButton_Click(object sender, RoutedEventArgs e)
        {
            if(instanceE != null)
            {
                if (MessageBox.Show("Voulez-vous supprimer cette équipement ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    instanceP.Inventaire.Remove(instanceE);
                    RefreshEquipementList();

                    if(InventaireListBox.Items.Count <= 0)
                        ResetScreen();
                }
            }
        }

        /// <summary>
        /// Gestion de changement de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventaireListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InventaireListBox.SelectedItem != null && instanceP != null)
            {
                instanceE = (Equipement)InventaireListBox.SelectedItem;
                DeleteEquipementButton.IsEnabled = true;
            }
            else
            {
                instanceE = null;
                DeleteEquipementButton.IsEnabled = false;
            }
        }
    }

}
