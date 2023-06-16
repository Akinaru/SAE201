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
        public Object actuel;

        public Modification(Personnel perso)
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
            
        }
        
        public Modification(Attribution attrib)
        {
            InitializeComponent();
            this.Title += "Attribution";
            dataGrid.AutoGenerateColumns = false;
            actuel = attrib;


            ObservableCollection<Attribution> listeAttribution = new ObservableCollection<Attribution>();
            listeAttribution.Add(attrib);

            DataGridTextColumn dateColumn = new DataGridTextColumn();
            dateColumn.Header = "Date";
            dateColumn.Binding = new Binding("Date");

            DataGridTextColumn commentaireColumn = new DataGridTextColumn();
            commentaireColumn.Header = "Commentaire";
            commentaireColumn.Binding = new Binding("Commentaire");

            dataGrid.Columns.Add(dateColumn);
            dataGrid.Columns.Add(commentaireColumn);
            dataGrid.ItemsSource = listeAttribution;
        }
        
        public Modification(Materiel materiel)
        {
            InitializeComponent();
            this.Title += "Materiel";
            dataGrid.AutoGenerateColumns = false;
            actuel = materiel;


            ObservableCollection<Materiel> listeMateriel = new ObservableCollection<Materiel>();
            listeMateriel.Add(materiel);

            DataGridTextColumn nomColumn = new DataGridTextColumn();
            nomColumn.Header = "Nom";
            nomColumn.Binding = new Binding("Nom");

            DataGridTextColumn codeBarreColumn = new DataGridTextColumn();
            codeBarreColumn.Header = "Code Barre";
            codeBarreColumn.Binding = new Binding("CodeBarre");

            DataGridTextColumn refConstructeurColumn = new DataGridTextColumn();
            refConstructeurColumn.Header = "Ref Constructeur";
            refConstructeurColumn.Binding = new Binding("RefConstructeur");


            dataGrid.Columns.Add(nomColumn);
            dataGrid.Columns.Add(codeBarreColumn);
            dataGrid.Columns.Add(refConstructeurColumn);
            dataGrid.ItemsSource = listeMateriel;
        }

        public Modification(CategorieMateriel materiel)
        {
            InitializeComponent();

            this.Title += "Categorie Materiel";
            dataGrid.AutoGenerateColumns = false;
            actuel = materiel;

            ObservableCollection<CategorieMateriel> listeCategorie = new ObservableCollection<CategorieMateriel>();
            listeCategorie.Add(materiel);

            DataGridTextColumn nomColumn = new DataGridTextColumn();
            nomColumn.Header = "Nom";
            nomColumn.Binding = new Binding("Nom");

            dataGrid.Columns.Add(nomColumn);
            dataGrid.ItemsSource = listeCategorie;
            
        }


        public Modification()
        {
            InitializeComponent();
        }


        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            
            if(actuel is Personnel)
            {
                if (((Personnel)actuel).Update())
                    MessageBox.Show("La modification a été validée.", "Modification Personnel", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                else
                    MessageBox.Show("La modification a été refusée.", "Modification Personnel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (actuel is Attribution)
            {
                if (((Attribution)actuel).Update())
                    MessageBox.Show("La modification a été validée.", "Modification Attribution", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                    MessageBox.Show("La modification a été refusée.", "Modification Attribution", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (actuel is Materiel)
            {
                if (((Materiel)actuel).Update())
                    MessageBox.Show("La modification a été validée.", "Modification Materiel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                    MessageBox.Show("La modification a été refusée.", "Modification Materiel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (actuel is CategorieMateriel)
            {
                if (((CategorieMateriel)actuel).Update())
                    MessageBox.Show("La modification a été validée.", "Modification Categorie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                    MessageBox.Show("La modification a été refusée.", "Modification Categorie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.Close();
            
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
