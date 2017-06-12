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
    public sealed partial class PlanningToets : Page
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

        public PlanningToets()
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
            HttpResponseMessage getPlanningen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getToetsPlanning.php?uID=" + selectedID);
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

        private void btVerwijder_Click(object sender, RoutedEventArgs e)
        {

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

                this.Frame.Navigate(typeof(ToevoegPlanningToets), parameters);
            }
        }
    }
}
