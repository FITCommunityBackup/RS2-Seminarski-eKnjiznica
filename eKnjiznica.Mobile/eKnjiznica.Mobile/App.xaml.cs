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
using eKnjiznica.Mobile.Services.User;
using eKnjiznica.Mobile.Navigation;
using Newtonsoft.Json;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Mobile.Services.UserBasket;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace eKnjiznica.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISettings>(new InjectionFactory(x => CrossSettings.Current));
            container.RegisterType<SettingsHelper>(new InjectionFactory(x => new SettingsHelper(container.Resolve<ISettings>())));


            container.RegisterType<HttpClient>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => getHttpClient(container)));
            container.RegisterType<IApiClient, EKnjiznicaApiClient>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserBasketService, UserBasketService>(new ContainerControlledLifetimeManager());


            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);


            var userService = container.Resolve<IUserService>();
            if (!userService.IsUserLogged())
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else if (userService.HasUserTokenExpired())
            {
                var apiService = container.Resolve<IApiClient>();
                if (refreshToken(userService, apiService))
                {
                    MainPage = new MyMasterDetailPage();
                }
                else
                    MainPage = new LoginPage();


            }
            else
            {
                MainPage = new MyMasterDetailPage();

            }
        }

        private bool refreshToken(IUserService userService, IApiClient apiService)
        {
            var oldAuth = userService.GetAuthenticationResponse();
            var response = apiService.RefreshToken(oldAuth.RefreshToken).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var newAuth = JsonConvert.DeserializeObject<AuthenticationResponseVM>(json);
                userService.SaveAuthenticationResponse(newAuth);
                apiService.AppendToken(newAuth);
            }
            return response.IsSuccessStatusCode;
        }

        private HttpClient getHttpClient(IUnityContainer container)
        {
            var url = eKnjiznica.Mobile.Services.Constants.ServiceBaseUrl;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            var settings = container.Resolve<SettingsHelper>();

            var authResponse = settings.GetAuthenticationResponse();
            string token = authResponse?.AccessToken;
            string tokenType = authResponse?.TokenType;

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(tokenType))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, token);
            }
            return client;
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
