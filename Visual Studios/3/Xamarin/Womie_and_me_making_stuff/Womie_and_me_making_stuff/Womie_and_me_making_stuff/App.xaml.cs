using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Womie_and_me_making_stuff
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Womie_and_me_making_stuff.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
