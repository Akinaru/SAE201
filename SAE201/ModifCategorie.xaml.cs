using SAE201.Ressources;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour ModifCategorie.xaml
    /// </summary>
    public partial class ModifCategorie : Window
    {
        CategorieMateriel catego;
        MainWindow fenetre;

        /// <summary>
        /// Constructeur de la fenêtre modification categorie, activé lors du clic droit et modification d'une catégorie.
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="window">Pour pouvoir récupérer les listview,...</param>
        public ModifCategorie(CategorieMateriel categorie, MainWindow window)
        {
            InitializeComponent();
            catego = categorie;
            tbNom.Text = categorie.Nom;
            fenetre = window;
        }


        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            if (tbNom.Text.Trim() == "")
            {
                tbNom.BorderBrush = Brushes.Red;
                MessageBox.Show("Champs incorrect.", "Format", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var index = ApplicationData.LesCategories.ToList().FindIndex(c => c.Id == catego.Id);
                ApplicationData.LesCategories[index].Nom = tbNom.Text;
                fenetre.listViewCategorie.Items.Refresh();
                if (!catego.Update())
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
