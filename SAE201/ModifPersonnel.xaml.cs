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
    /// Logique d'interaction pour ModifPersonnel.xaml
    /// </summary>
    public partial class ModifPersonnel : Window
    {
        Personnel persoTempo;
        public ModifPersonnel(Personnel personnel)
        {
            InitializeComponent();
            persoTempo = new Personnel(personnel.Id, personnel.Nom, personnel.Prenom, personnel.Email);
            tbNom.Text = personnel.Nom;
            tbPrenom.Text = personnel.Prenom;
            tbEmail.Text = personnel.Email;
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
