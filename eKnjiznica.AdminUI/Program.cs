using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.ErrorHandling;
using eKnjiznica.AdminUI.Services.User;
using eKnjiznica.AdminUI.UI.Administrators;
using eKnjiznica.AdminUI.UI.Logs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
namespace eKnjiznica.AdminUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            IUnityContainer container = new UnityContainer();
            container.RegisterType<HttpClient>(new InjectionFactory(x => getHttpClient()));

            container.RegisterType<IApiClient, EKnjiznicaApiClient>();

            var r = container.Resolve<IApiClient>();
            container.RegisterType<ErrorHandlingUtil>();

            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());


            container.RegisterType<LogsForm>();
            container.RegisterType<AdministratorAddForm>();
            container.RegisterType<AdministratorsForm>();
            container.RegisterType<MainForm>();
            container.RegisterType<LoginForm>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(container.Resolve<MainForm>());
            }
            catch (ApiUnauthorizedException unathorizedException)
            {
                Properties.Settings.Default.RefreshToken = "";
                Properties.Settings.Default.Token="";
                Properties.Settings.Default.TokenType="";
                Properties.Settings.Default.Save();

                Application.Exit();
                Application.Run(container.Resolve<MainForm>());

            }
        }

        private static HttpClient getHttpClient()
        {
            var url = ConfigurationManager.AppSettings["ApiUrl"];
            var client = HttpClientFactory.Create(new TokenHandler { RefreshTokenUri =url+"token" });
            client.BaseAddress = new Uri(url);
            string token = Properties.Settings.Default.Token;
            string tokenType = Properties.Settings.Default.TokenType;
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(tokenType))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, token);
            }
            return client;
        }
    }
}
