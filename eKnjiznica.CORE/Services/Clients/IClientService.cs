using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Clients;

namespace eKnjiznica.CORE.Services.Clients
{
    public interface IClientService
    {
        ClientVM CreateClientAccount(ClientAddVM model, string v);
        List<ClientVM> GetClientAccounts(string username, bool includeInactive);
        ClientVM GetClientAccount(string userId);
        ClientVM FindClientByEmail(string email);
        ClientVM FindClientByUsername(string username);
        ClientVM FindClientById(string id);
        void UpdateClientAccount(ClientUpdateVM model, string id);

        bool HasMoneyOnAccount(string userId,decimal amount);
        bool ChangeClientPassword(string v, ClientUpdateVM vm);
    }
}
