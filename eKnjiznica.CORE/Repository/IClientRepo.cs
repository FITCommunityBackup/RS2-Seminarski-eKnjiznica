using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Model.Roles;

namespace eKnjiznica.CORE.Repository
{
    public interface IClientRepo
    {
        string CreateClientAccount(ClientAddVM model);
        void AddClientToClientRole(string id, Role role);
        ClientVM GetClientById(string id);
        string CreateClientFinancialAccount(string id);
        List<ClientVM> GetClients(string username, bool includeInactive);
    }
}
