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
    public sealed partial class BewerkLes : Page
    {//VARIABELEN
        public string userid;
        public string vakid;
        public string lesid;
        public string loid;

        //STRUCTS
        struct Vraag
        {
            public string ID { get; set; }
            public string Omschrijving { get; set; }
        }

        //LISTS
        List<Vraag> lstVragen = new List<Vraag>();

        public BewerkLes()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            vakid = parameters.selectedVakID;
            lesid = parameters.selectedLesID;
            loid = parameters.selectedloID;

            getVragen();
        }
        

        private async void getVragen()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getVraag = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/getVragen.php?lesID=" + lesid);
            // gebruik eventueel PostAsync
            getVraag.EnsureSuccessStatusCode();

            string result = null;
            result = await getVraag.Content.ReadAsStringAsync();

            string[] items = result.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstVragen.Add(new Vraag() { Omschrijving = info[0], ID = info[1] });
                }

            }
            lbVragen.ItemsSource = lstVragen;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;
            parameters.selectedVakID = vakid;
            parameters.selectedloID = loid;

            this.Frame.Navigate(typeof(BewerkVak), parameters);
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btNieuw_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;
            parameters.selectedVakID = vakid;
            parameters.selectedloID = loid;
            parameters.selectedLesID = lesid;

            this.Frame.Navigate(typeof(ToevoegVraag), parameters);
        }

        private async void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbVragen.SelectedIndex == -1)
            {
                var dialog = new MessageDialog("Selecteer eerst een vraag om deze te kunnen verwijderen.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else
            {
                string selectedVraag = ((Vraag)(lbVragen.SelectedItem)).ID;
                VerwijderVraag(selectedVraag);
            }
        }

        private async void VerwijderVraag(string vraagid)
        {
            HttpClient connect1 = new HttpClient();
            HttpResponseMessage deleteVraag = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/verwijderVraag.php?vraagID=" + vraagid);
            //gebruik eventueel PostAsync
            deleteVraag.EnsureSuccessStatusCode();

            string resultaat = await deleteVraag.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                var dialog1 = new MessageDialog("Er is iets missgegaan met het verwijderen van de vraag en antwoorden, contacteer een beheerder", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De vraag met antwoorden zijn succesvol vernietigd, de lijst zal ververst worden.", "Succes!");
                await dialog1.ShowAsync();
                
                //Leeg de listbox
                lbVragen.ItemsSource = null;

                //Leeg de lists;
                lstVragen.Clear();

                //Stop de vragen er opnieuw in
                getVragen();
            }
        }
    }
}
