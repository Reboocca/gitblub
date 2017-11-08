using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Les7_Webservice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        List<String> namen = new List<String>();

        private async void Button_Clicked(object sender, EventArgs e)
        {
            radiolijst.ItemsSource = await Rest.GetOmroep(provincie.Text.Trim(), omroep.Text.Trim());
        }

    }
}
