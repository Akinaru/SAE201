﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    internal class Personnel : Crud<Personnel>
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



        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, prenom, email from personnel ;";
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
