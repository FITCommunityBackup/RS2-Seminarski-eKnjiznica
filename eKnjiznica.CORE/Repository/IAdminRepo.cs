using eKnjiznica.CORE.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IAdminRepo
    {
        AdminAccount FindByUsername(string name);
        AdminAccount FindByEmail(string name);
        AdminAccount FindById(string id);
        AdminAccount AddAccount(AdminAccount adminAccount,string password);
        void ToggleAccountStatus(string id);
        AdminAccount UpdateAdminAccount(AdminAccount adminAccount);
        IList<AdminAccount> GetAdminAccounts(string username);
    }
}
