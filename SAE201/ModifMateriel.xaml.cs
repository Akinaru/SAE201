using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour ModifMateriel.xaml
    /// </summary>
    public partial class ModifMateriel : Window
    {
        Materiel materiel;
        MainWindow fenetre;
        public ModifMateriel(Materiel mat, MainWindow fenetre)
        {
            InitializeComponent();
            materiel = mat;
            this.fenetre = fenetre;
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
