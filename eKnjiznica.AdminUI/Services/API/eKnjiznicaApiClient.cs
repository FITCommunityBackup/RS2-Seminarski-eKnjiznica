using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using eKnjiznica.AdminUI.model;

namespace eKnjiznica.AdminUI.Services.API
{
    public class EKnjiznicaApiClient : IApiClient
    {
        HttpClient httpClient;

        public EKnjiznicaApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
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


        #region Private

        private Task<HttpResponseMessage> Get<T>(string path)
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
