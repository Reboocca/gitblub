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
    public sealed partial class ToetsPage : Page
    {
        //VARIABELEN
        public string userid;
        public string loID;
        public string _sVraagID;
        public int _piRadioButton = 99;
        public int _iIndex = 0;
        public int _iScore = 0;
        static Random rnd = new Random();

        //LISTS
        List<string> _lstAntwoorden = new List<string>();
        List<string> _lstVragen = new List<string>();
        List<string> _lstVraagIDs = new List<string>();
        List<string> _lstSelectieVragen = new List<string>();
        List<string> _lstSelectieIDs= new List<string>();
        List<string> _lstAntwoordID = new List<string>();

        public ToetsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            loID = parameters.selectedloID;

            //Vul de velden in
            getLOnaam();
            getVragenLijst();
        }

        public async void getVragenLijst()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getVraaginfo = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/getVragen.php?loID=" + loID);
            // gebruik eventueel PostAsync
            getVraaginfo.EnsureSuccessStatusCode();

            string Vragen = null;
            Vragen = await getVraaginfo.Content.ReadAsStringAsync();

            string[] items = Vragen.Split(']').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('^').ToArray();
                    _lstVragen.Add(info[0]);
                    _lstVraagIDs.Add(info[1]);
                }
            }
            SelectVragenfromList();
        }

        public void SelectVragenfromList()
        {
            for (int i = _lstSelectieVragen.Count; i < 20; i++)
            {
                int r = rnd.Next(_lstVraagIDs.Count - 1);
                bool contains = _lstSelectieVragen.Contains((string)_lstVraagIDs[r]);

                if (!contains)
                {
                    _lstSelectieVragen.Add((string)_lstVragen[r]);
                    _lstSelectieIDs.Add((string)_lstVraagIDs[r]);
                }
                else
                {
                    i -= 1;
                }
            }
            NextQuestion();
        }

        public async void getAntwoorden(string vID)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getAntwoorden = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/getAntwoorden.php?vID=" + vID);
            // gebruik eventueel PostAsync
            getAntwoorden.EnsureSuccessStatusCode();

            string Antwoorden = null;
            Antwoorden = await getAntwoorden.Content.ReadAsStringAsync();

            string[] items = Antwoorden.Split(']').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('^').ToArray();
                    _lstAntwoorden.Add(info[0]);
                    _lstAntwoordID.Add(info[1]);
                }
            }

            rbA.Content = _lstAntwoorden[0];
            rbB.Content = _lstAntwoorden[1];
            rbC.Content = _lstAntwoorden[2];
            rbD.Content = _lstAntwoorden[3];
        }

        public async void getLOnaam()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getNaam = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/getLonaam.php?loID=" + loID);
            // gebruik eventueel PostAsync
            getNaam.EnsureSuccessStatusCode();

            tbLOnaam.Text = await getNaam.Content.ReadAsStringAsync();
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

        private async void NextQuestion()
        {
            string sContentButton = btVerder.Content.ToString();

            if (sContentButton == "Volgende vraag")
            {
                if (_piRadioButton != 99)
                {
                    HttpClient connect = new HttpClient();
                    HttpResponseMessage checkAntwoord = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/checkAntwoord.php?antwoord=" + _lstAntwoorden[_piRadioButton] + "&vID=" + _sVraagID);
                    // gebruik eventueel PostAsync
                    checkAntwoord.EnsureSuccessStatusCode();

                    string Juist_onjuist = await checkAntwoord.Content.ReadAsStringAsync();

                    //Het antwoord is juist wanneer waarde 1 is teruggegeven, 2 is onjuist
                    if (Juist_onjuist == "1")
                    {
                        _iScore++;
                    }
                }


                if (_iIndex < _lstSelectieVragen.Count)
                {
                    tbVraag.Text = _lstSelectieVragen[_iIndex];
                    _sVraagID = _lstSelectieIDs[_iIndex];

                    _iIndex++;

                    rbA.IsChecked = false;
                    rbB.IsChecked = false;
                    rbC.IsChecked = false;
                    rbD.IsChecked = false;

                    _lstAntwoorden.Clear();
                    getAntwoorden(_sVraagID);
                }

                else
                {
                    btVerder.Content = "Toets inleveren";
                }
            }

            if (sContentButton == "Toets inleveren")
            {
                int eindScore = _iScore * 2;

                string sResultaat = "";

                switch (eindScore)
                {
                    case 40:
                        sResultaat = "10";
                        break;
                    case 38:
                        sResultaat = "9.6";
                        break;
                    case 36:
                        sResultaat = "9.2";
                        break;
                    case 34:
                        sResultaat = "8.8";
                        break;
                    case 32:
                        sResultaat = "8.4";
                        break;
                    case 30:
                        sResultaat = "8";
                        break;
                    case 28:
                        sResultaat = "7.5";
                        break;
                    case 26:
                        sResultaat = "7.1";
                        break;
                    case 24:
                        sResultaat = "6.8";
                        break;
                    case 22:
                        sResultaat = "6.3";
                        break;
                    case 20:
                        sResultaat = "5.9";
                        break;
                    case 18:
                        sResultaat = "5.5";
                        break;
                    case 16:
                        sResultaat = "5.0";
                        break;
                    case 14:
                        sResultaat = "4.5";
                        break;
                    case 12:
                        sResultaat = "4.0";
                        break;
                    case 10:
                        sResultaat = "3.5";
                        break;
                    case 8:
                        sResultaat = "3.0";
                        break;
                    case 6:
                        sResultaat = "2.5";
                        break;
                    case 4:
                        sResultaat = "2.0";
                        break;
                    case 2:
                        sResultaat = "1.5";
                        break;
                    case 0:
                        sResultaat = "1.0";
                        break;
                }

                if (eindScore >= 18)
                {
                    var dialog = new MessageDialog("Je hebt een " + sResultaat + " gehaald, je hebt een voldoende!.", "Goed gedaan!");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("Je hebt een " + sResultaat + " gehaald, je hebt helaas een onvoldoende.", "Volgende keer beter!");
                    await dialog.ShowAsync(); 
                }

                HttpClient connect = new HttpClient();
                HttpResponseMessage saveVoortgang = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Toetsform/saveVoortgang.php?loID=" + loID + "&uID=" + userid + "&score=" + sResultaat);
                // gebruik eventueel PostAsynco
                saveVoortgang.EnsureSuccessStatusCode();

                string resultaat = await saveVoortgang.Content.ReadAsStringAsync();
                if (resultaat == "failed")
                {
                    //Wanneer het mislukt is om de voortgang op te slaan, geef een foutmelding en ga terug naar het dashboard
                    var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van de toets", "Foutmelding");
                    await dialog1.ShowAsync();
                }

                var parameters = new user();
                parameters.userID = userid;

                this.Frame.Navigate(typeof(DashboardLeerling), parameters);

            }
        }

        private async void btVerder_Click(object sender, RoutedEventArgs e)
        {
            if (rbA.IsChecked == true)
            {
                _piRadioButton = 0;
                NextQuestion();
            }
            else if (rbB.IsChecked == true)
            {
                _piRadioButton = 1;
                NextQuestion();
            }
            else if (rbC.IsChecked == true)
            {
                _piRadioButton = 2;
                NextQuestion();
            }
            else if (rbD.IsChecked == true)
            {
                _piRadioButton = 3;
                NextQuestion();
            }
            else
            {
                var dialog = new MessageDialog("Zorg ervoor dat je een antwoord hebt aangevinkt!", "Foutmelding");
                await dialog.ShowAsync();
            }
        }
    }
}
