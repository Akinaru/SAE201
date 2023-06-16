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
        private Window pageModif;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listViewMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewMateriel.SelectedItem != null)
            {
                listViewAttribution.DataContext = listViewMateriel.SelectedItem;
                listViewAttribution.ItemsSource = ((Materiel)listViewMateriel.SelectedItem).LesAttributions;
                
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

        private void MenuModificationPersonnel(object sender, RoutedEventArgs e)
        {
            if(listViewPersonnel.SelectedItem != null)
            {
                pageModif = new Modification((Personnel)listViewPersonnel.SelectedItem);
                pageModif.Show();
            }
        }

        private void MenuSuppressionPersonnel(object sender, RoutedEventArgs e)
        {
            if (listViewPersonnel.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer \"" + ((Personnel)listViewPersonnel.SelectedItem).Nom + " " + ((Personnel)listViewPersonnel.SelectedItem).Prenom + "\"", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ((Personnel)listViewPersonnel.SelectedItem).Delete();

                    ApplicationData.LesPersonnels = new Personnel().FindAll();
                    listViewPersonnel.ItemsSource = ApplicationData.LesPersonnels;

                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
                }
            }
        }

        private void MenuModificationAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                pageModif = new Modification((Attribution)listViewAttribution.SelectedItem);
                pageModif.Show();
            }
        }
        private void MenuSuppressionAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer cette attribution : \n" + ((Attribution)listViewAttribution.SelectedItem).NomPerso + " " + ((Attribution)listViewAttribution.SelectedItem).PrenomPerso + "\n" + ((Attribution)listViewAttribution.SelectedItem).NomMat + "\n" + ((Attribution)listViewAttribution.SelectedItem).Date.Date, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ((Attribution)listViewAttribution.SelectedItem).Delete();


                    ApplicationData.LesAttributions = new Attribution().FindAll();

                    foreach (Materiel unMat in ApplicationData.LesMateriels.ToList())
                        unMat.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(e => e.IdMateriel == unMat.Id));

                    listViewAttribution.DataContext = listViewMateriel.SelectedItem;
                    listViewAttribution.ItemsSource = ((Materiel)listViewMateriel.SelectedItem).LesAttributions;

                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
                }
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
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer ce matériel : " + ((Materiel)listViewMateriel.SelectedItem).Nom, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ((Materiel)listViewMateriel.SelectedItem).Delete();


                    ApplicationData.LesMateriels = new Materiel().FindAll();
                    
                    foreach (CategorieMateriel uneCat in ApplicationData.LesCategories.ToList())
                        uneCat.LesMateriels = new ObservableCollection<Materiel>(ApplicationData.LesMateriels.ToList().FindAll(g => g.IdCategorie == uneCat.Id));

                    listViewMateriel.DataContext = listViewCategorie.SelectedItem;
                    listViewMateriel.ItemsSource = ((CategorieMateriel)listViewCategorie.SelectedItem).LesMateriels;


                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
                }
            }
        }

        private void MenuModificationCategorie(object sender, RoutedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {
                pageModif = new Modification((CategorieMateriel)listViewCategorie.SelectedItem);
                pageModif.Show();
            }
        }
        private void MenuSuppressionCategorie(object sender, RoutedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {
                CategorieMateriel cat = ((CategorieMateriel)listViewCategorie.SelectedItem);
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer cette catégorie de matériel : " + cat.Nom, "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show(ApplicationData.LesCategories.Contains(cat) +" ");
                    cat.Delete();

                    ApplicationData.LesCategories = new CategorieMateriel().FindAll();
                    listViewCategorie.ItemsSource = ApplicationData.LesCategories;

                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
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

        }

        private void btAjouterMateriel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}