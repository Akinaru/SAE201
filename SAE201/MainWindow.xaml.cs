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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Window pageajout;
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
                pageModif = new Modification((Personnel)listViewPersonnel.SelectedItem, this);
                pageModif.Show();
            }
        }

        private void MenuSuppressionPersonnel(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}