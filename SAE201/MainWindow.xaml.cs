﻿using SAE201.Ressources;
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
    /// Fenêtre principale du logiciel où tout ce passe, selection de catégorie, de personnel, ...
    /// </summary>
    public partial class MainWindow : Window
    {

        private Window pageAjout;
        private Window pageAide;
        private Window pageModif;
        /// <summary>
        /// Initialisation de la fenêtre, se lance lors du lancement de l'application
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ApplicationData.UpdateAttribution(this);
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
            //Si on selectionne un personnel
            if (listViewPersonnel.SelectedItem != null)
            {
                listViewAttribution.DataContext = listViewPersonnel.SelectedItem;
                listViewAttribution.ItemsSource = ((Personnel)listViewPersonnel.SelectedItem).LesAttributions;
            }
            else
            {
                listViewAttribution.ItemsSource = ApplicationData.LesAttributions;
            }
        }

        private void btResetSelecPersonnel_Click(object sender, RoutedEventArgs e)
        {
            listViewPersonnel.SelectedItem = null;
            //Si on selectionne un materiel
            if (listViewMateriel.SelectedItem != null)
            {
                listViewAttribution.DataContext = listViewMateriel.SelectedItem;
                listViewAttribution.ItemsSource = ((Materiel)listViewMateriel.SelectedItem).LesAttributions;
            }
            else
            {
                listViewAttribution.ItemsSource = ApplicationData.LesAttributions;
            }

        }

        private void MenuModificationPersonnel(object sender, RoutedEventArgs e)
        {
            if(listViewPersonnel.SelectedItem != null)
            {
                pageModif = new ModifPersonnel((Personnel)listViewPersonnel.SelectedItem, this);
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

                    //On change pour tous les Materiels la liste d'attribution en reprenant les bonnes valeurs.
                    foreach (Materiel lesMateriels in ApplicationData.LesMateriels)
                    {
                        lesMateriels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdMateriel == lesMateriels.Id));
                    }
                    //On change pour tous les Personnels la liste d'attribution en reprenant les bonnes valeurs.
                    foreach (Personnel lesPersonnels in ApplicationData.LesPersonnels)
                        lesPersonnels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdPersonnel == lesPersonnels.Id));

                    ApplicationData.UpdateAttribution(this);
                }
            }
        }

        private void MenuModificationAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                pageModif = new ModifAttribution((Attribution)listViewAttribution.SelectedItem, this);
                pageModif.Show();
            }
        }
        private void MenuSuppressionAttribution(object sender, RoutedEventArgs e)
        {
            if (listViewAttribution.SelectedItem != null)
            {
                Attribution a = new Attribution();
                //Affichage d'une fenetre de vérification
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer l'attribution: \"" + ((Attribution)listViewAttribution.SelectedItem).PrenomPerso + " " + ((Attribution)listViewAttribution.SelectedItem).NomPerso + " -> " + ((Attribution)listViewAttribution.SelectedItem).NomMat + "\" ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    //On essaye de supprimer l'objet et en meme temps on vérifie si l'action a bien été efféctuée.
                    if (((Attribution)listViewAttribution.SelectedItem).Delete())
                    {
                        a = (Attribution)listViewAttribution.SelectedItem;
                        //On supprime l'attribution de la liste.
                        ApplicationData.LesAttributions.Remove((Attribution)listViewAttribution.SelectedItem);
                    }
                }

                //On change pour tous les Materiels la liste d'attribution en reprenant les bonnes valeurs.
                foreach (Materiel lesMateriels in ApplicationData.LesMateriels)
                {
                    if (lesMateriels.Id == a.IdMateriel)
                        lesMateriels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdMateriel == lesMateriels.Id));
                }
                //On change pour tous les Personnels la liste d'attribution en reprenant les bonnes valeurs.
                foreach (Personnel lesPersonnels in ApplicationData.LesPersonnels)
                    if (lesPersonnels.Id == a.IdPersonnel)
                        lesPersonnels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdPersonnel == lesPersonnels.Id));

                ApplicationData.UpdateAttribution(this);
            }
        }





        private void MenuModificationMateriel(object sender, RoutedEventArgs e)
        {
            if (listViewMateriel.SelectedItem != null)
            {
                pageModif = new ModifMateriel((Materiel)listViewMateriel.SelectedItem, this);
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
                
                if(listViewCategorie.SelectedItem != null)
                {
                    foreach (CategorieMateriel lesCategories in ApplicationData.LesCategories)
                    {
                        if (lesCategories.Id == ((CategorieMateriel)listViewCategorie.SelectedItem).Id)
                        {
                            lesCategories.LesMateriels = new ObservableCollection<Materiel>(ApplicationData.LesMateriels.ToList().FindAll(g => g.IdCategorie == lesCategories.Id));
                        }
                    }
                }
                listViewMateriel.DataContext = listViewCategorie.SelectedItem;
                listViewMateriel.ItemsSource = ((CategorieMateriel)listViewCategorie.SelectedItem).LesMateriels;

                ApplicationData.UpdateAttribution(this);
            }
        }






        private void MenuModificationCategorie(object sender, RoutedEventArgs e)
        {
            if (listViewCategorie.SelectedItem != null)
            {
                pageModif = new ModifCategorie((CategorieMateriel)listViewCategorie.SelectedItem, this);
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
                    {
                        ApplicationData.LesCategories.Remove((CategorieMateriel)listViewCategorie.SelectedItem);

                        //On change pour tous les Materiels la liste d'attribution en reprenant les bonnes valeurs.
                        foreach (Materiel lesMateriels in ApplicationData.LesMateriels)
                            lesMateriels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdMateriel == lesMateriels.Id));
                    
                        //On change pour tous les Personnels la liste d'attribution en reprenant les bonnes valeurs.
                        foreach (Personnel lesPersonnels in ApplicationData.LesPersonnels)
                            lesPersonnels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdPersonnel == lesPersonnels.Id));

                        listViewMateriel.ItemsSource = null;

                        ApplicationData.UpdateAttribution(this);
                    }
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