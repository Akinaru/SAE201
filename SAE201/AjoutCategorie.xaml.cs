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
    /// Logique d'interaction pour AjoutCategorie.xaml
    /// </summary>
    public partial class AjoutCategorie : Window
    {
        public AjoutCategorie()
        {
            InitializeComponent();
            tbNom.Focus();
        }



        private void btCreer_Click(object sender, RoutedEventArgs e)
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

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
