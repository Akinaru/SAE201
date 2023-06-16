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
    /// Logique d'interaction pour AjoutMateriel.xaml
    /// </summary>
    public partial class AjoutMateriel : Window
    {
        public AjoutMateriel()
        {
            InitializeComponent();
        }



        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            int idCategorie;

            Materiel p = new Materiel(0, tbNom.Text, tbCodeBarre.Text, tbRefConstructeur.Text);

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
