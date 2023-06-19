using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    public class CategorieMateriel : Crud<CategorieMateriel>
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

        //Cette fonction permet d'insérer la catégorie matériel dans la base de données
        //Renvoie true si l'insertion réussie, false sinon
        public bool Create()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"INSERT INTO categoriemateriel (nom) VALUES ('{this.Nom}');";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }



        public CategorieMateriel Read(int id)
        {
            throw new NotImplementedException();
        }


        //Cette fonction permet de mettre à jour la catégorie matériel dans la base de données
        //Renvoie true si la modification réussie, false sinon
        public bool Update()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"UPDATE categoriemateriel SET Nom = '{this.Nom}' WHERE Id = {this.Id};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }


        //Cette fonction permet de supprimer la catégorie matériel de la base de données
        //Renvoie true si la suppréssion réussie, false sinon
        public bool Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"DELETE FROM categoriemateriel WHERE id = {this.Id};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }

        //Cette fonction permet de récupérer l'id de la categorie materiel dans la base de donnée
        //Renvoie l'id
        public int GetId()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"select id from categoriemateriel where nom = '{this.Nom}';";
            DataTable datas = accesBD.GetData(requete);
            int id = 0;
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
        }


        public ObservableCollection<CategorieMateriel> FindAll()
        {
            ObservableCollection<CategorieMateriel> lesCategories = new ObservableCollection<CategorieMateriel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom from categoriemateriel order by id;";
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
