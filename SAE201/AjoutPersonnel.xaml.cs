using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace SAE201
{
    /// <summary>
    /// Fenêtre pour ajouter un personnel
    /// </summary>
    public partial class AjoutPersonnel : Window
    {
        /// <summary>
        /// Constructeur de la fenêtre ajout personnel, activé lors du clic sur le bouton d'ajout de personnel.
        /// </summary>
        public AjoutPersonnel()
        {
            InitializeComponent();
            tbPrenom.Focus();
        }


        private void btCreer_Click(object sender, RoutedEventArgs e)
        { 
            string paterne = @"@";
            
            if (tbEmail.Text.Trim() == "" || tbNom.Text.Trim() == "" || tbPrenom.Text.Trim() == "" || !Regex.IsMatch(tbEmail.Text, paterne))
            {
                if (tbEmail.Text.Trim() == "")
                    tbEmail.BorderBrush = Brushes.Red;
                else
                    tbEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));

                if (tbNom.Text.Trim() == "")
                    tbNom.BorderBrush = Brushes.Red;
                else
                    tbNom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
                
                if (tbPrenom.Text.Trim() == "")
                    tbPrenom.BorderBrush = Brushes.Red;
                else
                    tbPrenom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
                
                if (!Regex.IsMatch(tbEmail.Text, paterne))
                    tbEmail.BorderBrush = Brushes.Red;
                else
                    tbEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
                MessageBox.Show("L'un des champs est incorrect.", "Format", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            { 
                Personnel p = new Personnel(0, tbNom.Text, tbPrenom.Text, tbEmail.Text);

                if (p.Create())
                {
                    Personnel pFinal = new Personnel(p.GetId(), p.Nom, p.Prenom, p.Email);
                    ApplicationData.LesPersonnels.Add(pFinal);

                }
                else
                    MessageBox.Show("La création a été refusée.", "Ajout Personnel", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }


            
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbPrenom_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbPrenom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }

        private void tbNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }
    }
}
