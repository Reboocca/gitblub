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
    public sealed partial class VerwijderLes : Page
    {
        //VARIABELEN
        public string userid;
        public string lesid;
        public string vakid;

        public VerwijderLes()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            lesid = parameters.selectedLesID;
            vakid = parameters.selectedVakID;
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void bbtAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(BewerkVak), parameters);
        }

        private async void btAccept_Click(object sender, RoutedEventArgs e)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage deleteVak = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/verwijderLes.php?lesID=" + lesid);
            // gebruik eventueel PostAsync
            deleteVak.EnsureSuccessStatusCode();

            string resultaat = await deleteVak.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                var dialog1 = new MessageDialog("Er is iets missgegaan met het verwijderen van de les", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De les is succesvol verwijdert, u wordt nu teruggestuurd naar de vorige pagina.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(BewerkVak), parameters);
            }
        }
    }
}
