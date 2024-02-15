using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace VorbereitungsProjektCampus02.Models
{
    internal class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int ProductId { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Produktbezeichnung;

        public string Produktbezeichnung
        {
            get { return _Produktbezeichnung; }
            set { 
                _Produktbezeichnung = value;
                OnPropertyChanged("Produktbezeichnung");
            }
        }

        private string _Kategorie;

        public string Kategorie
        {
            get { return _Kategorie; }
            set { _Kategorie = value; }
        }

        private double _Preis;

        public double Preis
        {
            get { return _Preis; }
            set { 
                _Preis = value;
                OnPropertyChanged("Preis");
            }
        }

        private bool _Aktiv;

        public bool Aktiv
        {
            get { return _Aktiv; }
            set { _Aktiv = value; }
        }

        private string _Bild;

        public string Bild
        {
            get { return _Bild; }
            set { _Bild = value;
                OnPropertyChanged("Bild");
            }
        }

        public decimal Gewicht { get; set; }

        public decimal Size { get; set; }

    }
      
    
}
