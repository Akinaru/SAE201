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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Window pageAjout;
        private Window pageAide;
        private Window pageModif;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listViewMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewMateriel.SelectedItem != null)
            {

                if(listViewPersonnel.SelectedItem == null)
                {
                    listViewAttribution.DataContext = listViewMateriel.SelectedItem;
                    listViewAttribution.ItemsSource = ((Materiel)listViewMateriel.SelectedItem).LesAttributions;
                }

                
            }
        }
        private void listViewPersonnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewPersonnel.SelectedItem != null)
            {

                if (listViewMateriel.SelectedItem == null)
                {
                    listViewAttribution.DataContext = listViewPersonnel.SelectedItem;
                    listViewAttribution.ItemsSource = ((Personnel)listViewPersonnel.SelectedItem).LesAttributions;
                }


            }
        }

        private void listViewCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {
                listViewMateriel.DataContext = listViewCategorie.SelectedItem;
                listViewMateriel.ItemsSource = ((CategorieMateriel)listViewCategorie.SelectedItem).LesMateriels;
            }
        }

        private void btResetSelecCategorie_Click(object sender, RoutedEventArgs e)
        {
            listViewCategorie.SelectedItem = null;
            listViewMateriel.ItemsSource = null;
        }

        private void btResetSelecMateriel_Click(object sender, RoutedEventArgs e)
        {
            listViewMateriel.SelectedItem = null;
            listViewAttribution.ItemsSource = ApplicationData.LesAttributions;
        }

        private void btResetSelecPersonnel_Click(object sender, RoutedEventArgs e)
        {
            listViewPersonnel.SelectedItem = null;
            listViewAttribution.ItemsSource = ApplicationData.LesAttributions;
            
        }

        private void MenuModificationPersonnel(object sender, RoutedEventArgs e)
        {
            if(listViewPersonnel.SelectedItem != null)
            {
                pageModif = new ModifPersonnel((Personnel)listViewPersonnel.SelectedItem);
                pageModif.Show();
            }
        }

        private void MenuSuppressionPersonnel(object sender, RoutedEventArgs e)
        {
            if (listViewPersonnel.SelectedItem != null)
            {
                
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer \"" + ((Personnel)listViewPersonnel.SelectedItem).Nom + " " + ((Personnel)listViewPersonnel.SelectedItem).Prenom + "\" ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (((Personnel)listViewPersonnel.SelectedItem).Delete())
                        ApplicationData.LesPersonnels.Remove((Personnel)listViewPersonnel.SelectedItem);

                }
            }
        }

        private void MenuModificationAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                pageModif = new ModifAttribution((Attribution)listViewAttribution.SelectedItem);
                pageModif.Show();
            }
        }
        private void MenuSuppressionAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {

                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer l'attribution: \"" + ((Attribution)listViewAttribution.SelectedItem).PrenomPerso + " " + ((Attribution)listViewAttribution.SelectedItem).NomPerso + " -> " + ((Attribution)listViewAttribution.SelectedItem).NomMat + "\" ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (((Attribution)listViewAttribution.SelectedItem).Delete())
                        ApplicationData.LesAttributions.Remove((Attribution)listViewAttribution.SelectedItem);
                }
                foreach (Materiel lesMateriels in ApplicationData.LesMateriels)
                    if (lesMateriels.Id == ((Materiel)listViewMateriel.SelectedItem).Id)
                        lesMateriels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdMateriel == lesMateriels.Id));
                listViewAttribution.DataContext = listViewMateriel.SelectedItem;
                listViewAttribution.ItemsSource = ((Materiel)listViewMateriel.SelectedItem).LesAttributions;
            }
        }





        private void MenuModificationMateriel(object sender, RoutedEventArgs e)
        {
            if (listViewMateriel.SelectedItem != null)
            {
                pageModif = new Modification((Materiel)listViewMateriel.SelectedItem);
                pageModif.Show();
            }
        }
        private void MenuSuppressionMateriel(object sender, RoutedEventArgs e)
        {
            if (listViewMateriel.SelectedItem != null)
            {

                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer \"" + ((Materiel)listViewMateriel.SelectedItem).Nom + "\" ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (((Materiel)listViewMateriel.SelectedItem).Delete())
                        ApplicationData.LesMateriels.Remove((Materiel)listViewMateriel.SelectedItem);
                }
                foreach (CategorieMateriel lesCategories in ApplicationData.LesCategories)
                    if (lesCategories.Id == ((CategorieMateriel)listViewCategorie.SelectedItem).Id)
                        lesCategories.LesMateriels = new ObservableCollection<Materiel>(ApplicationData.LesMateriels.ToList().FindAll(g => g.IdCategorie == lesCategories.Id));
                listViewMateriel.DataContext = listViewCategorie.SelectedItem;
                listViewMateriel.ItemsSource = ((CategorieMateriel)listViewCategorie.SelectedItem).LesMateriels;
            }
        }






        private void MenuModificationCategorie(object sender, RoutedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {
                pageModif = new ModifCategorie((CategorieMateriel)listViewCategorie.SelectedItem);
                pageModif.Show();
            }
        }
        private void MenuSuppressionCategorie(object sender, RoutedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {

                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer \"" + ((CategorieMateriel)listViewCategorie.SelectedItem).Nom + "\" ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (((CategorieMateriel)listViewCategorie.SelectedItem).Delete())
                        ApplicationData.LesCategories.Remove((CategorieMateriel)listViewCategorie.SelectedItem);

                }
            }
        }





        private void btAjouterPersonnel_Click(object sender, RoutedEventArgs e)
        {
            pageAjout = new AjoutPersonnel();
            pageAjout.Show();
        }

        private void btAjouterAttribution_Click(object sender, RoutedEventArgs e)
        {
            Materiel m = new Materiel();
            Personnel p = new Personnel();
            if (listViewMateriel.SelectedItem != null)
                m = (Materiel)listViewMateriel.SelectedItem;
            if (listViewPersonnel.SelectedItem != null)
                p = (Personnel)listViewPersonnel.SelectedItem;
            pageAjout = new AjoutAttribution(m, p, this);
            pageAjout.Show();
        }

        private void btAjouterMateriel_Click(object sender, RoutedEventArgs e)
        {
            CategorieMateriel c = new CategorieMateriel();
            if (listViewCategorie.SelectedItem != null)
                c = (CategorieMateriel)listViewCategorie.SelectedItem;
            pageAjout = new AjoutMateriel(c, this);
            pageAjout.Show();
        }

        private void btAjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            pageAjout = new AjoutCategorie();
            pageAjout.Show();
        }

        private void btAide_Click(object sender, RoutedEventArgs e)
        {
            pageAide = new Aide();
            pageAide.Show();
        }
    }
}