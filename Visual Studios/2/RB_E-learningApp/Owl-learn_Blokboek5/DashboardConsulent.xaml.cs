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
    public sealed partial class DashboardConsulent : Page
    { 
        //VARIABELEN
        public string userid;

        //STRUCTS
        struct Vak
        {
            public string ID { get; set; }
            public string VakNaam { get; set; }
        }

        //LISTS
        List<Vak> lstVakken = new List<Vak>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            GetAllVakken();
        }

        private async void GetAllVakken()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getVakken = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getVakken.php");
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
            lbVakken.ItemsSource = lstVakken;
        }

        public DashboardConsulent()
        {
            this.InitializeComponent();
        }

        
        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btNieuw_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(ToevoegVak), parameters);
        }

        private async void btBewerk_Click(object sender, RoutedEventArgs e)
        {
            if (lbVakken.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een vak om deze te wijzigen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string sVakID = ((Vak)(lbVakken.SelectedItem)).ID;

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedVakID = sVakID;

                this.Frame.Navigate(typeof(BewerkVak), parameters);
            }
        }

        private async void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbVakken.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een vak om deze te kunnen verwijderen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string sVakID = ((Vak)(lbVakken.SelectedItem)).ID;

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedVakID = sVakID;

                this.Frame.Navigate(typeof(VerwijderVak), parameters);
            }
        }

        private void btToetsPlanning_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(PlanningToets), parameters);
        }

        private void btLesPlanning_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(PlanningLes), parameters);
        }
    }
}
