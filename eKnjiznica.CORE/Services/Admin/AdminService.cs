using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.CORE.Model.Admin;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Admin
{
    public class AdminService : IAdminService
    {
        private IAdminRepo adminRepo;

        public AdminService(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public void AddAdminAccount(AdminAccount adminAccount,string password)
        {
            adminRepo.AddAccount(adminAccount,password);
        }

        public AdminAccount FindById(string id)
        {
            return adminRepo.FindById(id);
        }

        public AdminAccount FindByUsernameOrEmail(string username, string email)
        {
            var admin = adminRepo.FindByUsername(username);
            if (admin != null)
                return admin;
            admin = adminRepo.FindByEmail(email);

            return admin;
        }

        public IList<AdminAccount> GetAdminAccountList(string username)
        {
            return adminRepo.GetAdminAccounts(username);
        }

        public void ToggleAdminAccountStatus(string id)
        {
            adminRepo.ToggleAccountStatus(id);
        }

        public AdminAccount UpdateAdminAccount(AdminAccount adminAccount)
        {
            return adminRepo.UpdateAdminAccount(adminAccount);
        }
    }
}
