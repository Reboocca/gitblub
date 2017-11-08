using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Les8_Ophaalpunten
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (CrossGeolocator.Current.IsGeolocationEnabled == false)
            {
                await DisplayAlert("Notification", "Geolocation is Unavailable ", "Ok");
            }
            else
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));

                NB.Text = "NB = " + position.Latitude.ToString();
                OL.Text = "OL = " + position.Longitude.ToString();
            }
        }

    }
}
