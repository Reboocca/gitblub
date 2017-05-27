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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Owl_learn_Blokboek5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        string login = "false";
        string rolID = null;

        private void login_Click(object sender, RoutedEventArgs e)
        {
            LoginFunction(tbUsername.Text, pbPassword.Password);
        }


        public async void LoginFunction(string user, string pwd)  // MainPage.xaml.cs        
        {
            HttpClient connect = new HttpClient();
            HttpResponseMessage logincheck = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Login/login.php?user=" + user + "&pwd=" + pwd);
            // gebruik eventueel PostAsync
            logincheck.EnsureSuccessStatusCode();

            login = await logincheck.Content.ReadAsStringAsync();

            if(login != "false")
            {
                HttpResponseMessage rolcheck = await connect.GetAsync("http://localhost/Leerjaar2/OP3/Owl-learn/functies/Login/rol.php?id=" + login );
                rolcheck.EnsureSuccessStatusCode();
                rolID = await rolcheck.Content.ReadAsStringAsync();

                if (rolID == "1")
                {
                    var parameters = new user();
                    parameters.userID = login;

                    this.Frame.Navigate(typeof(DashboardConsulent), parameters);
                }

                else if(rolID == "2")
                {
                    var parameters = new user();
                    parameters.userID = login;
                    this.Frame.Navigate(typeof(DashboardLeerling), parameters);
                }

                else if(rolID == "3")
                {
                    var parameters = new user();
                    parameters.userID = login;
                    this.Frame.Navigate(typeof(DashboardAdmin), parameters);

                }
                
            }
            else
            {
                var dialog = new MessageDialog("De gebruikte gebruikersnaam en/of wachtwoord is onjuist.", "Foutmelding");
                await dialog.ShowAsync();
            }
        }
    }
}
