using eKnjiznica.AdminUI.model;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Commons.ViewModels.Category;
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
        Task<HttpResponseMessage> GetCategories(string categoryNameFilter,bool includeInactiveCategories);
        Task<HttpResponseMessage> CreateCategory(CategoryAddVM model);
        Task<HttpResponseMessage> UpdateCategory(CategoryUpdateVm categoryUpdateVm, int id);
    }
}
