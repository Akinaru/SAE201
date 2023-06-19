using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour AjoutMateriel.xaml
    /// </summary>
    public partial class AjoutMateriel : Window
    {

        public MainWindow fenetre;

        public AjoutMateriel(CategorieMateriel categorie, MainWindow fenetre)
        {
            InitializeComponent();
            this.fenetre = fenetre;
            tbNom.Focus();
            foreach (CategorieMateriel cat in ApplicationData.LesCategories)
            {
                cbCategorie.Items.Add(cat.Nom);
                if (cat.Nom == categorie.Nom)
                {
                    cbCategorie.SelectedItem = cat.Nom;
                }
            }

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
                CategorieMateriel c = new CategorieMateriel(0, (string)cbCategorie.SelectedItem);
                int id = c.GetId();
                Materiel p = new Materiel(0, tbNom.Text, tbCodeBarre.Text, tbRefConstructeur.Text, id);

                if (p.Create())
                {
                    Materiel pFinal = new Materiel(p.GetId(), p.Nom, p.CodeBarre, p.RefConstructeur, p.IdCategorie);
                    ApplicationData.LesMateriels.Add(pFinal);
                    foreach (CategorieMateriel lesCategories in ApplicationData.LesCategories)
                        if (lesCategories.Id == id)
                            lesCategories.LesMateriels = new ObservableCollection<Materiel>(ApplicationData.LesMateriels.ToList().FindAll(g => g.IdCategorie == lesCategories.Id));
                    fenetre.listViewMateriel.DataContext = fenetre.listViewCategorie.SelectedItem;
                    fenetre.listViewMateriel.ItemsSource = ((CategorieMateriel)fenetre.listViewCategorie.SelectedItem).LesMateriels;
                }
                else
                    MessageBox.Show("La création a été refusée.", "Ajout Materiel", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
            
            
            

        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNom.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }

        private void tbCodeBarre_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCodeBarre.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }

        private void tbRefConstructeur_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbRefConstructeur.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }
    }
}
