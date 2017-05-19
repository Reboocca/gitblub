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
    public sealed partial class LesPage : Page
    {
        //VARIABELEN
        public string userid;
        public string lesid;
        public string _sVraagID;
        public int _piRadioButton = 99;
        public int _iIndex = 0;
        public int _iScore = 0;

        //LISTS
        List<string> _lstAntwoorden = new List<string>();
        List<string> _lsVragen = new List<string>();
        List<string> _lstVraagIDs = new List<string>();
        List<string> _lstAntwoordID = new List<string>();

        public LesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (user)e.Parameter;
            userid = parameters.userID;
            lesid = parameters.selectedLes;

            //Vul de velden in
            getUitleg();
            getLesNaam();
            getVragenLijst();
        }

        public async void getUitleg()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getUitleg = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/getUitleg.php?lID=" + lesid);
            // gebruik eventueel PostAsync
            getUitleg.EnsureSuccessStatusCode();
            
            tbUitleg.Text = await getUitleg.Content.ReadAsStringAsync();
        }

        public async void getVragenLijst()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getVraaginfo = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/getVragen.php?lID=" + lesid);
            // gebruik eventueel PostAsync
            getVraaginfo.EnsureSuccessStatusCode();

            string Vragen = null;
            Vragen = await getVraaginfo.Content.ReadAsStringAsync();

            string[] items = Vragen.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    _lsVragen.Add(info[0]);
                    _lstVraagIDs.Add(info[1]);
                }
            }

            NextQuestion();
            getAntwoorden(_sVraagID);
        }

        public async void getAntwoorden(string vID)
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getAntwoorden = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/getAntwoorden.php?vID=" + vID);
            // gebruik eventueel PostAsync
            getAntwoorden.EnsureSuccessStatusCode();

            string Antwoorden = null;
            Antwoorden = await getAntwoorden.Content.ReadAsStringAsync();

            string[] items = Antwoorden.Split(',').ToArray();

            foreach (string i in items)
            {
                if (i != "")
                {
                    string[] info = i.Split('.').ToArray();
                    _lstAntwoorden.Add(info[0]);
                    _lstAntwoordID.Add(info[1]);
                }
            }

            rbA.Content = _lstAntwoorden[0];
            rbB.Content = _lstAntwoorden[1];
            rbC.Content = _lstAntwoorden[2];
            rbD.Content = _lstAntwoorden[3];
        }

        public async void getLesNaam()
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage getNaam = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/getLesNaam.php?lID=" + lesid);
            // gebruik eventueel PostAsync
            getNaam.EnsureSuccessStatusCode();

            tbLesnaam.Text = await getNaam.Content.ReadAsStringAsync();
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
                    HttpResponseMessage checkAntwoord = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/checkAntwoord.php?antwoord=" + _lstAntwoorden[_piRadioButton] + "&vID=" + _sVraagID );
                    // gebruik eventueel PostAsync
                    checkAntwoord.EnsureSuccessStatusCode();

                    string Juist_onjuist = await checkAntwoord.Content.ReadAsStringAsync();

                    //Het antwoord is juist wanneer waarde 1 is teruggegeven, 2 is onjuist
                    if (Juist_onjuist == "1")
                    {
                        _iScore++;
                    }
                }


                if (_iIndex < _lsVragen.Count)
                {
                    tbVraag.Text = _lsVragen[_iIndex];
                    _sVraagID = _lstVraagIDs[_iIndex];
                    
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
                    btVerder.Content = "Les inleveren";
                }
            }

            if (sContentButton == "Les inleveren")
            {
                if (_iScore >= (_lsVragen.Count / 2))
                {
                    var dialog = new MessageDialog("Je hebt " + _iScore.ToString() + " van de " + _lsVragen.Count.ToString() + " vragen goed beantwoord, de les is voltooid.", "Goed gedaan!");
                    await dialog.ShowAsync();

                    HttpClient connect = new HttpClient();
                    HttpResponseMessage saveVoortgang = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Lesform/saveVoortgang.php?lID=" + lesid + "&uID=" + userid);
                    // gebruik eventueel PostAsync
                    saveVoortgang.EnsureSuccessStatusCode();

                    string resultaat = await saveVoortgang.Content.ReadAsStringAsync();

                   if(resultaat == "failed")
                    {
                        //Wanneer het mislukt is om de voortgang op te slaan, geef een foutmelding en ga terug naar het dashboard
                        var dialog1 = new MessageDialog("Er is iets missgegaan met het opslaan van jouw voortgang", "Foutmelding");
                        await dialog1.ShowAsync();
                    }

                    var parameters = new user();
                    parameters.userID = userid;

                    this.Frame.Navigate(typeof(DashboardLeerling), parameters);
                }
                else
                {
                    var dialog = new MessageDialog("Je hebt " + _iScore.ToString() + " van de " + _lsVragen.Count.ToString() + " vragen goed beantwoord, maak de les opnieuw.", "Volgende keer beter!");
                    await dialog.ShowAsync();

                    var parameters = new user();
                    parameters.userID = userid;

                    this.Frame.Navigate(typeof(DashboardLeerling), parameters);
                }

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
