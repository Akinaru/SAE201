﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    internal class Materiel
    {
        private int id;
        private string nom;
        private string codeBarre;
        private string refConstructeur;
        private int idCategorie;
        private ObservableCollection<Attribution> lesAttributions;

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



        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select id, nom, codebarre, refconstructeur, idcategorie from materiel ;";
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