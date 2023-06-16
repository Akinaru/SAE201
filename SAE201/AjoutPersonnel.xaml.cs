using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class AjoutPersonnel : Window
    {
        public AjoutPersonnel()
        {
            InitializeComponent();
            this.Title += "Personnel";
        }


        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir créer le personnel ?","Ajouter Personnel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Personnel p = new Personnel(0, tbNom.Text, tbPrenom.Text, tbEmail.Text);
                
                if (p.Create())
                {
                    ApplicationData.LesPersonnels = new Personnel().FindAll();

                }
                else
                   MessageBox.Show("La création a été refusée.", "Ajout Personnel", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
                

            }
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
