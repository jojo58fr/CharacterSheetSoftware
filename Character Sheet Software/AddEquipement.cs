using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Character_Sheet;
using System.Text.RegularExpressions;

namespace Character_Sheet_Software
{

    public partial class AddEquipement : Window
    {
        #region Attributs
        private Personnage personnage;
        private Equipement equipement;
        private ViewCharacterSheetMenu parent;
        #endregion

        /// <summary>
        /// Gestion de la fenêtre d'ajout équipement
        /// </summary>
        /// <param name="p">Personnage concerné</param>
        /// <param name="pa">Fenêtre parente</param>
        public AddEquipement(Personnage p, ViewCharacterSheetMenu pa)
        {
            InitializeComponent();

            personnage = p;
            parent = pa;
            Equipement equip = new Equipement(NameTextBox.Text, 0, (int)WeightSlider.Value);
            this.equipement = equip;
            AddEquipementButton.IsEnabled = false;
            WeightSlider.Maximum = p.Force / 3;


            WeightLabel.Content = (int)WeightSlider.Value;
            MoneyLabel.Content = 0;


        }

        /// <summary>
        /// Gestion du texte pour le nom de l'équipement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nomE_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (NameTextBox.Text != "")
            {
                AddEquipementButton.IsEnabled = true;
            }
            else
            {
                AddEquipementButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Gestion du changement du texte numérique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberTextBox_TextChanged(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }


        }

        /// <summary>
        /// Slider pour la gestion du prix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MoneyLabel != null)
            {
                MoneyLabel.Content = PrixTextBox.Text;
            }

            if (PrixTextBox.Text != "")
            {
                if (personnage.Argent < int.Parse(PrixTextBox.Text))
                {
                    AddEquipementButton.IsEnabled = false;
                }
                else if (NameTextBox.Text != "")
                {
                    AddEquipementButton.IsEnabled = true;
                }
            }
        }

        /// <summary>
        /// Gestion de l'équipement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handle = !IsTextAllowed(e.text);
            e.Handled = !IsTextAllowed(e.Text);
            
        }

        /// <summary>
        /// slider pour le poids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (personnage != null)
            {
                if (WeightLabel != null)
                {
                    WeightLabel.Content = (int)WeightSlider.Value;
                }



                Equipement equip = new Equipement("item", (int)WeightSlider.Value, 10);

                if ((equipement.Poids + personnage.CalculPoidsInventaire()) < (personnage.Force / 3) && NameTextBox.Text != "")
                {
                    WarningWeightLabel.Content = "";
                    AddEquipementButton.IsEnabled = true;
                    this.equipement = equip;
                }
                else
                {
                    AddEquipementButton.IsEnabled = false;
                    WarningWeightLabel.Content = "Equipement trop lourd, ajout impossible.";
                }

            }


        }
        /// <summary>
        /// Gestion de l'équipement bouton
        /// equiper l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equipButton_Click(object sender, RoutedEventArgs e)
        {

            if (PrixTextBox.Text == "")
                PrixTextBox.Text = "0";

            int prix = int.Parse(PrixTextBox.Text);
            equipement.Prix = prix;
            equipement.Nom = NameTextBox.Text;  


            personnage.AjoutEquipement(equipement);
            personnage.Argent = personnage.Argent - int.Parse(PrixTextBox.Text);
            DataWriteRead.WriteToJsonFile<List<Personnage>>(Environment.CurrentDirectory + "/save.dat", AnnuairePersonnages.Instance.ListePersonnages);
            parent.RefreshEquipementList();
            this.Close();
        }

        /// <summary>
        /// Vérification de si le texte est uniquement numérique
        /// </summary>
        /// <param name="text">texte variable</param>
        /// <returns></returns>
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex pour vérifier
            return !regex.IsMatch(text);
        }
    }
}
