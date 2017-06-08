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
    public sealed partial class ToevoegAccount : Page
    {
        //VARIABELEN
        public string userid;
        public string selectedTag;
        public ToevoegAccount()
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

        private async void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if( tbVoornaam.Text == "" || tbAchternaam.Text == "" || tbUsername.Text == "" || pbPassword.Password == "")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat je alle invoervelden ingevuld hebt", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else if (selectedTag == "0")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat je eerst de juiste rol selecteerd voordat je het account opslaat", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                //Alle invoervelden en de combobox is ingevoerd, sla het nieuwe account op
                saveNewAccount();
            }
        }

        private async void saveNewAccount()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage username = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/uniekUsername.php?uname=" + tbUsername.Text);
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
                HttpResponseMessage saveUser = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/saveNewAccount.php?vNaam=" + tbVoornaam.Text + "&aNaam=" + tbAchternaam.Text + "&gNaam=" + tbUsername.Text + "&ww=" + pbPassword.Password + "&rol=" + selectedTag);
                // gebruik eventueel PostAsync
                saveUser.EnsureSuccessStatusCode();

                string resultaat = await saveUser.Content.ReadAsStringAsync();

                if (resultaat == "failed")
                {
                    //Wanneer het mislukt is om het account op te slaan, geef een foutmelding en ga terug naar het dashboard
                    var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van het account", "Foutmelding");
                    await dialog1.ShowAsync();
                }
                else
                {
                    var dialog1 = new MessageDialog("Het account is succesvol opgeslagen, u wordt nu teruggestuurd naar het dashboard.", "Succes!");
                    await dialog1.ShowAsync();

                    var parameters = new user();
                    parameters.userID = userid;

                    this.Frame.Navigate(typeof(DashboardAdmin), parameters);
                }
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

        private async void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(tbUsername.Text, @"^[\sa-zA-Z0-9]*$")) return;

            tbUsername.Text = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van de gebruikersnaam", "Foutmelding");
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

        private async void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // \s - Stands for white space. The rest is for alphabets and numbers
            if (Regex.IsMatch(pbPassword.Password, @"^[\sa-zA-Z0-9]*$")) return;

            pbPassword.Password = String.Empty;
            var dialog = new MessageDialog("Speciale tekens zijn niet toegestaan bij het invoeren van het wachtwoord", "Foutmelding");
            await dialog.ShowAsync();
        }

        private void cbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTag = ((ComboBoxItem)cbRol.SelectedItem).Tag.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardAdmin), parameters);
        }
    }
}
