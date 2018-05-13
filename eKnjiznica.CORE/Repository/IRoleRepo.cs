using eKnjiznica.CORE.Model.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IRoleRepo
    {
        Role AddRole(Role role);
        Role FindRoleByName(string name);
        Role FindRoleById(string id);
    }
}
