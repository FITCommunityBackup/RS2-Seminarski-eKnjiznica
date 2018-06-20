using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unity;
using Unity.Lifetime;
using Unity.Injection;
using eKnjiznica.Commons.API;
using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using Unity.ServiceLocation;
using CommonServiceLocator;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace eKnjiznica.Mobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();


            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISettings>(new InjectionFactory(x=>CrossSettings.Current));
            container.RegisterType<SettingsHelper>(new InjectionFactory(x => new SettingsHelper(container.Resolve<ISettings>())));


            container.RegisterType<HttpClient>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => getHttpClient(container)));
            container.RegisterType<IApiClient, EKnjiznicaApiClient>(new ContainerControlledLifetimeManager());


            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);



            MainPage = new NavigationPage(new MainPage());

        }

        private HttpClient getHttpClient(IUnityContainer container)
        {
            var url = eKnjiznica.Mobile.Services.Constants.ServiceBaseUrl;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var settings = container.Resolve<SettingsHelper>();

            string token = settings.GetToken();
            string tokenType = settings.GetTokenType();

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
