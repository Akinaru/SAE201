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
        private ObservableCollection<Attribution> lesAttributions;
        /// <summary>
        /// Getter et Setter de Id
        /// </summary>
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
        /// <summary>
        /// Getter et Setter de Nom
        /// </summary>
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
        /// <summary>
        /// Getter et Setter de Prenom
        /// </summary>
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
        /// <summary>
        /// Getter et Setter de Email
        /// </summary>
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
        /// <summary>
        /// Getter et Setter de LesAttributions
        /// </summary>
        public ObservableCollection<Attribution> LesAttributions
        {
            get
            {
                return lesAttributions;
            }

            set
            {
                lesAttributions = value;
            }
        }
        /// <summary>
        /// Cette fonction permet d'insérer le personnel dans la base de données
        /// Renvoie true si l'insertion réussie, false sinon
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de récuperer un personnel par rapport son id dans la base de données
        /// Renvoie le personnel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de mettre à jour le personnel dans la base de données
        /// Renvoie true si la modification réussie, false sinon
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de supprimer le personnel de la base de données
        /// Renvoie true si la suppréssion réussie, false sinon
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de récupérer l'id du personnel dans la base de donnée
        ///Renvoie l'id
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Cette méthode renvoie tous les personnel de la base de donnée
        /// Renvoie une liste de personnel
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// ToString de personnel
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return this.Nom + " " + this.Prenom;
        }

        /// <summary>
        /// Constructeur vide de personnel
        /// </summary>
        public Personnel()
        {

        }
        /// <summary>
        /// Constructeur de personnel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="email"></param>
        public Personnel(int id, string nom, string prenom, string email)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }
    }
}
