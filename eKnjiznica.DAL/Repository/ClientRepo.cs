using eKnjiznica.Common.ViewModels.FinancialAccount;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Model.Roles;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class ClientRepo : IClientRepo
    {
        private EKnjiznicaDB context;
        private ApplicationUserManager applicationUserManager;
        private IRoleRepo roleRepo;
        public ClientRepo(EKnjiznicaDB context, ApplicationUserManager applicationUserManager, IRoleRepo roleRepo)
        {
            this.roleRepo = roleRepo;
            this.applicationUserManager = applicationUserManager;
            this.context = context;
        }

        public void AddClientToClientRole(string id, Role role)
        {
            applicationUserManager.AddToRole(id, role.Name);
        }

        public string CreateClientAccount(ClientAddVM model)
        {
            var client = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.DateOfBirth,
                IsActive = true
            };
            var result = applicationUserManager.Create(client, model.Password);
            if (result.Succeeded)
                return client.Id;
            else
                throw new Exception("Client not Created");
        }


        public ClientVM FindByEmail(string email)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);
            return context
                .Users
                .Include(x=>x.PurchasedBooks)
                .Include(x=>x.UserFinancialAccount)
                .Where(x => x.Email.Equals(email) && x.Roles.Any(y => y.RoleId == role.Id))
                .Select(ClientMapper())
                .FirstOrDefault();
        }

        private static System.Linq.Expressions.Expression<Func<ApplicationUser, ClientVM>> ClientMapper()
        {
            return x => new ClientVM
            {
                Id = x.Id,
                AccountBalance = x.UserFinancialAccount.Balance,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                DateOfBirth = x.BirthDate.Value,
                IsActive = x.IsActive,
                PhoneNumber = x.PhoneNumber,
                BookNumber = x.PurchasedBooks.Count
            };
        }

        public ClientVM FindByUsername(string username)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);
            return context
                .Users
                .Where(x => x.UserName.Equals(username) && x.Roles.Any(y => y.RoleId == role.Id))
                .Include(x => x.PurchasedBooks)
                .Include(x => x.UserFinancialAccount)
                .Select(ClientMapper())
                .FirstOrDefault();
        }


        public string CreateClientFinancialAccount(string id)
        {
            var account = new UserFinancialAccount
            {
                UserFinancialAccountId = id,
                Balance = 0
            };

            context.UserFinancialAccounts
               .Add(account);
            context.SaveChanges();

            return account.UserFinancialAccountId;
        }

        public ClientVM GetClientById(string id)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);
            return context
                .Users
                .Where(x => x.Id.Equals(id) && x.Roles.Any(y => y.RoleId == role.Id))
                .Include(x => x.PurchasedBooks)
                .Include(x => x.UserFinancialAccount)
                .Select(ClientMapper())
                .FirstOrDefault();
        }

        public List<ClientVM> GetClients(string username, bool includeInactive)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);

            return context
                .Users
                .Where(x => (string.IsNullOrEmpty(username)||  x.UserName.Contains(username)) &&( x.IsActive || includeInactive))
                .Where(x => x.Roles.Any(y => y.RoleId == role.Id))
                .Include(x => x.PurchasedBooks)
                .Include(x => x.UserFinancialAccount)
                .Select(ClientMapper())
                .ToList();
        }

        public void UpdateClientAccount(ClientUpdateVM model, string id)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);
            var user = context.Users
                .Where(x => x.Id.Equals(id))
                .Where(x => x.Roles.Any(y => y.RoleId == role.Id)).FirstOrDefault();

            if (user == null)
                return;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.BirthDate = model.DateOfBirth;
            user.IsActive = model.IsActive;
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = applicationUserManager.PasswordHasher.HashPassword(model.Password);
            context.SaveChanges();
        }

        public UserFinancialAccountVM GetUserFinancialAccount(string userId)
        {
            return context.UserFinancialAccounts.Where(x => x.UserFinancialAccountId == userId)
                 .Select(x => new UserFinancialAccountVM
                 {
                     Balance = x.Balance,
                     Id = x.UserFinancialAccountId
                 }).FirstOrDefault();
        }

        public bool TryChangeUserPassword(string userId, ClientUpdateVM vm)
        {
            return applicationUserManager.ChangePassword(userId, vm.OldPassword, vm.Password).Succeeded;
        }
    }
}
