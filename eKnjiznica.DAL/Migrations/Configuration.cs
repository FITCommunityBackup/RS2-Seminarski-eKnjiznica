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
                var role = new IdentityRole { Name = EntityRoles.ClientRole};
                manager.Create(role);
            }



            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new ApplicationUser { UserName = "founder",Email="admin@email.com" };

                var userStore = new UserStore<ApplicationUser>();
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.Create(user, "Password!1");
                userManager.AddToRole(user.Id, EntityRoles.AdminRole);
            }
        }
    }
}
