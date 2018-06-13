using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Mobile.Services
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> LoginUser(string username, string password);
    }
}
