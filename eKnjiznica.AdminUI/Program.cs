using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Injection;

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
            container.RegisterType<HttpClient>(new InjectionFactory(x =>
                    new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]) }
               ));
            container.RegisterType<IApiClient, EKnjiznicaApiClient>();
            container.RegisterType<ErrorHandlingUtil>();

            container.RegisterType<LoginForm>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<LoginForm>());
        }
    }
}
