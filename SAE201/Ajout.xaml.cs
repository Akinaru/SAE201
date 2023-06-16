using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public Object actuel;

        public Ajout()
        {
            InitializeComponent();
        }
        public Ajout(Personnel perso)
        {
            InitializeComponent();
            this.Title += "Personnel";
            dataGrid.AutoGenerateColumns = false;
            actuel = perso;
            

            ObservableCollection<Personnel> listePerso = new ObservableCollection<Personnel>();
            listePerso.Add(perso);

            DataGridTextColumn nomColumn = new DataGridTextColumn();
            nomColumn.Header = "Nom";
            nomColumn.Binding = new Binding("Nom");

            DataGridTextColumn prenomColumn = new DataGridTextColumn();
            prenomColumn.Header = "Prenom";
            prenomColumn.Binding = new Binding("Prenom");

            DataGridTextColumn emailColumn = new DataGridTextColumn();
            emailColumn.Header = "Email";
            emailColumn.Binding = new Binding("Email");

            dataGrid.Columns.Add(nomColumn);
            dataGrid.Columns.Add(prenomColumn);
            dataGrid.Columns.Add(emailColumn);

            dataGrid.ItemsSource = listePerso;
            dataGrid.SelectedIndex = 0;
        }

        public Ajout(CategorieMateriel categorie)
        {
            InitializeComponent();
            this.Title += "Categorie";
            dataGrid.AutoGenerateColumns = false;
            actuel = categorie;


            ObservableCollection<CategorieMateriel> listeCategorie = new ObservableCollection<CategorieMateriel>();
            listeCategorie.Add(categorie);

            DataGridTextColumn nomColumn = new DataGridTextColumn();
            nomColumn.Header = "Nom";
            nomColumn.Binding = new Binding("Nom");

            dataGrid.Columns.Add(nomColumn);

            dataGrid.ItemsSource = listeCategorie;
            dataGrid.SelectedIndex = 0;
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedIndex = 0;
            if(actuel is Personnel)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir créer le personnel ?","Ajouter Personnel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Personnel p = dataGrid.SelectedItem as Personnel;
                    if (p.Create())
                       MessageBox.Show("La création a été validée.", "Ajout Personnel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    else
                       MessageBox.Show("La création a été refusée.", "Ajout Personnel", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                    
                    ApplicationData.LesPersonnels.Add(p);

                }

            }

            if (actuel is CategorieMateriel)
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir créer la catégorie ?", "Ajouter Categorie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    CategorieMateriel p = dataGrid.SelectedItem as CategorieMateriel;
                    if (p.Create())
                        MessageBox.Show("La création a été validée.", "Ajout Categorie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    else
                        MessageBox.Show("La création a été refusée.", "Ajout Categorie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();

                    ApplicationData.LesCategories.Add(p);

                }

            }
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
