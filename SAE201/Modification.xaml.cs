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
    /// Logique d'interaction pour Modification.xaml
    /// </summary>
    public partial class Modification : Window
    {
        public ObservableCollection<Personnel> LesPersonnels { get; set; }
        public Object actuel;

        public Modification(Personnel perso, MainWindow fenetre)
        {
            InitializeComponent();
            this.Title += "Personnel";
            dataGrid.AutoGenerateColumns = false;
            actuel = perso;

            // Personnel p = new Personnel(perso.Id, perso.Nom, perso.Prenom, perso.Email);
            //actuel = p;
            //LesPersonnels = p.FindAll();
            ObservableCollection<Personnel> listePerso = new ObservableCollection<Personnel>();
            listePerso.Add(perso);

            // Créer les colonnes
            DataGridTextColumn nomColumn = new DataGridTextColumn();
            nomColumn.Header = "Nom";
            nomColumn.Binding = new Binding("Nom");

            DataGridTextColumn prenomColumn = new DataGridTextColumn();
            prenomColumn.Header = "Prenom";
            prenomColumn.Binding = new Binding("Prenom");

            DataGridTextColumn emailColumn = new DataGridTextColumn();
            emailColumn.Header = "Email";
            emailColumn.Binding = new Binding("Email");

            // Ajouter les colonnes au DataGrid
            dataGrid.Columns.Add(nomColumn);
            dataGrid.Columns.Add(prenomColumn);
            dataGrid.Columns.Add(emailColumn);
            dataGrid.ItemsSource = listePerso;
        }



        public Modification()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            if(actuel is Personnel)
            {
                if (((Personnel)actuel).Update())
                {
                    MessageBox.Show("La modification a été validée.", "Modification", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La modification a été refusée.", "Modification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                }
            }

        }
    }
}
