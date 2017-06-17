using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Owl_learn_Blokboek5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ToevoegPlanningToets : Page
    {
        //VARIABELEN
        public string userid;
        public string leerlingid;

        //STRUCTS
        struct Vak
        {
            public string ID { get; set; }
            public string VakNaam { get; set; }
        }
        struct Lesonderwerp
        {
            public string ID { get; set; }
            public string LONaam { get; set; }
        }

        //LISTS
        List<Vak> lstVakken = new List<Vak>();
        List<Lesonderwerp> lstLesonderwerp = new List<Lesonderwerp>();

        public ToevoegPlanningToets()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            leerlingid = parameters.selectedAccountID;

            getVakken();
        }

        public async void getVakken()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getVakken = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getVakken.php");
            // gebruik eventueel PostAsync
            getVakken.EnsureSuccessStatusCode();

            string Vakken = null;
            Vakken = await getVakken.Content.ReadAsStringAsync();

            string[] items = Vakken.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstVakken.Add(new Vak() { VakNaam = info[0], ID = info[1] });
                }

            }
            cbVak.ItemsSource = lstVakken;
        }
        public async void getLesonderwerp(string selectedVakID)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getLesonderwerp = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getLesonderwerp.php?vakID=" + selectedVakID);
            // gebruik eventueel PostAsync
            getLesonderwerp.EnsureSuccessStatusCode();

            string Lesonderwerpen = null;
            Lesonderwerpen = await getLesonderwerp.Content.ReadAsStringAsync();

            string[] items = Lesonderwerpen.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstLesonderwerp.Add(new Lesonderwerp() { LONaam = info[0], ID = info[1] });
                }

            }
            cbLO.ItemsSource = lstLesonderwerp;
        }

        private async void SaveNewPlanning(string datum, string vakid, string loid)
        {
            HttpClient connect1 = new HttpClient();
            HttpResponseMessage savePlanning = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/saveNewToetsPlanning.php?uID=" + leerlingid + "&vID=" + vakid + "&datum=" + datum + "&loid=" + loid);
            //gebruik eventueel PostAsync
            savePlanning.EnsureSuccessStatusCode();

            string resultaat = await savePlanning.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van de nieuwe les planning", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De planning is succesvol opgeslagen, u wordt nu teruggestuurd naar de vorige pagina.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;

                this.Frame.Navigate(typeof(PlanningToets), parameters);
            }
        }

        private void cbVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedVakID = cbVak.SelectedValue.ToString();

            //Leeg de comboboxen
            cbLO.ItemsSource = null;

            //Leeg de lists
            lstLesonderwerp.Clear();

            getLesonderwerp(selectedVakID);
        }

        private async void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date;

            if (cbVak.SelectedIndex == -1 || cbLO.SelectedIndex == -1)
            {

                var dialog = new MessageDialog("Zorg ervoor dat u een vak en lesonderwerp kiest voordat u de planning opslaat", "Foutmelding");
                await dialog.ShowAsync();
            }
            else if (dpDatum == null)
            {
                var dialog = new MessageDialog("Vergeet niet om een datum te prikken voor de planning", "Foutmelding");
                await dialog.ShowAsync();
            }
            else if (dpDatum != null)
            {
                date = dpDatum.Date.DateTime;
                string s = date.Value.ToString("yyyy-MM-dd");
                string selectedLOID = ((Lesonderwerp)(cbLO.SelectedItem)).ID;
                string selectedVakID = ((Vak)(cbVak.SelectedItem)).ID;

                SaveNewPlanning(s, selectedVakID, selectedLOID);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(PlanningToets), parameters);
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
