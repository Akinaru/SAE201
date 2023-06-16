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

        }

    }
}
