using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    internal class CategorieMateriel
    {

        private int id;
        private string nom;
        private ObservableCollection<Materiel> lesMateriels;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public ObservableCollection<Materiel> LesMateriels
        {
            get
            {
                return lesMateriels;
            }

            set
            {
                lesMateriels = value;
            }
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }



        public bool Read()
        {
            throw new NotImplementedException();
        }



        public bool Update()
        {
            throw new NotImplementedException();
        }



        public bool Delete()
        {
            throw new NotImplementedException();
        }



        public ObservableCollection<CategorieMateriel> FindAll()
        {
            ObservableCollection<CategorieMateriel> lesCategories = new ObservableCollection<CategorieMateriel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom from categoriemateriel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    CategorieMateriel e = new CategorieMateriel(int.Parse(row["id"].ToString()), (String)row["nom"]);
                    lesCategories.Add(e);
                }
            }
            return lesCategories;
        }

        public CategorieMateriel()
        {
        }
        public CategorieMateriel(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }
    }
}
