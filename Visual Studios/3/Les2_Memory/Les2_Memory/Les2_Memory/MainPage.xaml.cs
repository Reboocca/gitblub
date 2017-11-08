using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Les2_Memory
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadImages();
        }

        Classimg img;
        List<Classimg> lstImages = new List<Classimg>();

        public string ClickedImage1;
        public string ClickedImage2;
        public string img1Source;
        public string img2Source;



        public void LoadImages()
        {
            var rnd = new Random();
            var randomNumbers1 = Enumerable.Range(1, 6).OrderBy(x => rnd.Next()).Take(6).ToList();
            var randomNumbers2 = Enumerable.Range(1, 6).OrderBy(x => rnd.Next()).Take(6).ToList();
            var randomNumbers = randomNumbers1.Concat(randomNumbers2);

            int i = 1;

            foreach(int imgnumber in randomNumbers)
            {
                img = new Classimg();
                img.Name = "i" + i.ToString();
                img.Picture = imgnumber.ToString();
                img.Imgsource = ImageSource.FromResource("Les2_Memory.img." + imgnumber.ToString() + ".jpg");
                //grGrid.FindByName<Image>(img.Name).Source = img.Imgsource;
                lstImages.Add(img);

                i++;
            }
        }

        public void CheckImages(object sender, EventArgs e)
        {
            Image x = sender as Image;

            if (ClickedImage1 == x.ClassId)
            {
                DisplayAlert("Oh no", "You can't choose the same card twice", "Choose another");
            }
            else
            {
                if (ClickedImage1 == null)
                {
                    ClickedImage1 = x.ClassId;

                    foreach (Classimg ci in lstImages)
                    {
                        if (ci.Name == ClickedImage1)
                        {
                            grGrid.FindByName<Image>(ClickedImage1).Source = ci.Imgsource;
                        }
                    }

                }
                else if (ClickedImage2 == null)
                {
                    ClickedImage2 = x.ClassId;

                    foreach (Classimg ic in lstImages)
                    {
                        if (ic.Name == ClickedImage2)
                        {
                            grGrid.FindByName<Image>(ClickedImage2).Source = ic.Imgsource;
                        }
                    }

                    RightWrongAsync();
                }
            }
        }

        public async void RightWrongAsync()
        {
            foreach (Classimg ci in lstImages)
            {
                if (ci.Name == ClickedImage1)
                {
                    img1Source = ci.Picture;
                }
                else if (ci.Name == ClickedImage2)
                {
                    img2Source = ci.Picture;
                }
            }
            
            int nr1 = Int32.Parse(img1Source);
            int nr2 = Int32.Parse(img2Source);

            if( nr1 == nr2)
            {

                var answer = await DisplayAlert("You got it!", "Up to the next one", "", "Alright");
                
                //Hide the images that were guessed right this turn
                grGrid.FindByName<Image>(ClickedImage1).IsVisible = false;
                grGrid.FindByName<Image>(ClickedImage2).IsVisible = false;

                //Empty the images clicked
                ClickedImage1 = null;
                ClickedImage2 = null;

            }
            else
            {
                var answer = await DisplayAlert("Oops?", "The selected cards don't match", "", "Try again");

                grGrid.FindByName<Image>(ClickedImage1).Source = "";
                grGrid.FindByName<Image>(ClickedImage2).Source = "";

                //Empty the images clicked
                ClickedImage1 = null;
                ClickedImage2 = null;
            }
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            //Make every image visible again
            foreach (Classimg ci in lstImages)
            {
                grGrid.FindByName<Image>(ci.Name).IsVisible = true;
                grGrid.FindByName<Image>(ci.Name).Source = "";
            }

            //Clear the list you made
            lstImages.Clear();

            //Clear clicked images just in case
            ClickedImage1 = null;
            ClickedImage2 = null;

            //Assign the images again
            LoadImages();
        }
    }
}
