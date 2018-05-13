using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.CORE.Model.Roles;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Roles
{
    public class RoleService : IRoleService
    {
        private IRoleRepo roleRepo;

        public RoleService(IRoleRepo roleRepo)
        {
            this.roleRepo = roleRepo;
        }

        public Role GetRole(string roleName)
        {
            var role = roleRepo.FindRoleByName(roleName);
            if(role==null)
            {
                role = roleRepo.AddRole(new Role { Name = roleName });
            }
            return role;
        }
    }
}
