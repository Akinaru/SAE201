using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    public class Personnel : Crud<Personnel>
    {

        private int id;
        private string nom;
        private string prenom;
        private string email;

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

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public bool Create()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"INSERT INTO personnel (nom, prenom, email) VALUES ('{this.Nom}','{this.Prenom}','{this.Email}');";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }



        public Personnel Read(int id)
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"select nom,prenom,email from personnel where id = {id};";
            DataTable datas = accesBD.GetData(requete);
            Personnel perso = null;
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    perso = new Personnel(id, (string)row["nom"], (string)row["prenom"], (string)row["email"]);
                }
                
            }
            return perso;
        }



        public bool Update()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"UPDATE personnel SET Nom = '{this.Nom}', Prenom = '{this.Prenom}', Email = '{this.Email}' WHERE Id = {this.Id};";
            DataTable datas = accesBD.GetData(requete);
            if(datas != null)
            {
                return true;
            }
            return false;
        }



        public bool Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"DELETE from personnel WHERE id = '{this.Id}';";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }

        public int GetId()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"select id from personnel where nom = '{this.Nom}' and prenom = '{this.Prenom}';";
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



            public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, prenom, email from personnel order by id;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["id"].ToString()), (String)row["nom"], (String)row["prenom"], (String)row["email"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }

        public override string? ToString()
        {
            return this.Nom + " " + this.Prenom;
        }

        public Personnel()
        {

        }

        public Personnel(int id, string nom, string prenom, string email)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }
    }
}
