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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace les8_wk2_op4_AppDevv_Webservices
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

        async void HaalinfoHTML(object sender, TextChangedEventArgs e)  // MainPage.xaml.cs        
        {
            HttpClient klant = new HttpClient();
            HttpResponseMessage respons = await klant.GetAsync("http://localhost/Leerjaar2/OP3/AppDev/webservices/x.php?y=" + tbInput.Text);
            // gebruik eventueel PostAsync
            respons.EnsureSuccessStatusCode();
            tbTextblock.Text = await respons.Content.ReadAsStringAsync();
        }


}
}
