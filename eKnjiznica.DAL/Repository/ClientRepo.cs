using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Model.Roles;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
        public ClientRepo(EKnjiznicaDB context, ApplicationUserManager applicationUserManager,IRoleRepo roleRepo)
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
                BirthDate = model.DateOfBirth

            };
            var result = applicationUserManager.Create(client, model.Password);
            if (result.Succeeded)
                return client.Id;
            else
                throw new Exception("Client not Created");
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
                .Where(x => x.Id.Equals(id)&& x.Roles.Any(y=>y.RoleId==role.Id))
                .Select(x => new ClientVM
                {
                    Id = x.Id,
                    AccountBalance = x.UserFinancialAccount.Balance,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    DateOfBirth = x.BirthDate.Value
                })
                .FirstOrDefault();
        }

        public List<ClientVM> GetClients(string username, bool includeInactive)
        {
            var role = roleRepo.FindRoleByName(EntityRoles.ClientRole);

            return context
                .Users
                .Where(x => x.UserName.Contains(username) || x.IsActive || includeInactive)
                .Where(x=>x.Roles.Any(y=>y.RoleId==role.Id))
                .Select(x => new ClientVM
                {
                    Id = x.Id,
                    AccountBalance = x.UserFinancialAccount.Balance,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    DateOfBirth = x.BirthDate.Value,
                    IsActive=x.IsActive
                })
                .ToList();
        }
    }
}
