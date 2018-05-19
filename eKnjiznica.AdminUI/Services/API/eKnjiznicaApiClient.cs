using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using eKnjiznica.AdminUI.model;
using eKnjiznica.Commons.ViewModels;

namespace eKnjiznica.AdminUI.Services.API
{
    public class EKnjiznicaApiClient : IApiClient
    {
        HttpClient httpClient;

        public EKnjiznicaApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<HttpResponseMessage> CreateAdminAccount(AdminAddVM adminAdd)
        {
            return Post<AdminAddVM>(adminAdd, "api/admin");
        }

        public Task<HttpResponseMessage> LoadAminAccounts(string usernameFilter)
        {
            if (string.IsNullOrEmpty(usernameFilter))
                return Get("api/admin");
            return Get($"api/admin?username={usernameFilter}");
        }

        public async Task<HttpResponseMessage> LoginUser(LoginVM loginVM)
        {
            var dict = new Dictionary<string, string>();

            dict.Add("username", loginVM.Username);
            dict.Add("password", loginVM.Password);
            dict.Add("grant_type", "password");
            var req = new HttpRequestMessage(HttpMethod.Post, "token") { Content = new FormUrlEncodedContent(dict) };
            return await httpClient.SendAsync(req);
        }

        public Task<HttpResponseMessage> UpdateAdminAccount(AdminUpdateVM adminUpdateVM)
        {
            return Patch<AdminUpdateVM>(adminUpdateVM, "api/admin");
        }

        public Task<HttpResponseMessage> GetAuditLogs()
        {
            return Get("api/admin/logs");
        }


        #region Private

        public  Task<HttpResponseMessage> Patch<T>(T value, string requestUri)
        {

            var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };

            return httpClient.SendAsync(request);
        }

        private Task<HttpResponseMessage> Get(string path)
        {
            return httpClient.GetAsync(path);
        }

        private Task<HttpResponseMessage> Post<T>(T body, string path)
        {
            return httpClient.PostAsJsonAsync(path, body);
        }

        private Task<HttpResponseMessage> Put<T>(T body, string path)
        {
            return httpClient.PutAsJsonAsync(path, body);
        }

     
        #endregion

    }
}
