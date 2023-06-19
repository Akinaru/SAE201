using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    /// <summary>
    /// Interface CRUD (create, read, update, delete) et Findall.
    /// </summary>
    /// <typeparam name="T">Pour pouvoir passer en paramèrte n'importe quelle objet en paramètre (rendre le code générique)</typeparam>
    public interface Crud<T>
    {

        bool Create();


        T Read(int id);


        bool Update();


        bool Delete();


        ObservableCollection<T> FindAll();

    }
}
