using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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
    public sealed partial class Cijferlijst : Page
    {
        //VARIABELEN
        public string userid;

        //STRUCT
        struct Info
        {
            public string Vak { get; set; }
            public string Lesonderwerp { get; set; }
            public string Cijfer { get; set; }
        }

        //LISTS
        List<Info> lstInformatie = new List<Info>();

        public Cijferlijst()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;

            getInformatieJSON();
        }

        private async void getInformatieJSON()
        {
            HttpClient info = new HttpClient();
            HttpResponseMessage respons = await info.GetAsync(new Uri("http://localhost/leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getCijfers.php?uID=" + userid));

            respons.EnsureSuccessStatusCode();
            string jsonstring = await respons.Content.ReadAsStringAsync();

            JsonArray jsonArray = JsonArray.Parse(jsonstring);

            foreach (JsonValue jsonValue in jsonArray)
            {
                //Sla iedere company op in de list
                lstInformatie.Add(new Info() { Vak = jsonValue.GetObject().GetNamedString("Vak"), Lesonderwerp = jsonValue.GetObject().GetNamedString("Lesonderwerp"), Cijfer = jsonValue.GetObject().GetNamedString("Resultaat") });
            }

            //Stop de gegevens in de listview
            lvInfo.ItemsSource = lstInformatie;
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardLeerling), parameters);
        }
    }
}
