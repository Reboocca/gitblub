using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDev_Examenopdracht_RB
{
    public partial class MainPage : ContentPage
    {
        List<Sproeier> LijstSproeiers = new List<Sproeier>();
        List<Lamp> LijstLampen = new List<Lamp>();

        public MainPage()
        {
            InitializeComponent();
            HaalSproeierInfo();
        }

        private async void HaalSproeierInfo()
        {
            LijstSproeiers = await ScadaWebservice.SproeierInfo();
        }

        private async void HaalLampInfo()
        {
            LijstLampen = await ScadaWebservice.LampInfo();
        }
    }
    }
}
