using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Admin;
using eKnjiznica.CORE.Services.Logger;
using eKnjiznica.CORE.Services.Roles;
using eKnjiznica.DAL;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using eKnjiznica.DAL.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
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


            container.RegisterType<IUserStore<ApplicationUser>,
                UserStore<ApplicationUser>>();
            container.RegisterType<ApplicationUserManager>();

        }
    }
}