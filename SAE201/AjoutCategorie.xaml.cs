﻿using SAE201.Ressources;
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
    /// Fenêtre pour ajouter une catégorie
    /// </summary>
    public partial class AjoutCategorie : Window
    {
        /// <summary>
        /// Constructeur de la fenêtre ajout catégorie, activé lors du clic sur le bouton d'ajout de catégorie.
        /// </summary>
        public AjoutCategorie()
        {
            InitializeComponent();
            tbNom.Focus();
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
                CategorieMateriel p = new CategorieMateriel(0, tbNom.Text);

                if (p.Create())
                {
                    CategorieMateriel pFinal = new CategorieMateriel(p.GetId(), p.Nom);
                    ApplicationData.LesCategories.Add(pFinal);


                }
                else
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
