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
    public sealed partial class BewerkVak : Page
    {
        //VARIABELEN
        public string userid;
        public string vakid;
        public string selectedLOid;

        //STRUCTS
        struct Lesondewerp
        {
            public string ID { get; set; }
            public string LONaam { get; set; }
        }
        struct Les
        {
            public string ID { get; set; }
            public string LesNaam { get; set; }
        }

        //LISTS
        List<Lesondewerp> lstLO = new List<Lesondewerp>();
        List<Les> lstLes = new List<Les>();

        public BewerkVak()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            vakid = parameters.selectedVakID;

            getLesonderwerp();
        }

        public async void getLesonderwerp()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getLesonderwerp = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getLesonderwerp.php?vakID=" + vakid);
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
                    lstLO.Add(new Lesondewerp { LONaam = info[0], ID = info[1] });
                }
            }
            cbLO.ItemsSource = lstLO;
            lbLessen.ItemsSource = null;
        }

        private async void getLessen()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getLessen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getLessen.php?loID=" + selectedLOid);
            // gebruik eventueel PostAsync
            getLessen.EnsureSuccessStatusCode();

            string Lessen = null;
            Lessen = await getLessen.Content.ReadAsStringAsync();

            string[] items = Lessen.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstLes.Add(new Les() { LesNaam = info[0], ID = info[1] });
                }

            }
            lbLessen.ItemsSource = lstLes;
        }

        private void cbLO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLOid = cbLO.SelectedValue.ToString();

            //Leeg de les lijst
            lbLessen.ItemsSource = null;

            //Leeg de lists;
            lstLes.Clear();

            getLessen();
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

        private async void btBewerkLes_Click(object sender, RoutedEventArgs e)
        {
            if (lbLessen.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een les om deze te kunnen wijzigen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string lesid = ((Les)(lbLessen.SelectedItem)).ID;


                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedLesID = lesid;
                parameters.selectedloID = selectedLOid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(BewerkLes), parameters);
            }
        }

        private async void btVerwijderLes_Click(object sender, RoutedEventArgs e)
        {
            if (lbLessen.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een les om deze te kunnen wijzigen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string lesid = ((Les)(lbLessen.SelectedItem)).ID;
                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedLesID = lesid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(VerwijderLes), parameters);
            }
        }

        private void btNieuwLO_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;
            parameters.selectedVakID = vakid;

            this.Frame.Navigate(typeof(ToevoegLesonderwerp), parameters);
        }

        private async void btVerwijderLO_Click(object sender, RoutedEventArgs e)
        {
            string selectedLOid = cbLO.SelectedValue.ToString();
            if (cbLO.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een lesonderwerp om deze te kunnen verwijderen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedloID = selectedLOid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(VerwijderLesonderwerp), parameters);
            }
        }

        private async void btNieuwLes_Click(object sender, RoutedEventArgs e)
        {
            if (cbLO.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een lesonderwerp om er een les aan toe te voegen", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedloID = selectedLOid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(ToevoegLes), parameters);
            }
        }
    }
}
