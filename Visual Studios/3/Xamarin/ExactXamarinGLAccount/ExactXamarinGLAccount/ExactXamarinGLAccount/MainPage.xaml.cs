using Exact;
using Xamarin.Forms;




namespace ExactXamarinGLAccount
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            getAuthorization();
        }
        private void getAuthorization()
        {
            string request = Constants.BASE_URI + "/api/oauth2/auth" +
                            "?client_id={" + Constants.CLIENT_ID + "}" +
                            "&redirect_uri=" + Constants.CALLBACK_URL +
                            "&state=" + Constants.CLIENT_STATE +
                            "&response_type=code&force_login=0";

            webBrowser.Source = request;
            webBrowser.Focus();
        }
        private void GetCode(string url)
        {
            if (url.IndexOf(Constants.BASE_URI) < 0)
            {
                int c = url.IndexOf("?code=");
                int s = url.IndexOf("&state=");
                OAuth.Code = url.Substring(c + 6, s - c - 6);
                OAuth.State = url.Substring(s + 7);
                Navigation.PopModalAsync();
                Navigation.PushModalAsync(new GLAList());
            }
        }
        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            GetCode(e.Url.ToString());
        }
        private void webBrowser_Navigating(object sender, WebNavigatingEventArgs e)
        {
            GetCode(e.Url.ToString());
        }
    }
}
