using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorbereitungsProjektCampus02.Models
{
    internal class ProduktViewModel: INotifyPropertyChanged
    {
        private ProduktDBContext context = new ProduktDBContext();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Product> ObsProducts{ get; set; }

        public string StatusText1 { get; set; }
        public string StatusText2 { get; set; }
        public ProduktViewModel()
        {
            ObsProducts = new ObservableCollection<Product>();
            var myProductsLocalFromDB = context.Products.ToList();
            foreach (var product in myProductsLocalFromDB)
            {
                ObsProducts.Add(product);
            }

            Suchergebnis = new ObservableCollection<Product>();
            ChangeStatustxt();

        }

        public int AddProduct(Product product)
        {
            context.Products.Add(product);
            ObsProducts.Add(product);
            context.SaveChanges();
            ChangeStatustxt();
            return product.ProductId;
        }

        private void ChangeStatustxt()
        {
            StatusText1 = "Momentan sind " + context.Products.ToList().Count.ToString() + " Produkte in der DB";
            NotifyPropertyChanged("StatusText1");
        }

        internal void RemoveProdukt(Product ausgewaehltesProdukt)
        {
            ObsProducts.Remove(ausgewaehltesProdukt);
            context.Products.Remove(ausgewaehltesProdukt);
            context.SaveChanges();
        }

        private Product _AusgewaehltesProdukt;

        public Product AusgewaehltesProdukt
        {
            get { return _AusgewaehltesProdukt; }
            set { _AusgewaehltesProdukt = value;
                NotifyPropertyChanged("AusgewaehltesProdukt");
            }
        }

        private Product _NeuesProdukt;

        public Product NeuesProdukt
        {
            get { return _NeuesProdukt; }
            set
            {
                _NeuesProdukt = value;
                NotifyPropertyChanged("NeuesProdukt");
            }
        }

        public ObservableCollection<Product> Suchergebnis { get; set; }

        private string _Suchbegriff;

        public string Suchbegriff
        {
            get { return _Suchbegriff; }
            set
            {
                _Suchbegriff = value;
                Suchergebnis.Clear();
                foreach (var item in ObsProducts)
                {
                    if (item.Produktbezeichnung.Contains(_Suchbegriff))
                    {
                        Suchergebnis.Add(item);
                    }
                }
            }
        }
    }
}
