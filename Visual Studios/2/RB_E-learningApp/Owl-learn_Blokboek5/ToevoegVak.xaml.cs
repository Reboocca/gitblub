using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class ToevoegVak : Page
    {
        //VARIABELEN
        public string userid;

        public ToevoegVak()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
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

        private async void tbVaknaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(tbVaknaam.Text, @"^[\sa-zA-Z0-9]*$")) return;

            tbVaknaam.Text = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan in de benaming van het vak", "Foutmelding");
            await dialog.ShowAsync();
        }

        private async void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (tbVaknaam.Text == "")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat u alle invoervelden ingevuld heeft", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                SaveVak();
            }
        }

        private async void SaveVak()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage vak = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/checkVak.php?vNaam=" + tbVaknaam.Text);
            // gebruik eventueel PostAsync
            vak.EnsureSuccessStatusCode();

            string checkVaknaam = await vak.Content.ReadAsStringAsync();

            if (checkVaknaam == "Bestaat")
            {
                var dialog1 = new MessageDialog("De opgegeven benaming van het vak bestaat al, voer een unieke benaming in en sla het nieuwe vak op.", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                HttpClient connect1 = new HttpClient();
                HttpResponseMessage saveVak = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/saveNewVak.php?vNaam=" + tbVaknaam.Text);
                // gebruik eventueel PostAsync
                saveVak.EnsureSuccessStatusCode();

                string resultaat = await saveVak.Content.ReadAsStringAsync();

                if (resultaat == "failed")
                {
                    //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                    var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van het nieuwe vak", "Foutmelding");
                    await dialog1.ShowAsync();
                }
                else
                {
                    var dialog1 = new MessageDialog("Het vak is succesvol opgeslagen, u wordt nu teruggestuurd naar het dashboard.", "Succes!");
                    await dialog1.ShowAsync();

                    var parameters = new user();
                    parameters.userID = userid;

                    this.Frame.Navigate(typeof(DashboardConsulent), parameters);
                }
            }
        }
    }
}
