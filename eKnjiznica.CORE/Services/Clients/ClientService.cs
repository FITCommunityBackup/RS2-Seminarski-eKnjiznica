using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Common.ViewModels.FinancialAccount;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Roles;

namespace eKnjiznica.CORE.Services.Clients
{
    public class ClientService : IClientService
    {
        private IClientRepo clientRepo;
        private IRoleService roleService;
        public ClientService(IClientRepo clientRepo, IRoleService roleService)
        {
            this.clientRepo = clientRepo;
            this.roleService = roleService;
        }

        public bool ChangeClientPassword(string userId, ClientUpdateVM vm)
        {
            return clientRepo.TryChangeUserPassword(userId, vm);
        }

        public ClientVM CreateClientAccount(ClientAddVM model, string v)
        {
            var role = roleService.GetRole("Client");
            var id = clientRepo.CreateClientAccount(model);
            clientRepo.AddClientToClientRole(id, role);
            clientRepo.CreateClientFinancialAccount(id);

            return clientRepo.GetClientById(id);
        }

        public ClientVM FindClientByEmail(string email)
        {
            return clientRepo.FindByEmail(email);
        }

        public ClientVM FindClientById(string id)
        {
            return clientRepo.GetClientById(id);

        }

        public ClientVM FindClientByUsername(string username)
        {
            return clientRepo.FindByUsername(username);

        }

        public ClientVM GetClientAccount(string userId)
        {
            return clientRepo.GetClientById(userId);
        }

        public List<ClientVM> GetClientAccounts(string username, bool includeInactive)
        {
            return clientRepo.GetClients(username, includeInactive);
        }

        public UserFinancialAccountVM GetUserFinancialAccount(string userId)
        {
            return clientRepo.GetUserFinancialAccount(userId);
        }

        public bool HasMoneyOnAccount(string userId, decimal amount)
        {
            var account = clientRepo.GetUserFinancialAccount(userId);
            if (account == null)
                return false;

            return account.Balance >= amount;
        }

        public void UpdateClientAccount(ClientUpdateVM model, string id)
        {
            clientRepo.UpdateClientAccount(model, id);
        }

     
    }
}
