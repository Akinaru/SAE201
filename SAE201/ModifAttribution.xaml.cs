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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour ModifAttribution.xaml
    /// </summary>
    public partial class ModifAttribution : Window
    {
        Attribution attriTempo;
        public ModifAttribution(Attribution attribution)
        {
            InitializeComponent();
            attriTempo = new Attribution(attribution.IdPersonnel, attribution.IdMateriel, attribution.Date, attribution.Commentaire, attribution.PrenomPerso, attribution.NomPerso, attribution.NomMat);
            tbCommentaire.Focus();
            Materiel materiel = ApplicationData.LesMateriels.ToList().Find(g => g.Id == attribution.IdMateriel);
            Personnel personnel = ApplicationData.LesPersonnels.ToList().Find(p => p.Id == attribution.IdPersonnel);
            foreach (Materiel mat in ApplicationData.LesMateriels)
            {
                cbMateriel.Items.Add(mat.Nom);
                if (mat.Nom == materiel.Nom)
                    cbMateriel.SelectedItem = mat.Nom;
            }

            foreach (Personnel pers in ApplicationData.LesPersonnels)
            {
                cbPersonnel.Items.Add(pers);
                if (pers == personnel)
                    cbPersonnel.SelectedItem = pers;
            }
            tbCommentaire.Text = attribution.Commentaire;
            datePicker.SelectedDate = attribution.Date;
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
