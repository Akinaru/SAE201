using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SAE201.Ressources
{
    // File:    Attribution.cs 

    // Author:  martmate 

    // Created: mercredi 7 juin 2023 10:49:52 

    // Purpose: Definition of Class Attribution 

 
    public class Attribution : Crud<Attribution>
    {

        private int idMateriel;
        private int idPersonnel;
        private DateTime date;
        private string commentaire;
        private string prenomPerso;
        private string nomPerso;
        private string nomMat;

        public int IdMateriel
        {
            get
            {
                return idMateriel;
            }

            set
            {
                idMateriel = value;
            }
        }

        public int IdPersonnel
        {
            get
            {
                return idPersonnel;
            }

            set
            {
                idPersonnel = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Commentaire
        {
            get
            {
                return commentaire;
            }

            set
            {
                commentaire = value;
            }
        }

        public string PrenomPerso
        {
            get
            {
                return prenomPerso;
            }

            set
            {
                prenomPerso = value;
            }
        }

        public string NomPerso
        {
            get
            {
                return nomPerso;
            }

            set
            {
                nomPerso = value;
            }
        }

        public string NomMat
        {
            get
            {
                return nomMat;
            }

            set
            {
                nomMat = value;
            }
        }

        public bool Create()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"INSERT INTO attribution (date,commentaire,idpersonnel,idmateriel) VALUES ('{this.Date}','{this.Commentaire}','{this.IdPersonnel}','{this.IdMateriel}');";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                ApplicationData.LesAttributions.Add(this);
                return true;
            }
            return false;
        }



        public bool Read()
        {
            throw new NotImplementedException();
        }



        public bool Update()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"UPDATE attribution SET date = '{this.Date}', commentaire = '{this.Commentaire}' WHERE idpersonnel = {this.IdPersonnel} and idmateriel = {this.IdMateriel};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }



        public bool Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"DELETE FROM attribution WHERE idpersonnel = {this.IdPersonnel} and idmateriel = {this.IdMateriel};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                return true;
            }
            return false;
        }



        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributions = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, idmateriel, date, commentaire, p.nom, p.prenom, m.nom as \"NomMat\" from attribution a join personnel p on p.id = a.idpersonnel join materiel m on a.idmateriel = m.id order by idcategorie;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution e = new Attribution(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)row["date"], (String)row["commentaire"], (String)row["prenom"], (String)row["nom"], (String)row["NomMat"]);
                    lesAttributions.Add(e);
                }
            }
            return lesAttributions;
        }



        public Attribution(int idPersonnel, int idMateriel, DateTime date, string commentaire, string prenomPerso, string nomPerso, string nomMat)
        {
            this.IdPersonnel = idPersonnel;
            this.IdMateriel = idMateriel;
            this.Date = date;
            this.Commentaire = commentaire;
            this.PrenomPerso = prenomPerso;
            this.NomPerso = nomPerso;
            this.NomMat = nomMat;
        }



        public Attribution()
        {
        }


    }
}
