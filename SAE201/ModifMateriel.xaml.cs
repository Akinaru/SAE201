using SAE201.Ressources;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour ModifMateriel.xaml
    /// </summary>
    public partial class ModifMateriel : Window
    {
        Materiel materiel;
        MainWindow fenetre;
        public ModifMateriel(Materiel mat, MainWindow fenetre)
        {
            InitializeComponent();
            foreach (CategorieMateriel cat in ApplicationData.LesCategories)
            {
                cbCategorie.Items.Add(cat.Nom);
                if (cat.Id == mat.IdCategorie)
                {
                    cbCategorie.SelectedItem = cat.Nom;
                }
            }
            materiel = mat;
            tbNom.Text = mat.Nom;
            tbCodeBarre.Text = mat.CodeBarre;
            tbRefConstructeur.Text = mat.RefConstructeur;
            this.fenetre = fenetre;
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategorie.SelectedItem == null || tbNom.Text.Trim() == "" || tbCodeBarre.Text.Trim() == "" || tbRefConstructeur.Text.Trim() == "")
            {
                if (tbNom.Text.Trim() == "")
                    tbNom.BorderBrush = Brushes.Red;
                else
                    tbNom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));

                if (tbCodeBarre.Text.Trim() == "")
                    tbCodeBarre.BorderBrush = Brushes.Red;
                else
                    tbCodeBarre.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));

                if (tbRefConstructeur.Text.Trim() == "")
                    tbRefConstructeur.BorderBrush = Brushes.Red;
                else
                    tbRefConstructeur.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));

                MessageBox.Show("L'un des champs est incorrect.", "Format", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var index = ApplicationData.LesMateriels.ToList().FindIndex(c => c.Id == materiel.Id);
                ApplicationData.LesMateriels[index].Nom = tbNom.Text;
                ApplicationData.LesMateriels[index].CodeBarre = tbCodeBarre.Text;
                ApplicationData.LesMateriels[index].RefConstructeur = tbRefConstructeur.Text;
                fenetre.listViewMateriel.Items.Refresh();
                if (!materiel.Update())
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
