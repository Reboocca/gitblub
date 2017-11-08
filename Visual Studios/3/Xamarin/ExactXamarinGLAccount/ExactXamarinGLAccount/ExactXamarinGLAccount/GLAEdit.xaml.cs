using Exact;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace ExactXamarinGLAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GLAEdit : ContentPage
    {
        public string originalCode = null;
        public GLAccount glaAccount = null;
        public GLAEdit()
        {
            InitializeComponent();
            mijnImage.Source = ImageSource.FromResource("ExactXamarinGLAccount.logo-exact.png");
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Code.Text = glaAccount.Code;
            Description.Text = glaAccount.Description;
            originalCode = glaAccount.Code;
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            glaAccount.Code = Code.Text;
            glaAccount.Description = Description.Text; // doen met binding !!!
            if (glaAccount.Code == originalCode) await Rest.updateGLAccount(glaAccount); else await Rest.insertGLAccount(glaAccount);
            await Navigation.PopModalAsync();
        }
        private async void Delete_Click(object sender, EventArgs e)
        {
            await Rest.deleteGLAccount(glaAccount);
            await Navigation.PopModalAsync();
        }

        private void New_Click(object sender, EventArgs e)
        {
            Code.Text = "";
            Code.IsEnabled = true;
            Description.Text = "";
        }
        private async void Close_Click(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}