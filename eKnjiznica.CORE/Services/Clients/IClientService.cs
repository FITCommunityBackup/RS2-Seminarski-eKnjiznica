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
        List<ClientVM> GetClientAccount(string username, bool includeInactive);
    }
}
