using eKnjiznica.CORE.Model.Roles;
using eKnjiznica.CORE.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class RoleRepo : IRoleRepo
    {
        RoleManager<IdentityRole> roleManager;

        public RoleRepo(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public Role AddRole(Role role)
        {
            var newRole = new IdentityRole
            {
                Name = role.Name
            };
            roleManager.Create(newRole);

            role.Id = newRole.Id;
            return role;
        }

        public Role FindRoleById(string id)
        {
            var role = roleManager.FindById(id);
            return new Role
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public Role FindRoleByName(string name)
        {
            var role = roleManager.FindByName(name);
            return new Role
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
