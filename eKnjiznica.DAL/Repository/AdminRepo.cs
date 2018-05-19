using eKnjiznica.CORE.Model.Admin;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Roles;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private EF.EKnjiznicaDB context;
        private ApplicationUserManager applicationUserManager;
        private IRoleService roleService;

        public AdminRepo(EKnjiznicaDB context, ApplicationUserManager applicationUserManager, IRoleService roleService)
        {
            this.context = context;
            this.applicationUserManager = applicationUserManager;
            this.roleService = roleService;
        }

        public AdminAccount AddAccount(AdminAccount adminAccount, string password)
        {
            var user = new ApplicationUser
            {
                UserName = adminAccount.Username,
                Email = adminAccount.Email,
                IsActive = true,
                FirstName = adminAccount.FirstName,
                LastName = adminAccount.LastName,
                PhoneNumber = adminAccount.PhoneNumber
            };

            var role = roleService.GetRole(EntityRoles.AdminRole);

            applicationUserManager.Create(user, password);
            applicationUserManager.AddToRole(user.Id, role.Name);

            adminAccount.Id = user.Id;
            return adminAccount;
        }

        public AdminAccount FindByEmail(string email)
        {
            var user = applicationUserManager.FindByEmail(email);
            if (user == null)
                return null;

            return new AdminAccount
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Username = user.UserName,
                IsActive = user.IsActive
            };

        }

        public AdminAccount FindById(string id)
        {
            var user = applicationUserManager.FindById(id);
            if (user == null)
                return null;

            return new AdminAccount
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Username = user.UserName,
                IsActive = user.IsActive
            };
        }

        public AdminAccount FindByUsername(string name)
        {
            var user = applicationUserManager.FindByName(name);
            if (user == null)
                return null;

            return new AdminAccount
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Username = user.UserName,
                IsActive = user.IsActive
            };
        }

        public IList<AdminAccount> GetAdminAccounts(string username)
        {
            var adminRole = roleService.GetRole(EntityRoles.AdminRole);
            var users = context.Users
                .Where(x => string.IsNullOrEmpty(username) || x.UserName.Contains(username))
                .Where(x => x.Roles.Any(y => y.RoleId.Equals(adminRole.Id))).ToList();
            return users
                .Select(x=> new AdminAccount
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Username = x.UserName,
                    IsActive = x.IsActive
                }).ToList();
        }

        public void ToggleAccountStatus(string id)
        {
            var user = context.Users.Where(x=>x.Id == id).First();
            user.IsActive = !user.IsActive;
            context.SaveChanges();
        }

        public AdminAccount UpdateAdminAccount(AdminAccount adminAccount)
        {
            var user  = context.Users.Where(x => x.Id == adminAccount.Id).FirstOrDefault();
            if (user == null)
                return null;
            user.FirstName = adminAccount.FirstName ?? user.FirstName;
            user.LastName = adminAccount.LastName?? user.LastName;
            user.Email = adminAccount.Email?? user.Email;
            user.PhoneNumber= adminAccount.PhoneNumber ?? user.PhoneNumber;
            user.PasswordHash = !string.IsNullOrEmpty(adminAccount.Password)?
                applicationUserManager.PasswordHasher.HashPassword(adminAccount.Password):
                user.PasswordHash;

            user.IsActive = adminAccount.IsActive;

            context.SaveChanges();

            return new AdminAccount
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
