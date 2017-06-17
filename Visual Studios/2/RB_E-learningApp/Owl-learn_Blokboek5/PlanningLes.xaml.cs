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
    public sealed partial class PlanningLes : Page
    {
        //VARIABELEN
        public string userid;
        //STRUCTS

        struct Leerling
        {
            public string ID { get; set; }
            public string Naam { get; set; }
        }
        struct Planning
        {
            public string ID { get; set; }
            public string Naam { get; set; }
        }

        //LISTS
        List<Leerling> lstLeerlingen = new List<Leerling>();
        List<Planning> lstPlanningen = new List<Planning>();

        public PlanningLes()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;

            getLeerlingen();
        }

        private async void getLeerlingen()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getNamen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getLeerling.php?");
            // gebruik eventueel PostAsync
            getNamen.EnsureSuccessStatusCode();

            string result = null;
            result = await getNamen.Content.ReadAsStringAsync();

            string[] items = result.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstLeerlingen.Add(new Leerling() { ID = info[0], Naam = info[1] });
                }

            }
            lbLeerlingen.ItemsSource = lstLeerlingen;
        }

        private async void getPlanningen(string selectedID)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getPlanningen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getLesPlanning.php?uID=" + selectedID);
            // gebruik eventueel PostAsync
            getPlanningen.EnsureSuccessStatusCode();

            string result = null;
            result = await getPlanningen.Content.ReadAsStringAsync();

            string[] items = result.Split(']').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('^').ToArray();
                    lstPlanningen.Add(new Planning() { ID = info[0], Naam = info[1] });
                }

            }
            lbPlanning.ItemsSource = lstPlanningen;
        }

        private async void deletePlanning(string id)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage deleteVak = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/verwijderPlanningLes.php?pID=" + id);
            // gebruik eventueel PostAsync
            deleteVak.EnsureSuccessStatusCode();

            string resultaat = await deleteVak.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                var dialog1 = new MessageDialog("Er is iets missgegaan met het verwijderen van de planning", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De planning is succesvol verwijdert.", "Succes!");
                await dialog1.ShowAsync();

                //Haal het userid op
                string selectedUserID = ((Leerling)(lbLeerlingen.SelectedItem)).ID;

                //Leeg de les lijst
                lbPlanning.ItemsSource = null;

                //Leeg de lists;
                lstPlanningen.Clear();

                //Haal de nieuwe planningen op
                getPlanningen(selectedUserID);
            }
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardConsulent), parameters);
        }

        private async void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlanning.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een planning om deze te kunnen verwijderen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string selectedPlanning = ((Planning)(lbPlanning.SelectedItem)).ID;
                deletePlanning(selectedPlanning);
            }
        }

        private async void btNieuw_Click(object sender, RoutedEventArgs e)
        {
            if (lbLeerlingen.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een leerling om een nieuwe planning toe te voegen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string selectedLeerling = ((Leerling)(lbLeerlingen.SelectedItem)).ID;
                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedAccountID = selectedLeerling;

                this.Frame.Navigate(typeof(ToevoegPlanningLes), parameters);
            }
        }

        private void lbLeerlingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Haal het userid op
            string selectedUserID = ((Leerling)(lbLeerlingen.SelectedItem)).ID;
            
            //Leeg de les lijst
            lbPlanning.ItemsSource = null;

            //Leeg de lists;
            lstPlanningen.Clear();

            //Haal de nieuwe planningen op
            getPlanningen(selectedUserID);
            
        }
    }
}
