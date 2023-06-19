using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour ModifPersonnel.xaml
    /// </summary>
    public partial class ModifPersonnel : Window
    {
        Personnel perso;
        MainWindow fenetre;
        public ModifPersonnel(Personnel personnel, MainWindow fenetre)
        {
            InitializeComponent();
            perso = personnel;
            tbNom.Text = personnel.Nom;
            tbPrenom.Text = personnel.Prenom;
            tbEmail.Text = personnel.Email;
            this.fenetre = fenetre;
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            string paterne = @"@";

            if (tbEmail.Text.Trim() == "" || tbNom.Text.Trim() == "" || tbPrenom.Text.Trim() == "" || !Regex.IsMatch(tbEmail.Text, paterne))
            {
                if (tbPrenom.Text.Trim() == "")
                    tbPrenom.BorderBrush = Brushes.Red;
                else
                    tbPrenom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));


                if (tbNom.Text.Trim() == "")
                    tbNom.BorderBrush = Brushes.Red;
                else
                    tbNom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));


                if (tbEmail.Text.Trim() == "")
                    tbEmail.BorderBrush = Brushes.Red;
                else
                    tbEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));


                if (!Regex.IsMatch(tbEmail.Text, paterne))
                    tbEmail.BorderBrush = Brushes.Red;
                else
                    tbEmail.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
                MessageBox.Show("L'un des champs est incorrect.", "Format", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var index = ApplicationData.LesPersonnels.ToList().FindIndex(c => c.Id == perso.Id);
                ApplicationData.LesPersonnels[index].Nom = tbNom.Text;
                ApplicationData.LesPersonnels[index].Prenom = tbPrenom.Text;
                ApplicationData.LesPersonnels[index].Email = tbEmail.Text;
                fenetre.listViewPersonnel.Items.Refresh();
                if (!perso.Update())
                    MessageBox.Show("La création a été refusée.", "Ajout Categorie", MessageBoxButton.OK, MessageBoxImage.Warning);

                this.Close();
            }

        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
