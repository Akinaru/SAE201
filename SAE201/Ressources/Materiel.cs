using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    public class Materiel : Crud<Materiel>
    {
        private int id;
        private string nom;
        private string codeBarre;
        private string refConstructeur;
        private int idCategorie;
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
        /// Getter et Setter de CodeBarre
        /// </summary>
        public string CodeBarre
        {
            get
            {
                return codeBarre;
            }

            set
            {
                codeBarre = value;
            }
        }
        /// <summary>
        /// Getter et Setter de RefConstructeur
        /// </summary>
        public string RefConstructeur
        {
            get
            {
                return refConstructeur;
            }

            set
            {
                refConstructeur = value;
            }
        }
        /// <summary>
        /// Getter et Setter de  IdCategorie
        /// </summary>
        public int IdCategorie
        {
            get
            {
                return idCategorie;
            }

            set
            {
                idCategorie = value;
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
        /// Cette fonction permet d'insérer le matériel dans la base de données
        /// Renvoie true si l'insertion réussie, false sinon
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            DataAccess accesBD = new DataAccess(); 
            string requete = $"INSERT INTO materiel (nom, codebarre, refconstructeur, idcategorie) VALUES ('{this.Nom}','{this.CodeBarre}','{this.RefConstructeur}','{this.IdCategorie}');";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Materiel Read(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette fonction permet de mettre à jour le matériel dans la base de données
        /// Renvoie true si la modification réussie, false sinon
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"UPDATE materiel SET Nom = '{this.Nom}', codebarre = '{this.CodeBarre}', refconstructeur = '{this.RefConstructeur}' WHERE Id = {this.Id};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cette fonction permet de supprimer le matériel de la base de données
        /// Renvoie true si la suppréssion réussie, false sinon
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"DELETE FROM materiel WHERE id = {this.Id};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cette fonction permet de récupérer l'id du matériel dans la base de donnée
        /// Renvoie l'id
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"select id from materiel where nom = '{this.Nom}';";
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

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, codebarre, refconstructeur, idcategorie from materiel order by id;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel e = new Materiel(int.Parse(row["id"].ToString()), (String)row["nom"], (String)row["codebarre"], (String)row["refconstructeur"], int.Parse(row["idcategorie"].ToString()));
                    lesMateriels.Add(e);
                }
            }
            return lesMateriels;
        }

        public override string? ToString()
        {
            return this.Nom;
        }

        public Materiel() { }
        public Materiel(int id, string nom, string codeBarre, string refConstructeur, int idCategorie)
        {
            this.Id = id;
            this.Nom = nom;
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConstructeur;
            this.IdCategorie = idCategorie;
        }
    }
}
