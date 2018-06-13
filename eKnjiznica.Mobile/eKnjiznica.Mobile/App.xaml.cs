using eKnjiznica.Mobile.Services.API;
using System;
using System.Net.Http;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace eKnjiznica.Mobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}



        private HttpClient getHttpClient(IUnityContainer container)
        {
            var url = Services.Constants.ServiceBaseUrl;

            var client = new HttpClient(new TokenHandler());
            client.Bas=
            HttpClientFactory.Create(new TokenHandler() { RefreshTokenUri = url + "token", Container = container });
            client.BaseAddress = new Uri(url);
            string token = Properties.Settings.Default.Token;
            string tokenType = Properties.Settings.Default.TokenType;
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(tokenType))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, token);
            }
            return client;
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
