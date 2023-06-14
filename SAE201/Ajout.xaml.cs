using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class Ajout : Window
    {
        
        public Ajout(Object obj, MainWindow mainWindow)
        {
            InitializeComponent();
            if (obj is Personnel)
            {
                ObservableCollection<Personnel> listePerso = new ObservableCollection<Personnel>();
                listePerso.Add(obj as Personnel);
                dataGrid.DataContext = mainWindow.applicationData.LesPersonnels;
                dataGrid.ItemsSource = listePerso;
            }
        }
    }
}
