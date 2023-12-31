﻿using System;
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
        /// Getter et Setter de LesMateriels
        /// </summary>
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

        /// <summary>
        /// Cette fonction permet d'insérer la catégorie matériel dans la base de données
        /// Renvoie true si l'insertion réussie, false sinon
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CategorieMateriel Read(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette fonction permet de mettre à jour la catégorie matériel dans la base de données
        /// Renvoie true si la modification réussie, false sinon
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de supprimer la catégorie matériel de la base de données
        /// Renvoie true si la suppréssion réussie, false sinon
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette fonction permet de récupérer l'id de la categorie materiel dans la base de donnée
        /// Renvoie l'id
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cette méthode renvoie toutes les categories materiels de la base de donnée
        /// Renvoie une liste de categoriemateriel
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Constructeur vide de CategorieMateriel
        /// </summary>
        public CategorieMateriel()
        {
        }
        /// <summary>
        /// Constructuer de CategorieMateriel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public CategorieMateriel(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }
    }
}
