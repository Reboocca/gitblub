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
    public sealed partial class DagPlanning : Page
    {
        //VARIABELEN
        public string userid;

        //STRUCT
        struct Planning
        {
            public string Omschrijving { get; set; }
            public string ID { get; set; }
            public string LesID { get; set; }
        }

        //LIST
        List<Planning> lstPlanningen = new List<Planning>();

        public DagPlanning()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;

            GetPlanning();
        }

        private async void GetPlanning()
        {
            HttpClient planning = new HttpClient();
            HttpResponseMessage respons = await planning.GetAsync(new Uri("http://localhost/leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getPlanning.php?uID=" + userid + "&datum=" + DateTime.Now.ToString("yyyy-MM-dd")));

            respons.EnsureSuccessStatusCode();
            string jsonstring = await respons.Content.ReadAsStringAsync();

            JsonArray jsonArray = JsonArray.Parse(jsonstring);

            foreach (JsonValue jsonValue in jsonArray)
            {
                lstPlanningen.Add(new Planning() { Omschrijving = jsonValue.GetObject().GetNamedString("PlanningOmschrijving"), ID = jsonValue.GetObject().GetNamedString("PlanningID"), LesID = jsonValue.GetObject().GetNamedString("LesID") });
                getVoltooid(jsonValue.GetObject().GetNamedString("LesID"));
            }

            //Stop de gegevens in de listbox
            lbPlanning.ItemsSource = lstPlanningen;
        }
        private async void getVoltooid(string lesid)
        {
            HttpClient voltooid = new HttpClient();
            HttpResponseMessage respons1 = await voltooid.GetAsync(new Uri("http://localhost/leerjaar2/OP3/Owl-learn/functies/LeerlingDashboard/getVoltooid.php?lesid=" + lesid + "&userid=" + userid));
            respons1.EnsureSuccessStatusCode();

            string VoltooideLessen = await respons1.Content.ReadAsStringAsync();

            if (VoltooideLessen != "GeenResultaat")
            {
                lbVoltooid.Items.Add(VoltooideLessen);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new user();
            parameters.userID = userid;

            this.Frame.Navigate(typeof(DashboardLeerling), parameters);
        }

        private void btLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

