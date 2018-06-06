using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<ClientVM> GetClientAccount(string username, bool includeInactive)
        {
            return clientRepo.GetClients(username, includeInactive);
        }

        public void UpdateClientAccount(ClientUpdateVM model, string id)
        {
            clientRepo.UpdateClientAccount(model, id);
        }
    }
}
