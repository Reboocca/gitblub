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
    public sealed partial class DashboardAdmin : Page
    {
        //VARIABELEN
        public string userid;

        //STRUCTS
        struct Account
        {
            public string ID { get; set; }
            public string Voornaam { get; set; }
            public string Achternaam { get; set; }
        }

        //LISTS
        List<Account> lstAccounts = new List<Account>();

        public DashboardAdmin()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
        }

        public async void getAccounts()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getNamen = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/AdminDashboard/getAccounts.php?");
            // gebruik eventueel PostAsync
            getNamen.EnsureSuccessStatusCode();

            string result = null;
            result = await getNamen.Content.ReadAsStringAsync();

            string[] items = result.Split(',').ToArray();
            //XML HULP NODIG
            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    lstAccounts.Add(new Account() { ID = info[0], Voornaam = info[1], Achternaam = info[] });
                }

            }
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
