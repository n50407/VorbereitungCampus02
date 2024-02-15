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
using System.Windows.Shapes;
using VorbereitungsProjektCampus02.Models;

namespace VorbereitungsProjektCampus02
{
    /// <summary>
    /// Interaction logic for AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {
        public AddNewProductWindow()
        {
            InitializeComponent();
        }

        private void AddNewProductAndClose(object sender, RoutedEventArgs e)
        {
            var vm = (ProduktViewModel)this.DataContext;

            /*
            var neuesProdukt = vm.NeuesProdukt;

            var neuesProduktClone=new Product()
            {
                Produktbezeichnung = neuesProdukt.Produktbezeichnung,
                Kategorie = neuesProdukt.Kategorie,
                Preis = neuesProdukt.Preis,
                Aktiv = neuesProdukt.Aktiv,
                Bild = neuesProdukt.Bild
            };

            vm.AddProduct(neuesProduktClone);
            */

            vm.AddProduct(vm.NeuesProdukt);

            this.Close();


        }
    }
}
