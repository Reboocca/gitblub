using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Owl_learn_Blokboek5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardLeerling : Page
    {
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
        struct Les
        {
            public string ID { get; set; }
            public string LesNaam { get; set; }
        }

        //LISTS
        List<Vak> lstVakken = new List<Vak>();
        List<Lesonderwerp> lstLesonderwerp = new List<Lesonderwerp>();
        List<Les> lstLes = new List<Les>();

        //PARAMETERS
        string userid;

        public DashboardLeerling()
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
                    lstVakken.Add(new Vak(){VakNaam = info[0], ID = info[1] });
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
                    lstLesonderwerp.Add(new Lesonderwerp() { LesonderwerpNaam = info[0], ID = info[1] });
                }

            }
            cbLesonderwerp.ItemsSource = lstLesonderwerp;
            cbLes.ItemsSource = null;
        }

        public async void getLes(string selectedLOid)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getLessen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getLessen.php?loID=" + selectedLOid);
            // gebruik eventueel PostAsync
            getLessen.EnsureSuccessStatusCode();

            string Les = null;
            Les = await getLessen.Content.ReadAsStringAsync();

            string[] items = Les.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstLes.Add(new Les() { LesNaam = info[0], ID = info[1] });
                }

            }
            cbLes.ItemsSource = lstLes;
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void cbVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedVakID = cbVak.SelectedValue.ToString();

            //Leeg de comboboxen
            cbLesonderwerp.ItemsSource = null;
            cbLes.ItemsSource = null;

            //Leeg de lists
            lstLesonderwerp.Clear();
            lstLes.Clear();

            getLesonderwerp(selectedVakID);

            //Zet de button terug op false
            btStart.Content = "Kies eerst een les om te beginnen";
            btStart.IsEnabled = false;

        }

        private void cbLesonderwerp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbLesonderwerp.ItemsSource != null)
            {
                string selectedLOid = cbLesonderwerp.SelectedValue.ToString();

                //Leeg de comboboxen
                cbLes.ItemsSource = null;
                lstLes.Clear();

                getLes(selectedLOid);

                //Zet de button terug op false
                btStart.Content = "Kies eerst een les om te beginnen";
                btStart.IsEnabled = false;
            }
        }

        private void cbLes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLes.ItemsSource != null)
            {
                btStart.Content = "Klik hier om de les te starten";
                btStart.IsEnabled = true;
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if(cbLes.SelectedIndex == -1)
            {
                tbNoLes.Text = "Je moet eerst een les kiezen, voordat je verder kan";
            }
            else
            {
                string sLesID = ((Les)(cbLes.SelectedItem)).ID;

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedLes = sLesID;

                this.Frame.Navigate(typeof(LesPage), parameters);
            }
        }

        private void btToets_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(Toetskiezen), parameters);
        }
    }
}
