using Exact;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExactXamarinGLAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GLAList : ContentPage
    {
        public GLAList()
        {
            InitializeComponent();
            imageLogoExact.Source = ImageSource.FromResource("ExactXamarinGLAccount.logo-exact.png");
        }

        private async Task ToonGLAccounts()
        {
            string f = filter.Text.Trim();   //   .Text;
            list.ItemsSource = await Rest.getGLAccounts(f);
        }

        async void Select_Click(object sender, ItemTappedEventArgs e)
        {
            list.ItemsSource = null;
            GLAccount gla = e.Item as GLAccount;
            GLAEdit glaEdit = new GLAEdit();
            glaEdit.glaAccount = gla;
            await Navigation.PushModalAsync(glaEdit);
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await ToonGLAccounts();
        }
        async void filter_Completed(object sender, EventArgs e)
        {
            await ToonGLAccounts();
        }
    }
}