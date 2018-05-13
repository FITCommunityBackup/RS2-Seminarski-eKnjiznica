using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.CORE.Model.Roles;
namespace eKnjiznica.CORE.Services.Roles
{
    public interface IRoleService
    {
        Role GetRole(string roleName);
    }
}
