using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Mobile.Services
{
  
    public class MobileApiClient : IApiClient
    {
        private HttpClient httpClient;
        public MobileApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<HttpResponseMessage> LoginUser(string username,string password)
        {
            var dict = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password },
                { "grant_type", "password" }
            };
            var req = new HttpRequestMessage(HttpMethod.Post, "token") { Content = new FormUrlEncodedContent(dict) };
            return httpClient.SendAsync(req);
        }
    }
}
