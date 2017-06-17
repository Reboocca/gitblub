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
    public sealed partial class Toetskiezen : Page
    {
        //VARIABELEN
        public string userid;

        //STRUCTS
        struct Vak
        {
            public string ID { get; set; }
            public string VakNaam { get; set; }
        }
        struct Lesonderwerp
        {
            public string ID { get; set; }
            public string LesonderwerpNaam { get; set; }
        }

        //LISTS
        List<Vak> lstVakken = new List<Vak>();
        List<Lesonderwerp> lstLesonderwerp = new List<Lesonderwerp>();

        public Toetskiezen()
        {
            this.InitializeComponent();
            getVakken();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardLeerling), parameters);
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
            HttpResponseMessage getLesonderwerp = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/getLesonderwerp.php?vakID=" + selectedVakID + "&datum=" + DateTime.Now.ToString("yyyy-MM-dd"));
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
                    lstLesonderwerp.Add(new Lesonderwerp() { LesonderwerpNaam = info[0], ID = info[1] });
                }

            }
            cbLesonderwerp.ItemsSource = lstLesonderwerp;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {

            if (cbLesonderwerp.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Kies eerst een lesonderwerp om verder te gaan", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string sLoID = ((Lesonderwerp)(cbLesonderwerp.SelectedItem)).ID;

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedloID = sLoID;

                this.Frame.Navigate(typeof(ToetsPage), parameters);
            }
        }

        private void cbVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedVakID = cbVak.SelectedValue.ToString();

            //Leeg de combobox
            cbLesonderwerp.ItemsSource = null;

            //Leeg de lists
            lstLesonderwerp.Clear();

            getLesonderwerp(selectedVakID);

            //Zet de button terug op false
            btStart.Content = "Kies een lesonderwerp om de toets te starten";
            btStart.IsEnabled = false;
        }

        private void cbLesonderwerp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLesonderwerp.ItemsSource != null)
            {
                btStart.Content = "Klik hier om de toets te starten";
                btStart.IsEnabled = true;
            }
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
