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
    public sealed partial class ToevoegLes : Page
    {
        //VARIABELEN
        public string userid;
        public string loid;
        public string vakid;

        public ToevoegLes()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            loid = parameters.selectedloID;
            vakid = parameters.selectedVakID;
        }
        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;
            parameters.selectedVakID = vakid;

            this.Frame.Navigate(typeof(BewerkVak), parameters);
        }

        private async void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaam.Text == "")
            {
                var dialog1 = new MessageDialog("Zorg ervoor dat u de benaming voor de les ingevuld heeft", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                SaveLes();
            }
        }

        private async void SaveLes()
        {
            HttpClient connect1 = new HttpClient();
            HttpResponseMessage saveVak = await connect1.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/ConsulentDashboard/saveNewLes.php?lNaam=" + tbNaam.Text + "&Uitleg=" + tbUitleg.Text + "&loid=" + loid);
            //gebruik eventueel PostAsync
            saveVak.EnsureSuccessStatusCode();

            string resultaat = await saveVak.Content.ReadAsStringAsync();

            if (resultaat == "failed")
            {
                var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van de nieuwe les", "Foutmelding");
                await dialog1.ShowAsync();
            }
            else
            {
                var dialog1 = new MessageDialog("De les is succesvol opgeslagen, u wordt nu teruggestuurd naar de vorige pagina.", "Succes!");
                await dialog1.ShowAsync();

                var parameters = new user();
                parameters.userID = userid;
                parameters.selectedVakID = vakid;

                this.Frame.Navigate(typeof(BewerkVak), parameters);
            }
        }
    }
}
