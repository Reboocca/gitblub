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
    public sealed partial class BewerkAccount : Page
    {
        //VARIABELEN
        public string userid;
        public string selectedTag;
        public string accoundid;

        public BewerkAccount()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            accoundid = parameters.selectedAccountID;

            getAccountInfo();
        }

        private async void getAccountInfo()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getinfo = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/getAccountinfo.php?aID=" + accoundid);
            // gebruik eventueel PostAsyncnseMessage getinfo = awa
            getinfo.EnsureSuccessStatusCode();

            string info = null;
            info = await getinfo.Content.ReadAsStringAsync();

            string[] items = info.Split('.').ToArray();
            tbVoornaam.Text = items[0];
            tbAchternaam.Text = items[1];
            tbUsername.Text = items[2];

        }
        private async void wijzigInlogGegevens()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage username = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/eigenUsername.php?uname=" + tbUsername.Text + "&aID=" + accoundid);
            // gebruik eventueel PostAsync
            username.EnsureSuccessStatusCode();

            string checkUsername = await username.Content.ReadAsStringAsync();

            if (checkUsername == "Bestaat")
            {
                var dialog1 = new MessageDialog("De opgegeven gebruikersnaam is al in gebruik, voer een andere gebruikersnaam in", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                HttpClient connect1 = new HttpClient();
                HttpResponseMessage saveUser = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/wijzigInlog.php?aID=" + accoundid + "&uNaam=" + tbUsername.Text + "&ww=" + pbPassword.Password);
                // gebruik eventueel PostAsync
                saveUser.EnsureSuccessStatusCode();

                string resultaat = await saveUser.Content.ReadAsStringAsync();

                if (resultaat == "failed")
                {
                    //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                    var dialog1 = new MessageDialog("Er is iets missgegaan met het wijzigen van het account", "Foutmelding");
                    await dialog1.ShowAsync();
                }
                else
                {
                    var dialog1 = new MessageDialog("De inloggegevens zijn succesvol gewijzigd, u wordt nu teruggestuurd naar het dashboard.", "Succes!");
                    await dialog1.ShowAsync();

                    var parameters = new user();
                    parameters.userID = userid;

                    this.Frame.Navigate(typeof(DashboardAdmin), parameters);
                }
            }
        }
        private async void wijzigAccountGegevens()
        {
            HttpClient connect1 = new HttpClient();
            HttpResponseMessage saveUser = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/wijzigAccount.php?aID=" + accoundid + "&vNaam=" + tbVoornaam.Text + "&aNaam=" + tbAchternaam.Text);
            // gebruik eventueel PostAsync
            saveUser.EnsureSuccessStatusCode();

            string resultaat = await saveUser.Content.ReadAsStringAsync();
            if (resultaat == "failed")
            {
                //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van de gegevens", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De gegevens zijn succesvol opgeslagen, u wordt nu teruggestuurd naar het dashboard.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;

                this.Frame.Navigate(typeof(DashboardAdmin), parameters);
            }
        }

        private async void tbVoornaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(tbVoornaam.Text, @"^[\sa-zA-Z0-9]*$")) return;

            tbVoornaam.Text = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van de voornaam", "Foutmelding");
            await dialog.ShowAsync();
        }

        private async void tbAchternaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(tbAchternaam.Text, @"^[\sa-zA-Z0-9]*$")) return;

            tbAchternaam.Text = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van de achternaam", "Foutmelding");
            await dialog.ShowAsync();
        }

        private async void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(tbUsername.Text, @"^[\sa-zA-Z0-9]*$")) return;

            tbUsername.Text = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van de gebruikersnaam", "Foutmelding");
            await dialog.ShowAsync();
        }

        private async void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(pbPassword.Password, @"^[\sa-zA-Z0-9]*$")) return;

            pbPassword.Password = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van het wachtwoord", "Foutmelding");
            await dialog.ShowAsync();
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardAdmin), parameters);
        }

        private async void btWijzigGegevens_Click(object sender, RoutedEventArgs e)
        {
            if (tbVoornaam.Text == "" || tbAchternaam.Text == "")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat je de invoervelden: voornaam en achternaam ingevoerd zijn", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                //Alle invoervelden en de combobox is ingevoerd, wijzig de gegevens
                wijzigAccountGegevens();
            }
        }

        private async void btWijziglogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "" || pbPassword.Password == "")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat je de invoervelden: gebruikersnaam en wachtwoord ingevoerd zijn", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                //Alle invoervelden en de combobox is ingevoerd, wijzig de gegevens
                wijzigInlogGegevens();
            }
        }
    }
}
