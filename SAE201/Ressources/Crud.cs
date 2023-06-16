using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources
{
    public interface Crud<T>
    {

        bool Create();


        T Read(int id);


        bool Update();


        bool Delete();


        ObservableCollection<T> FindAll();

    }
}
