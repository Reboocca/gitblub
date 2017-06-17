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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EindToets_AppDev_Rebecca_Broens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            HaalLijstCompanies();
        }
        //Struct voor de gegevens van een company
        struct Company
        {
            public string Name { get; set; }
            public string No { get; set; }
        }
        //Struct opgehaalde gegevens aan de hand van de zoekfunctie
        struct Info
        {
            public string PartNo { get; set; }
            public string Description { get; set; }
            public string Cost { get; set; }
        }

        //Lijst voor de opgehaalde companies
        List<Company> lstCompanies = new List<Company>();

        //Lijst met informatie van de opgehaalde gegevens
        List<Info> lstInfo = new List<Info>();


        async void HaalLijstCompanies()
        {
            HttpClient companies = new HttpClient();
            HttpResponseMessage respons = await companies.GetAsync(new Uri("http://localhost/leerjaar2/OP3/AppDev/eindtoets/stakeholder.php"));

            respons.EnsureSuccessStatusCode();
            string jsonstring = await respons.Content.ReadAsStringAsync();

            JsonArray jsonArray = JsonArray.Parse(jsonstring);
            
            foreach (JsonValue jsonValue in jsonArray)
            {
                //Sla iedere company op in de list
                lstCompanies.Add(new Company() { Name = jsonValue.GetObject().GetNamedString("Name"), No = jsonValue.GetObject().GetNamedString("No") });
            }

            //Stop alle companies in de combobox 
            cbCompany.ItemsSource = lstCompanies;
        }

        async void HaalInfo(string sNo)
        {
            HttpClient info = new HttpClient();
            HttpResponseMessage respons = await info.GetAsync(new Uri("http://localhost/leerjaar2/OP3/AppDev/eindtoets/stakeholder.php?vendorno=" + sNo));

            respons.EnsureSuccessStatusCode();
            string jsonstring = await respons.Content.ReadAsStringAsync();

            JsonArray jsonArray = JsonArray.Parse(jsonstring);

            foreach (JsonValue jsonValue in jsonArray)
            {
                //Sla iedere company op in de list
                lstInfo.Add(new Info() { PartNo = jsonValue.GetObject().GetNamedString("No"), Description = jsonValue.GetObject().GetNamedString("Description"), Cost = jsonValue.GetObject().GetNamedString("Cost") });
            }

            //Stop de gegevens in de listview
            lvInfo.ItemsSource = lstInfo;
        }

        private void cbCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Leeg de lijst en de listview voordat de nieuwe gegevens erin worden geplaatst
            lstInfo.Clear();
            lvInfo.ItemsSource = null;

            //Haal de juiste vendernummer op
            string selectedCompany = cbCompany.SelectedValue.ToString();

            //Haal de informatie op
            HaalInfo(selectedCompany);

        }
    }
}
