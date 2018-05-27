using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.ErrorHandling;
using eKnjiznica.AdminUI.Services.User;
using eKnjiznica.AdminUI.UI.Administrators;
using eKnjiznica.AdminUI.UI.Categories;
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
            container.RegisterType<HttpClient>(new ContainerControlledLifetimeManager(),new InjectionFactory(x => getHttpClient(container)));
            container.RegisterType<IApiClient, EKnjiznicaApiClient>(new ContainerControlledLifetimeManager());
            
            container.RegisterType<ErrorHandlingUtil>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());


            container.RegisterType<CategoriesEditForm>();
            container.RegisterType<CategoriesAddForm>();
            container.RegisterType<CategoriesForm>();
            container.RegisterType<LogsForm>();
            container.RegisterType<AdministratorAddForm>();
            container.RegisterType<AdministratorsForm>();
            container.RegisterType<MainForm>();
            container.RegisterType<LoginForm>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());

        }

        private static HttpClient getHttpClient(IUnityContainer container)
        {
            var url = ConfigurationManager.AppSettings["ApiUrl"];
            var client = HttpClientFactory.Create(new TokenHandler() { RefreshTokenUri = url + "token", Container = container });
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
