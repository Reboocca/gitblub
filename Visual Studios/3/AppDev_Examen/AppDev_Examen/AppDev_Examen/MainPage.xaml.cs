using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDev_Examen
{
    public partial class MainPage : ContentPage
    {

        List<sproeier> LijstSproeiers = new List<sproeier>();
        List<lamp> LijstLampen = new List<lamp>();

        public MainPage()
        {
            InitializeComponent();
            HaalSproeierInfo();
        }

        private async void HaalSproeierInfo()
        {
            lbType.Text = "Sproeiers";
            LijstSproeiers = await ScadaWebservice.SproeierInfo();
            string stand;

            A1.Text = "A: " + Math.Round(LijstSproeiers[0].Actueel, 3) + " g/kg"; 
            B1.Text = "" + LijstSproeiers[0].Stand;
            C1.Text = "H: " + Math.Round(LijstSproeiers[0].Hoog, 3) + " g/kg";
            D1.Text = "L: " + Math.Round(LijstSproeiers[0].Laag, 3) + " g/kg";

            A2.Text = "A: " + Math.Round(LijstSproeiers[1].Actueel, 3) + " g/kg";
            B2.Text = "" + LijstSproeiers[1].Stand;
            C2.Text = "H: " + Math.Round(LijstSproeiers[1].Hoog, 3) + " g/kg";
            D2.Text = "L: " + Math.Round(LijstSproeiers[1].Laag, 3) + " g/kg";

            A3.Text = "A: " + Math.Round(LijstSproeiers[2].Actueel, 3) + " g/kg";
            B3.Text = "" + LijstSproeiers[2].Stand;
            C3.Text = "H: " + Math.Round(LijstSproeiers[2].Hoog, 3) + " g/kg";
            D3.Text = "L: " + Math.Round(LijstSproeiers[2].Laag, 3) + " g/kg";

            A4.Text = "A: " + Math.Round(LijstSproeiers[3].Actueel, 3) + " g/kg";
            B4.Text = "" + LijstSproeiers[3].Stand;
            C4.Text = "H: " + Math.Round(LijstSproeiers[3].Hoog, 3) + " g/kg";
            D4.Text = "L: " + Math.Round(LijstSproeiers[3].Laag, 3) + " g/kg";

            A5.Text = "A: " + Math.Round(LijstSproeiers[4].Actueel, 3) + " g/kg";
            B5.Text = "" + LijstSproeiers[4].Stand;
            C5.Text = "H: " + Math.Round(LijstSproeiers[4].Hoog, 3) + " g/kg";
            D5.Text = "L: " + Math.Round(LijstSproeiers[4].Laag, 3) + " g/kg";

            A6.Text = "A: " + Math.Round(LijstSproeiers[5].Actueel, 3) + " g/kg";
            B6.Text = "" + LijstSproeiers[5].Stand;
            C6.Text = "H: " + Math.Round(LijstSproeiers[5].Hoog, 3) + " g/kg";
            D6.Text = "L: " + Math.Round(LijstSproeiers[5].Laag, 3) + " g/kg";
        }

        private async void HaalLampInfo()
        {
            lbType.Text = "Lampen";
            LijstLampen = await ScadaWebservice.LampInfo();

            A1.Text = "A: " + LijstLampen[0].Actueel + " %";
            B1.Text = "B: ";
            C1.Text = "H: " + LijstLampen[0].Hoog + " W/m2";
            D1.Text = "L: " + LijstLampen[0].Laag + " W/m2";

            A2.Text = "A: " + LijstLampen[1].Actueel + " %";
            B2.Text = "B: ";
            C2.Text = "H: " + LijstLampen[1].Hoog + " W/m2";
            D2.Text = "L: " + LijstLampen[1].Laag + " W/m2";

            A3.Text = "A: " + LijstLampen[2].Actueel + " %";
            B3.Text = "B: ";
            C3.Text = "H: " + LijstLampen[2].Hoog + " W/m2";
            D3.Text = "L: " + LijstLampen[2].Laag + " W/m2";

            A4.Text = "A: " + LijstLampen[3].Actueel + " %";
            B4.Text = "B: ";
            C4.Text = "H: " + LijstLampen[3].Hoog + " W/m2";
            D4.Text = "L: " + LijstLampen[3].Laag + " W/m2";

            A5.Text = "A: " + LijstLampen[4].Actueel + " %";
            B5.Text = "B: ";
            C5.Text = "H: " + LijstLampen[4].Hoog + " W/m2";
            D5.Text = "L: " + LijstLampen[4].Laag + " W/m2";

            A6.Text = "A: " + LijstLampen[5].Actueel + " %";
            B6.Text = "B: ";
            C6.Text = "H: " + LijstLampen[5].Hoog + " W/m2";
            D6.Text = "L: " + LijstLampen[5].Laag + " W/m2";
        }

        private void Sproeier_Clicked(object sender, EventArgs e)
        {
            LijstSproeiers.Clear();
            HaalSproeierInfo();
        }

        private void Lamp_Clicked(object sender, EventArgs e)
        {
            LijstLampen.Clear();
            HaalLampInfo();
        }
    }
}
