using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace wk6_AppDev_RB
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        class Chauffeur
        {
            public int Personeelsnummer { get; set; }
            public string Naam { get; set; }

            public Chauffeur(string Naam)
            {

            }
        }

        class CarRent
        {
            public List<Chauffeur> chauffeurs = new List<Chauffeur>();
            public List<Auto> autos = new List<Auto>();

            public string Naam { get; set; }

            public bool Verhuur(Auto auto, DateTime datum) { return true; }
            public bool Verhuur(Chauffeur chauffeur, DateTime datum){return true;}
            public bool Retourneer(Auto auto) { return true; }
            public bool Retournee(Chauffeur chauffeur) { return true; }
        }

        class Auto
        {
            public string Kenteken { get; set; }
            public string Model { get; set; }
            public bool Inzetbaar { get; set; }

            public Auto(string kenteken, string model) { }

        }

        class Standaard : Auto
        {
            public bool TrekhaakAanwezig { get; set; }

            public Standaard(string kenteken, string model, bool trekhaakAanwezig) :base(kenteken, model) { }


        }

        class Limousine : Auto
        {
            public bool MinibarAanwezig { get; set; }

            public Limousine(string kenteken, string model, bool minibarAanwezig) : base(kenteken, model) { }
        
        }

        class FourWD : Auto
        {
            public FourWD(string kenteken, string model) : base(kenteken, model) { }

        }

        class Vrachtwagen : Auto
        {
            public int Laadvermogen { get; set; }

            public Vrachtwagen(string kenteken, string model, int laadvermogen) : base(kenteken, model) { }
        }

    }
}
