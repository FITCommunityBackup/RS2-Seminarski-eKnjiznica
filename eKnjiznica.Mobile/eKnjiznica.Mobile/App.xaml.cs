using eKnjiznica.Commons.API;
using System;
using System.Net.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
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

            IUnityContainer container = new UnityContainer();
            container.RegisterType<HttpClient>(new ContainerControlledLifetimeManager(), 
                new InjectionFactory(x => getHttpClient(container)));
            container.RegisterType<IApiClient, EKnjiznicaApiClient>(new ContainerControlledLifetimeManager());

        }

        private HttpClient getHttpClient(IUnityContainer container)
        {
            var url = eKnjiznica.Mobile.Services.Constants.ServiceBaseUrl;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //string token = Properties.Settings.Default.Token;
            //string tokenType = Properties.Settings.Default.TokenType;
            //if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(tokenType))
            //{
            //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, token);
            //}
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
