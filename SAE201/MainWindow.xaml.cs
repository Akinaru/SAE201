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
                lbSelection.Content = ((Materiel)listViewMateriel.SelectedItem).ToString();
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
            listViewAttribution.ItemsSource = applicationData.LesAttributions;
            lbSelection.Content = "";
        }

        private void MenuModificationPersonnel(object sender, RoutedEventArgs e)
        {
            if(listViewPersonnel.SelectedItem != null)
            {
                pageModif = new Modification((Personnel)listViewPersonnel.SelectedItem);
                pageModif.Owner = this;
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
                    CollectionViewSource.GetDefaultView(listViewPersonnel.ItemsSource).Refresh();

                    MessageBox.Show("Bien supprimé", "Suppression", MessageBoxButton.OK);
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

                    MessageBox.Show("Bien supprimé", "Suppression", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
                }
            }
        }

        private void MenuModificationMateriel(object sender, RoutedEventArgs e)
        {
        }
        private void MenuSuppressionMateriel(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer ce matériel : ", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ((Attribution)listViewAttribution.SelectedItem).Delete();

                    MessageBox.Show("Bien supprimé", "Suppression", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Operation annulée", "Annulation", MessageBoxButton.OK);
                }
            }
        }

        private void MenuModificationCategorie(object sender, RoutedEventArgs e)
        {
        }
        private void MenuSuppressionCategorie(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e) // AJOUT PERSONNEL
        {
            pageAjout = new Ajout();
            pageAjout.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // AJOUT ATTRIBUTION
        {
            pageAjout = new Ajout();
            pageAjout.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // AJOUT MATERIEL
        {
            pageAjout = new Ajout();
            pageAjout.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // AJOUT CATEGORIE
        {
            pageAjout = new Ajout();
            pageAjout.Show();
        }
    }
}