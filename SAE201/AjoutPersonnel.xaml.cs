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
            tbPrenom.Focus();
        }


        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text.Trim() == "" || tbNom.Text == "" || tbPrenom.Text == "")
            {
                
                MessageBoxResult result = MessageBox.Show("Champs nom et prenom obligatoires", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Personnel p = new Personnel(0, tbNom.Text, tbPrenom.Text, tbEmail.Text);

                if (p.Create())
                {
                    Personnel pFinal = new Personnel(p.GetId(), p.Nom, p.Prenom, p.Email);
                    ApplicationData.LesPersonnels.Add(pFinal);

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
