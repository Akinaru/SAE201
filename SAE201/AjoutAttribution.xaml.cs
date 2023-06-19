using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour AjoutAttribution.xaml
    /// </summary>
    public partial class AjoutAttribution : Window
    {

        public MainWindow fenetre;

        public AjoutAttribution(Materiel materiel, Personnel personnel, MainWindow fenetre)
        {
            InitializeComponent();
            this.fenetre = fenetre;
            tbCommentaire.Focus();
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
            datePicker.SelectedDate = DateTime.Now;
        }



        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            if (cbMateriel.SelectedItem == null || cbPersonnel.SelectedItem == null || datePicker.SelectedDate == null || tbCommentaire.Text.Trim() == "")
            {
                if (tbCommentaire.Text.Trim() == "")
                {
                    tbCommentaire.BorderBrush = Brushes.Red;
                }
                else
                {
                    tbCommentaire.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
                }
                MessageBox.Show("L'un des champs est incorrect.", "Format", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
                Materiel m = new Materiel(0, (string)cbMateriel.SelectedItem, "", "", 0);
                Personnel p = new Personnel(0, ((Personnel)cbPersonnel.SelectedItem).Nom, ((Personnel)cbPersonnel.SelectedItem).Prenom, "");
                Personnel pFinal = p.Read(p.GetId());
                int idPersonnel = pFinal.Id;
                int idMateriel = m.GetId();

                Attribution a = new Attribution(idPersonnel, idMateriel, (DateTime)datePicker.SelectedDate, tbCommentaire.Text, pFinal.Prenom, pFinal.Nom, m.Nom);

                if (a.Create())
                {
                    ApplicationData.LesAttributions.Add(a);

                    foreach (Materiel lesMateriels in ApplicationData.LesMateriels)
                        if (lesMateriels.Id == idMateriel)
                            lesMateriels.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(g => g.IdMateriel == lesMateriels.Id));

                    foreach (Materiel unMat in ApplicationData.LesMateriels.ToList())
                        unMat.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(e => e.IdMateriel == unMat.Id));

                    foreach (Personnel unPerso in ApplicationData.LesPersonnels.ToList())
                        unPerso.LesAttributions = new ObservableCollection<Attribution>(ApplicationData.LesAttributions.ToList().FindAll(e => e.IdPersonnel == unPerso.Id));

                    ApplicationData.UpdateAttribution(fenetre);
                }
                else
                    MessageBox.Show("La création a été refusée.", "Ajout Materiel", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbCommentaire_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCommentaire.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C192F"));
        }
    }
}
