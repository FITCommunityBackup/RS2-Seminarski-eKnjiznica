using eKnjiznica.AdminUI.model;
using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.AdminUI.Services.API
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> LoginUser(LoginVM loginVM);
        Task<HttpResponseMessage> LoadAminAccounts(string usernameFilter);
        Task<HttpResponseMessage> CreateAdminAccount(AdminAddVM adminAdd);
        Task<HttpResponseMessage> UpdateAdminAccount(AdminUpdateVM adminUpdateVM);
        Task<HttpResponseMessage> GetAuditLogs();
    }
}
