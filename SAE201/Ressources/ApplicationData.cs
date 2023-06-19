using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    internal class ApplicationData
    {

        public static ObservableCollection<Attribution> LesAttributions { get; set; }
        public static ObservableCollection<Personnel> LesPersonnels { get; set; }
        public static ObservableCollection<CategorieMateriel> LesCategories { get; set; }
        public static ObservableCollection<Materiel> LesMateriels { get; set; }

        public ApplicationData()
        {
            Attribution a = new Attribution();
            LesAttributions = a.FindAll();
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();
            CategorieMateriel c = new CategorieMateriel();
            LesCategories = c.FindAll();
            Materiel m = new Materiel();
            LesMateriels = m.FindAll();

            foreach (CategorieMateriel uneCat in LesCategories.ToList())
                uneCat.LesMateriels = new ObservableCollection<Materiel>(LesMateriels.ToList().FindAll(g => g.IdCategorie == uneCat.Id)); 

            foreach (Materiel unMat in LesMateriels.ToList())
                unMat.LesAttributions = new ObservableCollection<Attribution>(LesAttributions.ToList().FindAll(e => e.IdMateriel == unMat.Id));

            foreach (Personnel unPerso in LesPersonnels.ToList())
                unPerso.LesAttributions = new ObservableCollection<Attribution>(LesAttributions.ToList().FindAll(e => e.IdPersonnel == unPerso.Id));
        }

        internal static void UpdateAttribution(MainWindow fenetre)
        {
            ApplicationData.LesAttributions = new Attribution().FindAll();


            //Si on selectionne un personnel et un materiel
            if (fenetre.listViewPersonnel.SelectedItem != null && fenetre.listViewMateriel.SelectedItem != null)
            {
                ObservableCollection<Attribution> listeFinalCroise = new ObservableCollection<Attribution>();
                foreach (Attribution attri in ApplicationData.LesAttributions)
                {
                    if (attri.IdPersonnel == ((Personnel)fenetre.listViewPersonnel.SelectedItem).Id && attri.IdMateriel == ((Materiel)fenetre.listViewMateriel.SelectedItem).Id)
                    {
                        listeFinalCroise.Add(attri);

                    }
                }
                fenetre.listViewAttribution.ItemsSource = listeFinalCroise;
            }

            //Si on selectionne un personnel
            else if (fenetre.listViewPersonnel.SelectedItem != null && fenetre.listViewMateriel.SelectedItem == null)
            {
                fenetre.listViewAttribution.DataContext = fenetre.listViewPersonnel.SelectedItem;
                fenetre.listViewAttribution.ItemsSource = ((Personnel)fenetre.listViewPersonnel.SelectedItem).LesAttributions;
            }

            //Si on selectionne un materiel
            else if (fenetre.listViewPersonnel.SelectedItem == null && fenetre.listViewMateriel.SelectedItem != null)
            {
                fenetre.listViewAttribution.DataContext = fenetre.listViewMateriel.SelectedItem;
                fenetre.listViewAttribution.ItemsSource = ((Materiel)fenetre.listViewMateriel.SelectedItem).LesAttributions;
            }
            else
            {
                fenetre.listViewAttribution.ItemsSource = ApplicationData.LesAttributions;
            }
        }
    }
}
