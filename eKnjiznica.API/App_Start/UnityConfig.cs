using eKnjiznica.API.App_Start;
using eKnjiznica.API.Jobs;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Admin;
using eKnjiznica.CORE.Services.Auctions;
using eKnjiznica.CORE.Services.Books;
using eKnjiznica.CORE.Services.Categories;
using eKnjiznica.CORE.Services.ClientBooks;
using eKnjiznica.CORE.Services.Clients;
using eKnjiznica.CORE.Services.Documents;
using eKnjiznica.CORE.Services.EmailService;
using eKnjiznica.CORE.Services.Logger;
using eKnjiznica.CORE.Services.Roles;
using eKnjiznica.CORE.Services.Transaction;
using eKnjiznica.DAL;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using eKnjiznica.DAL.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Quartz;
using Quartz.Spi;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using Unity;
using Unity.Injection;

namespace eKnjiznica.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            var emailService = new EmailService
            {
                EmailFrom = ConfigurationManager.AppSettings["EmailAddress"],
                SmtpClient = new System.Net.Mail.SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["EmailHost"],
                    EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EmailEnableSsl"]),
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential
                    {
                        UserName = ConfigurationManager.AppSettings["EmailUsername"],
                        Password = ConfigurationManager.AppSettings["EmailPassword"]
                    },
                    Port = int.Parse(ConfigurationManager.AppSettings["EmailPort"])
                }
            };

            container.RegisterType<EmailService>(new InjectionFactory(x => emailService));
            container.RegisterType<IEmailService, EmailService>();



            container.RegisterType<DbContext, EKnjiznicaDB>();
            container.RegisterType<ILoggerRepo, LoggerRepo>();
            container.RegisterType<ILoggerService,LoggerService>();
            container.RegisterType<IRoleStore<IdentityRole,string>,RoleStore<IdentityRole,string,IdentityUserRole>>();
            container.RegisterType<RoleManager<IdentityRole>>();
            container.RegisterType<IRoleRepo,RoleRepo>();
            container.RegisterType<IRoleService, RoleService>();

            container.RegisterType<IUserStore<ApplicationUser>,UserStore<ApplicationUser>>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<IAdminRepo, AdminRepo>();
            container.RegisterType<IAdminService, AdminService>();

            container.RegisterType<ICategoriesRepo,CategoriesRepo>();
            container.RegisterType<ICategoriesService, CategoriesService>();

            container.RegisterType<IBookRepo, BookRepo>();
            container.RegisterType<IBookService, BookService>();

            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<IClientRepo, ClientRepo>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<ITransactionsRepo, TransactionRepo>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IClientBooksRepo, ClientBooksRepo>();
            container.RegisterType<IClientBooksService, ClientBooksService>();
            container.RegisterType<IAuctionRepo, AuctionsRepo>();
            container.RegisterType<IAuctionService, AuctionService>();

            container.RegisterType<IUserStore<ApplicationUser>,
                UserStore<ApplicationUser>>();
            container.RegisterType<ApplicationUserManager>();


            container.RegisterType<ISchedulerFactory,UnitySchedulerFactory>();
            container.RegisterType<IJobFactory,MyJobFactory>();
            QuartzConfig.Config(container);




        }
    }
}