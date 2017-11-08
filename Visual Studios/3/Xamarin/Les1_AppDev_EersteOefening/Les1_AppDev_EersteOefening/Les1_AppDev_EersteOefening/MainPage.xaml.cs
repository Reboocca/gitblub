using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Les1_AppDev_EersteOefening
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bottom.Text = button.Text;
        }

    }
}
