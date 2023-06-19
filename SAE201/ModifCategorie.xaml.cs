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
        CategorieMateriel cateTempo;
        public ModifCategorie(CategorieMateriel categorie)
        {
            InitializeComponent();
            cateTempo = new CategorieMateriel(categorie.Id, categorie.Nom);
            tbNom.Text = categorie.Nom;
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
