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
    public sealed partial class VerwijderAccount : Page
    {
        //VARIABELEN 
        public string userid;
        public string accountid;
        public VerwijderAccount()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            accountid = parameters.selectedAccountID;
        }

        private async void btAccept_Click(object sender, RoutedEventArgs e)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage deleteAccount = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/verwijderAccount.php?aID=" + accountid);
            // gebruik eventueel PostAsync
            deleteAccount.EnsureSuccessStatusCode();

            string resultaat = await deleteAccount.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                var dialog1 = new MessageDialog("Er is iets missgegaan met het verwijderen van het account", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("Het account is succesvol verwijdert, u wordt nu teruggestuurd naar het dashboard.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;

                this.Frame.Navigate(typeof(DashboardAdmin), parameters);
            }
        }

        private void bbtAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardAdmin), parameters);
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
