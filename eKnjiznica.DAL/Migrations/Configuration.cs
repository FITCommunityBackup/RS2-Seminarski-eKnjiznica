namespace eKnjiznica.DAL.Migrations
{
    using eKnjiznica.DAL.EF;
    using eKnjiznica.DAL.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eKnjiznica.DAL.EF.EKnjiznicaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(EKnjiznicaDB context)
        {

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == EntityRoles.AdminRole))
            {
                var role = new IdentityRole { Name = EntityRoles.AdminRole };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == EntityRoles.ClientRole))
            {
                var role = new IdentityRole { Name = EntityRoles.ClientRole };
                manager.Create(role);
            }



            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@email.com", FirstName = "Admin", LastName = "Sistema", IsActive = true };
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);

                userManager.Create(user, "Password!1");
                userManager.AddToRole(user.Id, EntityRoles.AdminRole);
            }


            if (!context.Users.Any(u => u.UserName == "client"))
            {
                var user = new ApplicationUser {
                    UserName = "client",
                    Email = "client@email.com",
                    FirstName = "Client",
                    LastName = "Sistema",
                    IsActive = true,
                BirthDate=DateTime.Now.AddYears(-18)};
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);

                userManager.Create(user, "Password!1");
                userManager.AddToRole(user.Id, EntityRoles.ClientRole);
                context.UserFinancialAccounts.Add(new Model.UserFinancialAccount
                {
                    ApplicationUser = user,
                    Balance = 0
                });
                context.SaveChanges();
            }
        }

    }
}
