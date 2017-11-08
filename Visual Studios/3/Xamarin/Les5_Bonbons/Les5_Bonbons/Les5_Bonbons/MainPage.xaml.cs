using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;    

namespace Les5_Bonbons
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private ObservableCollection<Persoon> _lijstBonBons = new ObservableCollection<Persoon>();
        public ObservableCollection<Persoon> LijstBonbons
        {
            get { return _lijstBonBons; }
            set { _lijstBonBons = value; base.OnPropertyChanged(); }
        }


        private ObservableCollection<Persoon> bonbons = new ObservableCollection<Persoon>();
        protected override void OnAppearing()
        {
            base.OnAppearing();

            bonbons.Add(new Persoon("B01", "Kaarslicht Extase", "Puur", "Cashew", "MokkacrÃ¨me", "Cashew in mokkacrÃ¨me met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B02", "Butterscotch Bosbes", "Butterscotch", "Geen", "Bosbes", "Bosbes met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B03", "Marsepeinen Eikeblad", "Butterscotch", "Geen", "Marsepein", "Marsepein in de vorm van een groot eikeblad met een butterscotch-chocolade steel."));
            bonbons.Add(new Persoon("B04", "Butterscotch Aardbei", "Butterscotch", "Geen", "Aardbei", "Aardbei met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B05", "Butterscotch Framboos", "Butterscotch", "Geen", "Framboos", "Framboos met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B06", "Butterscotch Marmelade", "Butterscotch", "Geen", "Marmelade", "Marmelade met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B07", "Butterscotch Kers", "Butterscotch", "Geen", "Kers, heel", "Kers met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("B08", "Hazelnoot Bitter", "Butterscotch", "Hazelnoot", "Geen", "Hazelnoot met een laag butterscotch-chocolade."));
            bonbons.Add(new Persoon("F01", "Walnoot Mokka Toffee", "Toffee", "Walnoot", "MokkacrÃ¨me", "Zoete crÃ¨mige mokka en walnoot."));
            bonbons.Add(new Persoon("F02", "Pistache Mokka Toffee", "Toffee", "Pistache", "MokkacrÃ¨me", "Zoete crÃ¨mige mokka en pistache."));
            bonbons.Add(new Persoon("M01", "Zoete aardbei", "Melk", "Geen", "Aardbei", "Aardbei met een laag zoete melkchocolade."));
            bonbons.Add(new Persoon("M02", "Macadamia Perfect", "Melk", "Macadamia", "Geen", "Hele macadamia-noten met een laag melkchocolade."));
            bonbons.Add(new Persoon("M03", "Pistache Perfect", "Melk", "Pistache", "Geen", "Een aantal pistache-noten met een laag melkchocolade."));
            bonbons.Add(new Persoon("M04", "Pinda Delight", "Melk", "Geen", "PindacrÃ¨me", "Zachte pindacrÃ¨me met een laag melkchocolade."));
            bonbons.Add(new Persoon("M05", "Marsepeinen Vink", "Melk", "Geen", "Marsepein", "Marsepein in de vorm van een vink, met een pistache-noot als snavel, met een laag melkchocolade."));
            bonbons.Add(new Persoon("M06", "Verliefd Hart", "Melk", "Geen", "KersecrÃ¨me", "Melkchocolade in de vorm van een hart, met een vulling van zoete kersecrÃ¨me."));
            bonbons.Add(new Persoon("M07", "Appel Amore", "Melk", "Amandel", "Geen", "CrÃ¨mige melkchocolade in de vorm van een appel, met bladeren van amandel."));
            bonbons.Add(new Persoon("M08", "Marsepeinen esdoornblad", "Melk", "Geen", "Marsepein", "Marsepein in de vorm van een esdoornblad met een steel van melkchocolade."));
            bonbons.Add(new Persoon("M09", "Zoete framboos", "Melk", "Geen", "Framboos", "Framboos met een zoete laag melkchocolade."));
            bonbons.Add(new Persoon("M10", "Vergeet-Me-Niet", "Melk", "Geen", "Bosbes", "Melkchocolade met een vulling van bosbes, die u niet snel zult vergeten, in de vorm van een vergeet-mij-nietje."));
            bonbons.Add(new Persoon("M11", "Zoete Kers", "Melk", "Geen", "Kers, heel", "Kers met een zoete laag melkchocolade."));
            bonbons.Add(new Persoon("M12", "Zoete Bosbes", "Melk", "Geen", "Bosbes", "Bosbessen met een zoete laag melkchocolade."));
            bonbons.Add(new Persoon("M13", "Zoete Marmelade", "Melk", "Geen", "Marmalade", "Marmelade met een zoete laag melkchocolade."));
            bonbons.Add(new Persoon("M14", "Hazelnoot Kers", "Melk", "Hazelnoot", "KersecrÃ¨me", "Exclusieve hazelnoot met een laag kersecrÃ¨me en melkchocolade."));
            bonbons.Add(new Persoon("M15", "Tropische Palm", "Melk", "Geen", "Kokos", "Palm van melkchocolade met een vulling van kokos."));
            bonbons.Add(new Persoon("M16", "Marsepeinverrassing", "Melk", "Geen", "Marsepein", "Marsepein in de vorm van een amandel met melkchocolade, met de tekst \"MMmmm.\""));
            bonbons.Add(new Persoon("M17", "Hazelnoot Amaretto", "Melk", "Hazelnoot", "Amaretto", "Klassieke hazelnoot en amaretto omringd met melkchocolade."));
            bonbons.Add(new Persoon("M18", "Hazelnoot Mokka", "Melk", "Hazelnoot", "MokkacrÃ¨me", "Klassieke hazelnoot- en mokkacrÃ¨me met een laag melkchocolade."));
            bonbons.Add(new Persoon("P01", "Amandel Perfect", "Puur", "Amandel", "Geen", "Hele amandel met een laag pure chocolade."));
            bonbons.Add(new Persoon("P02", "Hart op een Voetstuk", "Puur", "Geen", "KersecrÃ¨me", "Pure chocolade gevuld met kersecrÃ¨me."));
            bonbons.Add(new Persoon("P03", "Cashew Perfect", "Puur", "Cashew", "Geen", "Grote cashewnoot met een laag pure chocolade."));
            bonbons.Add(new Persoon("P04", "Amandelverrassing", "Puur", "Amandel", "Amaretto", "Amandel met amaretto."));
            bonbons.Add(new Persoon("P06", "Hazelnoot Perfect", "Puur", "Hazelnoot", "Geen", "Hele hazelnoot met een laag pure chocolade."));
            bonbons.Add(new Persoon("P07", "Klassieke Kers", "Puur", "Geen", "Kers, heel", "Hele kers met een laag pure chocolade."));
            bonbons.Add(new Persoon("P08", "Chocolade Kiwi", "Puur", "Para", "Geen", "Kiwi met een laag pure chocolade."));
            bonbons.Add(new Persoon("P09", "Madeliefje", "Puur", "Geen", "Geen", "Heerlijke pure chocolade in de vorm van een madeliefje."));
            bonbons.Add(new Persoon("P11", "Marsepeinverrassing", "Puur", "Geen", "Marsepein", "Heerlijke marsepein met een laag pure chocolade."));
            bonbons.Add(new Persoon("W01", "Marsepeinen Zwaluw", "Wit", "Geen", "Marsepein", "Marsepein in de vorm van een zwaluw, met vleugels van witte chocolade."));
            bonbons.Add(new Persoon("W02", "Als een Lelie", "Wit", "Geen", "Geen", "Witte chocolade, elegant gevormd als een lelie."));
            bonbons.Add(new Persoon("W03", "Gebroken Hart", "Wit", "Pecan", "Geen", "Twee halve pecannoten met een laag witte chocolade, die een gebroken hart voorstellen."));
            bonbons.Add(new Persoon("W06", "Para Perfect", "Wit", "Para", "Geen", "Een hele paranoot met een laag witte chocolade."));

            LijstBonbons = bonbons;
        }

        void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {

            }
        }
    }
}
