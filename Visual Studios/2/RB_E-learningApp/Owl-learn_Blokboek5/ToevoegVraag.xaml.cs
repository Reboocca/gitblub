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
    public sealed partial class ToevoegVraag : Page
    {
        //VARIABELEN
        public string userid;
        public string vakid;
        public string lesid;
        public string loid;
        public int iJuistAntwoord;

        public ToevoegVraag()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            lesid = parameters.selectedLesID;
            loid = parameters.selectedloID;
            vakid = parameters.selectedVakID;
        }

        private async void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (tbVraag.Text ==  "" || tbA.Text == "" || tbB.Text == "" || tbC.Text == "" || tbD.Text == "")
            {
                var dialog = new MessageDialog("Zorg ervoor dat u alle invoervelden heeft gevuld.", "Foutmelding");
                await dialog.ShowAsync();
            }
            else if (rbA.IsChecked == true)
            {
                iJuistAntwoord = 1;
                SaveVraag();
            }
            else if (rbB.IsChecked == true)
            {
                iJuistAntwoord = 2;
                SaveVraag();
            }
            else if (rbC.IsChecked == true)
            {
                iJuistAntwoord = 3;
                SaveVraag();
            }
            else if (rbD.IsChecked == true)
            {
                iJuistAntwoord = 4;
                SaveVraag();
            }
            else
            {
                var dialog = new MessageDialog("Zorg ervoor dat u een juist antwoord aangevinkt heeft.", "Foutmelding");
                await dialog.ShowAsync();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;
            parameters.selectedVakID = vakid;
            parameters.selectedLesID = lesid;

            this.Frame.Navigate(typeof(BewerkLes), parameters);
        }

        private async void SaveVraag()
        {
            HttpClient connect1 = new HttpClient();
            HttpResponseMessage saveVraag = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/saveNewVraag.php?vraag=" + tbVraag.Text + "&lesid=" + lesid + "&loid=" + loid + "&A=" + tbA.Text +"&B=" + tbB.Text + "&C=" + tbC.Text + "&D=" + tbD.Text + "&juist=" + iJuistAntwoord);
            //gebruik eventueel PostAsync
            saveVraag.EnsureSuccessStatusCode();

            string resultaat = await saveVraag.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van de nieuwe vraag", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De vraag met antwoorden zijn succesvol opgeslagen, u wordt nu teruggestuurd naar de vorige pagina.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedVakID = vakid;
                parameters.selectedLesID = lesid;
                parameters.selectedloID = loid;

                this.Frame.Navigate(typeof(BewerkLes), parameters);
            }
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
