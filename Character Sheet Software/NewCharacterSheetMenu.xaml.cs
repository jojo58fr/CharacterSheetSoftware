using Character_Sheet;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Character_Sheet_Software
{
    /// <summary>
    /// Logique d'interaction pour NewCharacterSheetMenu.xaml
    /// </summary>
    public partial class NewCharacterSheetMenu : Window
    {
        BitmapImage instanceImage;
        string defaultNameValue;
        string pathImage;

        /// <summary>
        /// Constructeur par défaut de la fenêtre
        /// </summary>
        public NewCharacterSheetMenu()
        {
            InitializeComponent();

            ComboBoxClasse.ItemsSource = FabriquePersonnage.Instance.Types;
            ComboBoxClasse.SelectedItem = ComboBoxClasse.Items.GetItemAt(0);
            ButtonValidate.IsEnabled = false;
            defaultNameValue = TextBoxName.Text;
        }

        /// <summary>
        /// Bouton permettant d'annuler l'ouverture de la fen�tre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gestion du bouton pour valider et cr�er le personnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {

            Genre resGender; //= (Genre) Convert.ToInt32(RadioButtonGenderFemale.IsChecked.Value | RadioButtonGenderMale.IsChecked.Value);

            if(RadioButtonGenderMale.IsChecked.Value == true)
            {
                resGender = Genre.Homme;
            }
            else
            {
                resGender = Genre.Femme;
            }

            PersonnageIHM personnage = new PersonnageIHM(FabriquePersonnage.Instance.Cree(ComboBoxClasse.SelectedItem.ToString(), TextBoxName.Text, resGender));

            personnage.Image = pathImage;

            AnnuairePersonnages.Instance.NouveauPersonnage(personnage.Personnage);

            //instanceImage = (BitmapImage)CharacterImage.Source;

            //DataWriteRead.WriteToBinaryFile<BitmapImage>("Data/images/" + personnage.Nom + "-" + AnnuairePersonnages.Instance.ListePersonnages.IndexOf(personnage), instanceImage, true);

            DataWriteRead.WriteToJsonFile<List<Personnage>>(Environment.CurrentDirectory + "/save.dat",AnnuairePersonnages.Instance.ListePersonnages);
            this.Close();
           
        }


        /// <summary>
        /// Lorsque le nom du textBox change, vérification du nom et gestion du bouton valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(TextBoxName.Text == "" || TextBoxName.Text == defaultNameValue )
            {
                ButtonValidate.IsEnabled = false;
            }
            else
            {
                ButtonValidate.IsEnabled = true;
            }



        }

        private void RadioButtonGenderMale_Checked(object sender, RoutedEventArgs e)
        {
            CharacterImage.Source = new BitmapImage(new Uri("Images/male.jpg", UriKind.Relative));
        }

        private void RadioButtonGenderFemale_Checked(object sender, RoutedEventArgs e)
        {
            CharacterImage.Source = new BitmapImage(new Uri("Images/female.jpg", UriKind.Relative));
        }
    }
    }

