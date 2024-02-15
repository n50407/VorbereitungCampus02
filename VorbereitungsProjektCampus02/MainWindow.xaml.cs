using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VorbereitungsProjektCampus02.Models;

namespace VorbereitungsProjektCampus02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProduktViewModel produktViewModel = new ProduktViewModel();
        public MainWindow()
        {
            InitializeComponent();
            Product myDummyProduct = new Product();
            myDummyProduct.Produktbezeichnung = "Laptop";
            myDummyProduct.Kategorie = "IT";
            myDummyProduct.Preis = 860;
            myDummyProduct.Aktiv = true;
            myDummyProduct.Bild = "Lap.png";
           // produktViewModel.AddProduct(myDummyProduct);
            this.DataContext= produktViewModel;
                
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddNewProductWindow addNewProductWindow = new AddNewProductWindow();
            produktViewModel.NeuesProdukt = new Product()
            {
                Produktbezeichnung = "Neues Produkt",
                Kategorie = "Neue Kategorie",
                Preis = 0,
                Aktiv = true,
                Bild = "Lap.png"
            };
            addNewProductWindow.DataContext = produktViewModel;
            addNewProductWindow.ShowDialog();
        

        }

        private void OpenSearchWindow_Click(object sender, RoutedEventArgs e)
        {
            SuchWindow suche = new SuchWindow();
            produktViewModel.Suchbegriff = "bitte Suchbegriff eingeben";
            suche.DataContext = produktViewModel;
            produktViewModel.Suchergebnis =new System.Collections.ObjectModel.ObservableCollection<Product>();

            suche.Show();
        }
    }
}
