using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Les2_Hallo_Wereld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            loadImages();
        }


        public void loadImages()
        {
            img1.Source = ImageSource.FromResource("Les2_Hallo_Wereld.img1.png");
            img2.Source = ImageSource.FromResource("Les2_Hallo_Wereld.img2.png");
            img3.Source = ImageSource.FromResource("Les2_Hallo_Wereld.img3.png");
            img4.Source = ImageSource.FromResource("Les2_Hallo_Wereld.img4.png");
        }

        void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string Text = null;
            switch (button.Text)
            {
                case "French":
                    Text = "Bonjour le monde";
                    break;
                case "Dutch":
                    Text = "Hallo wereld";
                    break;
                case "German":
                    Text = "Hallo Welt";
                    break;
                case "Norwegian":
                    Text = "Hei Verden";
                    break;
            }
            
            btn1.BackgroundColor = Color.FromHex("#c63f17");
            btn2.BackgroundColor = Color.FromHex("#c63f17");
            btn3.BackgroundColor = Color.FromHex("#c63f17");
            btn4.BackgroundColor = Color.FromHex("#c63f17");

            button.BackgroundColor = Color.FromHex("#ff5722");
            lbText.Text = Text;
        }

    }
}
