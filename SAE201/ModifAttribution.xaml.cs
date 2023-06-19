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
    /// Fenêtre pour modifier une attribution
    /// </summary>
    public partial class ModifAttribution : Window
    {
        Attribution attribution;
        Materiel materiel;
        Personnel personnel;
        MainWindow fenetre;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrib"></param>
        /// <param name="window">Pour pouvoir récupérer les listview,...</param>
        public ModifAttribution(Attribution attrib, MainWindow window)
        {
            InitializeComponent();
            tbCommentaire.Focus();
            attribution = attrib;
            fenetre = window;
            materiel = ApplicationData.LesMateriels.ToList().Find(g => g.Id == attribution.IdMateriel);
            personnel = ApplicationData.LesPersonnels.ToList().Find(p => p.Id == attribution.IdPersonnel);
            foreach (Materiel mat in ApplicationData.LesMateriels)
            {
                cbMateriel.Items.Add(mat);
                if (mat.Nom == materiel.Nom)
                {
                    cbMateriel.SelectedItem = mat;
                }
            }

            foreach (Personnel pers in ApplicationData.LesPersonnels)
            {
                cbPersonnel.Items.Add(pers);
                if (pers == personnel)
                {
                    cbPersonnel.SelectedItem = pers;
                }

            }
            tbCommentaire.Text = attribution.Commentaire;
            datePicker.SelectedDate = attribution.Date;
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {

            var index = ApplicationData.LesAttributions.ToList().FindIndex(c => c.IdPersonnel == personnel.Id && c.IdMateriel == materiel.Id);
            Personnel p = cbPersonnel.SelectedItem as Personnel;
            Materiel m = cbMateriel.SelectedItem as Materiel;
            ApplicationData.LesAttributions[index].Commentaire = tbCommentaire.Text;
            ApplicationData.LesAttributions[index].Date = (DateTime)datePicker.SelectedDate;
            ApplicationData.LesAttributions[index].PrenomPerso = p.Prenom;
            ApplicationData.LesAttributions[index].NomPerso = p.Nom;
            ApplicationData.LesAttributions[index].NomMat = m.Nom;
            fenetre.listViewAttribution.Items.Refresh();
            if (!attribution.Update())
                MessageBox.Show("La création a été refusée.", "Ajout Categorie", MessageBoxButton.OK, MessageBoxImage.Warning);

            this.Close();

        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
